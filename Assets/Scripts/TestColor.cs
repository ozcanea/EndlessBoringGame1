using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// player->RTI_yellow->Body
/// </summary>
public class TestColor : MonoBehaviour
{
    private float initialColorChangeTime = 15f;
    public float colorChangeTime = 15f;
    public float selectTime;
    public Material[] materials;
    private Material currentMaterial;
    [HideInInspector]public Material nextMaterial;
    bool isSelected = false;
    bool isChanged = true;

    private void Awake()
    {
        currentMaterial = GetComponent<MeshRenderer>().materials[0];
    }

    private void Update()
    {
        if (!GameManager.Instance.gameOver)
        {
            SelectNextColor();
            if (isSelected)
                ChangeColor();
        }
    }

    void SelectNextColor()
    {
        if (selectTime <= 0 && isChanged)
        {
            selectTime = colorChangeTime;
            nextMaterial = materials[Random.Range(0, materials.Length)];
            isSelected = true;
            isChanged = false;
        }
        else
        {
            selectTime = GameManager.Instance.timeManager.DecreaseUpToDeltaTime(selectTime);
        }
    }
    void ChangeColor()
    {
        if (colorChangeTime <= 0)
        {
            colorChangeTime = initialColorChangeTime;
            GetComponent<MeshRenderer>().materials[0].color = nextMaterial.color;
            isSelected = false;
            isChanged = true;
        }
        else
            colorChangeTime = GameManager.Instance.timeManager.DecreaseUpToDeltaTime(colorChangeTime);
    }
}