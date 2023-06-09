using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : Damagable
{
    // Start is called before the first frame update
    CharacterController controller;
    [SerializeField]
    private float Veclocity = 3;
    [SerializeField]
    private float MaxFireDistance = 10;
    private bool stop = false;
    private GameObject targetEnemy = null;
    private float timeSinceLastDamageToEnemy = 100;
    [SerializeField]
    private float TimeBetweenDamage = 1;
    [SerializeField]
    private int Damage = 5;
    [SerializeField]
    public GameObject bulletPrefab;
    [SerializeField]
    private float BulletVelocity=5;
    private Animator animator;
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.GameIsFinished)
            return;
        //transform.Translate(0, 0, Time.deltaTime);
        timeSinceLastDamageToEnemy += Time.deltaTime;
        stop = CheckToStop();
        if (!stop)
            transform.Translate(new Vector3(0, 0, Veclocity * Time.deltaTime));
        else
        {
            if (TimeBetweenDamage < timeSinceLastDamageToEnemy)
            {
                timeSinceLastDamageToEnemy = 0;
                DamageEnemy(targetEnemy, Damage);
            }

            timeSinceLastDamageToEnemy += Time.deltaTime;
        }
    }
    private void DamageEnemy(GameObject target, int damage)
    {
        //target.GetComponent<Enemy>().Damage(damage);
        //return;
        if (target == null)
            return;
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = this.transform.position;
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bullet != null)
        {
            bulletScript.Damage = damage;
            bulletScript.Velocity = BulletVelocity;
            bulletScript.StartMoving(target.transform.position);
            ///
        }
    }
    private bool CheckToStop()
    {
        foreach(GameObject enemy in MainManager.EnemyAndPlayerManager.Enemies)
        {
            if (enemy == null)
                continue;
            if (enemy.transform.position.z - transform.position.z <= MaxFireDistance)
            {
                targetEnemy = enemy;
                return true;
            }
        }
        return false;
    }
    public override void Die()
    {
        MainManager.FinishGame();
        Debug.Log("PlayerDie");
        transform.Rotate(0, 0, 90);
    }
    public void Enhanse(Feature feature)
    {
        switch (feature)
        {
            case Feature.AtackSpeed:
                TimeBetweenDamage = TimeBetweenDamage / 1.2f;
                break;
            case Feature.Damage:
                Damage++;
                break;
            case Feature.Health:
                HP += 10;
                if (HP < MaxHP)
                    HP = MaxHP;
                break;
        }
    }
}
