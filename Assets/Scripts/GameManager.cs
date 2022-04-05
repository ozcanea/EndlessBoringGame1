using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonGM 
{
    ParticleSystem[] particle;
    private void Start()
    {
        particle=GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<ParticleSystem>();
    }
    void Update()
    {
        if(!gameOver)Spawn();
        if (gameOver)
        {
            foreach (ParticleSystem p in particle)
            {
                p.Stop();
            }
        } //stop particul systems
    }
    void Spawn()
    {
        if (timeManager.spawnTime<= 0)
        {
            GameManager.Instance.spawnManager.ReadyForSpawn();
            timeManager.spawnTime = timeManager.spawnDelay;
            if (timeManager.spawnDelay > timeManager.minTime)
                timeManager.spawnDelay= timeManager.DecreaseSpawnDelay(timeManager.spawnDelay, timeManager.decrease);
        }
        else
        {
            timeManager.spawnTime =timeManager.DecreaseUpToDeltaTime(timeManager.spawnTime);
        }
    }
   
}
