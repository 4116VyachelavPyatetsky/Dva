using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPuzzles : MonoBehaviour
{
    bool move;

    Vector2 mousePos;
    float StarPosX;
    float StarPosY;

    public GameObject form;

    bool finish = false;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = true;
            mousePos = Input.mousePosition;
            StarPosX = mousePos.x-transform.localPosition.x;
            StarPosY = mousePos.y-transform.localPosition.y;
        }
    }

    private void OnMouseUp()
    {
        move = false;

        if(Mathf.Abs(transform.localPosition.x - form.transform.localPosition.x)<=30f&&
            Mathf.Abs(transform.localPosition.y - form.transform.localPosition.y) <= 30f && !finish)
        {
            transform.position = new Vector2(form.transform.position.x, form.transform.position.y);
            finish = true;
            transform.parent.transform.parent.GetComponent<WinConditionPuzzle>().PlusCount();
        }
    }


    private void Update()
    {
        if (move && !finish) 
        { 
        mousePos = Input.mousePosition;

        transform.localPosition = new Vector2(mousePos.x-StarPosX, mousePos.y-StarPosY);
        }
    }
}

