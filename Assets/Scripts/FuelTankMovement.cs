using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// FuelTank Prefab
/// </summary>
public class FuelTankMovement : MonoBehaviour
{
    TestMoveRoad tMR;
    float rotateSpeed = 100f;
    void Start()
    {
        tMR=FindObjectOfType<TestMoveRoad>();        
    }


    void Update()
    {

        if (!GameManager.Instance.gameOver)
        {
            transform.Translate(Vector3.back * Time.deltaTime * tMR.roadSpeed, Space.World);
            transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime, Space.World);
        }
    }

}
