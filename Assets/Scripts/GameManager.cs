using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : SingletonGM
{

    private void Start()
    {
        
    }
    void Update()
    {
        Debug.Log(gameOver);
        
        if (!gameOver)
        {
            
            Spawn();

            if (score > PlayerPrefs.GetInt("highScore", 0))
            {
                highScore = score;
                PlayerPrefs.SetInt("highScore", score);
            }



        }

    }
    void Spawn()
    {
        if (timeManager.spawnTime <= 0)
        {
            spawnManager.ReadyForSpawn();
            timeManager.spawnTime = timeManager.spawnDelay;
            if (timeManager.spawnDelay > timeManager.minTime)
                timeManager.spawnDelay = timeManager.DecreaseSpawnDelay(timeManager.spawnDelay, timeManager.decrease);
        }
        else
        {
            timeManager.spawnTime = timeManager.DecreaseUpToDeltaTime(timeManager.spawnTime);
        }
    }

  
  
}