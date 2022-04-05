using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColor : MonoBehaviour
{
    private float initialColorChangeTime=15f;
    float colorChangeTime = 15f;
    private float colorDelayDecrease=0.05f;
    private float selectTime;
    public Material[] materials;
    private Material currentMaterial;
    private Material nextMaterial;
    bool isSelected=false;
    private void Awake()
    {
        currentMaterial=GetComponent<MeshRenderer>().materials[0];   
    }
    private void Start()
    {
        
        //StartCoroutine(ChangeColor2());
    }
    private void Update()
    {
        if(!GameManager.Instance.gameOver)
        {
            SelectNextColor();
            if(isSelected)
                ChangeColor();
        }
    }
    IEnumerator ChangeColor2()
    {
        while (!GameManager.Instance.gameOver)
        {

            yield return new WaitUntil(() => Time.time >= colorChangeTime);
            nextMaterial= materials[Random.Range(0, materials.Length)];
            Debug.Log("next color "+nextMaterial.name);
            colorChangeTime += 10f - colorDelayDecrease;
            GetComponent<MeshRenderer>().materials[0].color = nextMaterial.color;
           

            Debug.Log(currentMaterial.name);
            
        }


    }

    void SelectNextColor()
    {
        if (selectTime <= 0)
        {
            selectTime = colorChangeTime;
            nextMaterial = materials[Random.Range(0, materials.Length)];
            while (nextMaterial == currentMaterial)
            {
                nextMaterial = materials[Random.Range(0, materials.Length)];
            }
            Debug.Log("next color " + nextMaterial.name);
            isSelected = true;
        }
        else
            selectTime -= Time.deltaTime;
       
    }
    void ChangeColor()
    {
        if(colorChangeTime<=0)
        {
            initialColorChangeTime -= colorDelayDecrease;
            colorChangeTime = initialColorChangeTime;
            GetComponent<MeshRenderer>().materials[0].color = nextMaterial.color;
            isSelected = false;
        }
        else
            colorChangeTime-= Time.deltaTime;
    }
}
