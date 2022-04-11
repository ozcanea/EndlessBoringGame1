using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// GameManager->TimeManager
/// </summary>
public class TimeManager : MonoBehaviour
{
    [HideInInspector]public float gameTime;
    [HideInInspector] public float spawnTime;
    public float spawnDelay;
    public float decrease;
    public float minTime;

    public float DecreaseSpawnDelay(float spawnD,float decrementValue)
    {
       return spawnD -= decrementValue;
    }
    public float DecreaseUpToDeltaTime(float time)
    {
        return time - Time.deltaTime;
    }
}
