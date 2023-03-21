using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAndPlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerPrefab;
    [SerializeField]
    private GameObject EnemyPrefab;
    public GameObject Player { get; private set; }
    public List<GameObject> Enemies { get; private set; }
    [SerializeField]
    private float checkPointDelta;
    private float lastEnemySpawnDistance = 0;
    [SerializeField]
    private float SpawnInterval = 50;
    private int numberOfSpawnEnemies = 1;
    private int CurrentCheckPoint = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Player = Instantiate(PlayerPrefab) as GameObject;
        Player.transform.position = new Vector3(0, 1.1f, 0);
        Enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.GameIsFinished)
            return;
        if (Player.transform.position.z - lastEnemySpawnDistance > SpawnInterval)
        {
            SpawnEnemies();
        }
    }
    private void SpawnEnemies()
    {
        if (checkPointDelta * (CurrentCheckPoint + 1) < Player.transform.position.z)
        {
            CurrentCheckPoint++;
            numberOfSpawnEnemies++;
        }
        for (int j = 0; j < numberOfSpawnEnemies; j++)
        {
            GameObject enemy = Instantiate(EnemyPrefab) as GameObject;
            enemy.transform.position = Player.transform.position + new Vector3(0, 0, 10+j);
            Debug.Log("Spawn at:" + enemy.transform.position);
            Enemies.Add(enemy);
            Enemy script = enemy.GetComponent<Enemy>();
            script.start = true;
            //MainManager.OnEnemyIsSpawned();
            MainManager.UIManager.EnemyIsSpawned(script);
        }
        lastEnemySpawnDistance += SpawnInterval;
    }
}
