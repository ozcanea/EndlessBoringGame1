using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// FuelTank->prefab
/// </summary>
public class CollectableHit : MonoBehaviour
{
    [SerializeField] Material[] playerMesh = new Material[3];
    MeshRenderer fuelTankMesh;
    public Collider player;

    private void Start()
    {
        playerMesh = GameObject.FindGameObjectWithTag("Body").GetComponent<MeshRenderer>().materials;
        player = GameObject.FindWithTag("Player").GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        fuelTankMesh = GetComponent<MeshRenderer>();
        if (!GameManager.Instance.gameOver && playerMesh[0].color.Equals(fuelTankMesh.material.color)&&other.tag=="Player")
        {
            Destroy(gameObject);
            //GameManager.Instance.score++;
            GameManager.Instance.score += 10;
            Debug.Log(GameManager.Instance.score);
        }
        if (!GameManager.Instance.gameOver && !playerMesh[0].color.Equals(fuelTankMesh.material.color) && other.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.Instance.gameOver = true;
        }
    }
}