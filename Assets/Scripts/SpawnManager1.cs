using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManager->SpawnManager
/// </summary>
public class SpawnManager1 : MonoBehaviour
{
    [SerializeField] GameObject fuelTankPrefab;
    [HideInInspector] public int palet;
    [HideInInspector] public int secondPalet;
    [HideInInspector] public int firstRoad;
    [HideInInspector] public int secondRoad;
    public Material[] materials = new Material[3];
    public Transform[] spanwPoints;
    [HideInInspector] public GameObject newObject;
    [HideInInspector] public MeshRenderer mR;
    public bool isMultiple = false;

    public bool LaneAmount()
    {
        return Random.Range(0, 2) == 0 ? true : false;

    }

    public void Selections(bool multipleLane, out int firstIndex, out int secondIndex)
    {
        if (!multipleLane)
        {
            firstIndex = Random.Range(0, 3);
            secondIndex = 0;
        }
        else
        {
            firstIndex = Random.Range(0, 3);
            secondIndex = Random.Range(0, 3);

            while (secondIndex == firstIndex)
            {
                secondIndex = Random.Range(0, 3);
            }

        }

    }

    public void CreateCollectable(int material, int i)
    {
        newObject = Instantiate(fuelTankPrefab, spanwPoints[i].position,Quaternion.identity);
        mR = newObject.GetComponent<MeshRenderer>();
        mR.material = materials[material];

    }
    public void CreateCollectable(int material, int secondMaterial, int index, int secondIndex)
    {
        newObject = Instantiate(fuelTankPrefab, spanwPoints[index].position, Quaternion.identity);
        mR = newObject.GetComponent<MeshRenderer>();
        mR.material = materials[material];
        newObject = Instantiate(fuelTankPrefab, spanwPoints[secondIndex].position, Quaternion.identity);
        mR = newObject.GetComponent<MeshRenderer>();
        mR.material= materials[secondMaterial];
    }
    public void ReadyForSpawn()
    {
        isMultiple = LaneAmount();
        Selections(isMultiple, out palet, out secondPalet);
        Selections(isMultiple, out firstRoad, out secondRoad);

        if (!isMultiple)
            CreateCollectable(palet, firstRoad);

        else
            CreateCollectable(palet, secondPalet, firstRoad, secondRoad);

    }
}
