using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Road
/// </summary>
public class TestMoveRoad : MonoBehaviour
{
    [HideInInspector]public float roadSpeed = 10f;
    [HideInInspector]private float increaseDelay = 20f;
    [HideInInspector] private float maxSpeed = 25f;

    private void Start()
    {
        roadSpeed = 10f;
        StartCoroutine(IncreaseRoadSpeed());
    }

    void Update()
    {
        if (!GameManager.Instance.gameOver)
        {

            transform.Translate(Vector3.back * Time.deltaTime * roadSpeed);
        }
    }

    void  RoadMove()
    {
        transform.Translate(Vector3.back * Time.deltaTime * roadSpeed);
    }

    IEnumerator IncreaseRoadSpeed()
    {
        while (!GameManager.Instance.gameOver && roadSpeed <= maxSpeed)
        {
            yield return new WaitUntil(() => Time.time >= increaseDelay);
            increaseDelay += 30f;
            roadSpeed *= 1.2f;
        }
    }
}
