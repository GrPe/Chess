using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void OnSelect()
    {
        Debug.Log("Selected: " + gameObject.name);
    }

    public void OnDiselect()
    {
        Debug.Log("Diselected: " + gameObject.name);
    }

    public void Move(Vector3 position)
    {
        Debug.Log("Moved: " + gameObject.name);
        transform.position = position;
    }
}
