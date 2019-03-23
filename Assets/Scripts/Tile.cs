using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool EnableMove { get; set; } = false;

    [SerializeField] public int x;
    [SerializeField] public int y;
}
