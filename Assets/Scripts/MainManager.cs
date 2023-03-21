using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainManager : MonoBehaviour
{
    public static EnemyAndPlayerManager EnemyAndPlayerManager;
    public static CameraScript CameraScript;
    public static SceneGenerator SceneGenerator;
    public static GameProgressManager GameProgressManager;
    public static UIManager UIManager;
    public static bool GameIsFinished { get; private set; } = false;
    public float TimeSinceStart { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        EnemyAndPlayerManager = GetComponent<EnemyAndPlayerManager>();
        CameraScript = Camera.main.GetComponent<CameraScript>();
        GameProgressManager = GetComponent<GameProgressManager>();
        SceneGenerator = GetComponent<SceneGenerator>();
        UIManager = GetComponent<UIManager>();
        TimeSinceStart = 0;
    }
    private void Start()
    {
        CameraScript.SetTarget(EnemyAndPlayerManager.Player.transform);
    }
    public static void FinishGame()
    {
        GameIsFinished = true;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceStart += Time.deltaTime;
    }
    public static event EventHandler EnemyIsKilled;
    public static event EventHandler EnemyIsSpawned;
    //public static void OnEnemyIsKilled()
    //{
    //    EventHandler handler = EnemyIsKilled;
    //    if (handler != null)
    //        handler(null, new EventArgs());
    //}
    //public static void OnEnemyIsSpawned()
    //{
    //    EventHandler handler = EnemyIsSpawned;
    //    if (handler != null)
    //        handler(null, new EventArgs());
    //}
}
