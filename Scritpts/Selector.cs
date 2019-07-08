using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    bool clicked = false;

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
        }
        else
        {
            clicked = false;
        }
    }

    public bool GetClicked()
    {
        return clicked;
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}
