using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damagable
{
    public float Velocity=2;
    public int Damage;
    public float MinDistance = 1;
    // Start is called before the first frame update
    CharacterController controller;
    private float timeSinceLastDamageToPlayer = 100;
    public float TimeBetweenDamage = 1;
    public bool start = false;
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.GameIsFinished)
            return;
        Debug.Log("Pos:" + transform.position);
        if(!start)
            return;
        //transform.Translate(0, 0, Time.deltaTime);
        if (transform.position.z - MainManager.EnemyAndPlayerManager.Player.transform.position.z > MinDistance)
        {
            Debug.Log("Move:" + new Vector3(0, 0, -Velocity * Time.deltaTime));
            transform.Translate(new Vector3(0, 0, -Velocity * Time.deltaTime));
            //controller.Move(new Vector3(0, 0, -Velocity * Time.deltaTime));
        }
        else if (TimeBetweenDamage < timeSinceLastDamageToPlayer)
        {
            timeSinceLastDamageToPlayer = 0;
            DamagePlayer();
        }

        timeSinceLastDamageToPlayer += Time.deltaTime;
    }
    private void DamagePlayer()
    {
        Damagable script = MainManager.EnemyAndPlayerManager.Player.GetComponent<PlayerMovment>() as Damagable;
        MainManager.UIManager.PlayerIsHited(Damage);
        script.Damage(Damage);
    }

    public override void Die()
    {
        Debug.Log("EnemyDie");
        MainManager.UIManager.EnemyIsKilled(this);
        MainManager.GameProgressManager.EnemiIsKilled();
        Destroy(this.gameObject);
    }
}
