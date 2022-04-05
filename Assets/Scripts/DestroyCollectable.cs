using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// CollectableDestroyer
/// </summary>
public class DestroyCollectable : MonoBehaviour
{
    MeshRenderer playerMesh;
    private void Start()
    {
        playerMesh=GameObject.FindWithTag("Body").GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
    
        if(other.GetComponent<MeshRenderer>().material.color.Equals(playerMesh.materials[0].color))
        {
            GameManager.Instance.gameOver = true;
        }
        Destroy(other.gameObject);
    }
}
