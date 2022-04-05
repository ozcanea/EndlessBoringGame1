using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// GameManager->Transporter
/// </summary>
public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    [SerializeField] private float offset = 60f;

    float newAxisZ;
    void Start()
    {
       
        if(roads!=null&&roads.Count>0)
        {
            roads=roads.OrderBy(r=>r.transform.position.z).ToList();
        }
    }
    public void MoveTransport()
    {
        GameObject moveRoad=roads[0];
        roads.Remove(moveRoad);
        newAxisZ=roads[roads.Count-1].transform.position.z+offset;
        moveRoad.transform.position=new Vector3(0,0,newAxisZ);
        roads.Add(moveRoad);
        
    }
  
}
