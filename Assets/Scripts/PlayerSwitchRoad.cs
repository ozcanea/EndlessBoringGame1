using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

/// <summary>
/// Player
/// </summary>

public class PlayerSwitchRoad : MonoBehaviour
{
    [SerializeField] float duration = 0.5f;
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] Transform middle;
    int desiredPos = 1;//0=left, 1=middle, 2=right
    void Update()
    {
        if (Input.touchCount > 0&&!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).position.x < Screen.width / 2 && !GameManager.Instance.gameOver)
            {
                DedectLane(false);
                StartCoroutine(RotateAndMoveCar(desiredPos, -20f, 0.4f));
            }
            if (Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).position.x > Screen.width / 2 && !GameManager.Instance.gameOver)
            {
                DedectLane(true);
                StartCoroutine(RotateAndMoveCar(desiredPos, 20f, 0.4f));
            }
        }
    }
    void MoveWithTouch(int lane)//for moving a position
    {
        switch (lane)
        {
            case 0:
                transform.DOMoveX(left.position.x, duration);

                break;
            case 1:
                transform.DOMoveX(middle.position.x, duration);

                break;
            case 2:
                transform.DOMoveX(right.position.x, duration);

                break;
        }
    }

    void DedectLane(bool isRight)//for which direction player want to go
    {
        desiredPos += (isRight) ? 1 : -1;
        desiredPos = Mathf.Clamp(desiredPos, 0, 2);
    }

    IEnumerator RotateAndMoveCar(int lane, float degreeY, float rotateDuration)//Move Car More Realistic
    {
        transform.DORotate(new Vector3(0f, degreeY, 0f), rotateDuration);
        MoveWithTouch(lane);
        yield return new WaitForSeconds(rotateDuration / 1.7f);
        transform.DORotate(new Vector3(0f, 0f, 0f), rotateDuration);
    }
}