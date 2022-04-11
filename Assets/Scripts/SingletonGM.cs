using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingletonGM : MonoBehaviour
{
    private static SingletonGM _instance;
    public static SingletonGM Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SingletonGM>();

                if (_instance == null)
                    _instance = new GameObject("Game Manager").AddComponent<SingletonGM>();
            }
            return _instance;
        }
    }
    [HideInInspector] public bool gameOver = false;
    [HideInInspector] public SpawnManager1 spawnManager;
    [HideInInspector] public TimeManager timeManager;
    [HideInInspector] public int score = 0;
    [HideInInspector] public int highScore;
    
    public void Awake()
    {



        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
            Destroy(gameObject);

        spawnManager = GetComponentInChildren<SpawnManager1>();
        timeManager = GetComponentInChildren<TimeManager>();
        
        

    }
    public void StopGame()
    {
        Time.timeScale = 0;
    }




}
