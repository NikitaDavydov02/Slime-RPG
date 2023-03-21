using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGenerator : MonoBehaviour
{
    [SerializeField]
    private float distanceOfGenerating;
    private float lastSpawnZCoordinate = 0;
    [SerializeField]
    private GameObject SpawnPrefab;
    private List<GameObject> spawnedPlanes;
    // Start is called before the first frame update
    void Start()
    {
        spawnedPlanes = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.GameIsFinished)
            return;
        if (lastSpawnZCoordinate-MainManager.EnemyAndPlayerManager.Player.transform.position.z < distanceOfGenerating)
        {
            GameObject plane =Instantiate(SpawnPrefab) as GameObject;
            plane.transform.position = new Vector3(0, 0, lastSpawnZCoordinate + 10);
            lastSpawnZCoordinate += 10;
            spawnedPlanes.Add(plane);
        }
        List<GameObject> planesToDelete = new List<GameObject>();
        foreach (GameObject plane in spawnedPlanes)
        {
            if (MainManager.EnemyAndPlayerManager.Player.transform.position.z - plane.transform.position.z > 10)
            {
                planesToDelete.Add(plane);
            }
        }
        foreach(GameObject plane in planesToDelete)
        {
            spawnedPlanes.Remove(plane);
            Destroy(plane);
        }
    }
}
