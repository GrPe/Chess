using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Move(Vector3 position)
    {
        Debug.Log("Moved: " + gameObject.name);
        transform.position = position;
    }
}
