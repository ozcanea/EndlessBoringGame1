using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// where is the script located?
/// Road->Trigger
/// </summary>
public class RoadTrigger : MonoBehaviour
{
    [HideInInspector] RoadSpawner rs;

    private void Start()
    {
        rs = FindObjectOfType<RoadSpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!GameManager.Instance.gameOver)
        rs.MoveTransport();
    }
}
