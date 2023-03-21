using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damagable : MonoBehaviour
{
    [SerializeField]
    public int HP;
    [SerializeField]
    public int MaxHP;
    public void Damage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            Die();
        }
    }
    public void Heal(int heal)
    {
        HP += heal;
        if (HP >= MaxHP)
        {
            HP = MaxHP;
        }
    }
    public abstract void Die();
    void Start()
    {
       
    }
    void Update()
    {
    }
}
