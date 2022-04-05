using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Road
/// </summary>
public class TestMoveRoad : MonoBehaviour
{
    public float roadSpeed = 10f;
    [SerializeField]private float increaseDelay = 30f;
    [SerializeField] private float maxSpeed = 25f;

    private void Start()
    {
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
