using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Velocity;
    private Vector3 EndPoint= Vector3.zero;
    private Vector3 StartPoint;
    private Vector3 direction;
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.GameIsFinished)
            return;
        if (EndPoint != Vector3.zero)
        {
            transform.Translate(direction * Velocity * Time.deltaTime, Space.World);
        }
    }
    public void StartMoving(Vector3 EndPoint)
    {
        StartPoint = this.gameObject.transform.position;
        this.EndPoint = EndPoint;
        direction = (EndPoint - StartPoint).normalized;
        Debug.Log("Start");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(Damage);
            MainManager.UIManager.EnemyIsHited(enemy, Damage);
            Destroy(this.gameObject);
        }
    }
}
