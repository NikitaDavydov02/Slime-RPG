using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameProgressManager : MonoBehaviour
{
    public int CurrentCoints { get; private set; } = 0;
    public int KilledEnemies { get; private set; } = 0;
    // Start is called before the first frame updateC
    void Start()
    {
        //MainManager.EnemyIsKilled += EnemiIsKilled;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.GameIsFinished)
            return;
    }
    public void EnemiIsKilled()
    {
        CurrentCoints += 10;
        KilledEnemies++;
        //MainManager.UIManager.UpdateCoins();
    }
    
}
