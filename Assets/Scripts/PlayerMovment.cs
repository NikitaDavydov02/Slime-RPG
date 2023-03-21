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


    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
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
            controller.Move(new Vector3(0, 0, Veclocity * Time.deltaTime));
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
            bulletScript.Damage = this.Damage;
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
}
