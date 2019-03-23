using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public bool isWhite;

    protected bool firstMove = true; //pawn only

    public int XPositionOnBoard;
    public int YPositionOnBoard;

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = new Vector3(position.x, transform.position.y, position.z);
        firstMove = false;
    }

    public abstract bool[,] GetPossibleMoves(Pawn[,] pawns);
}
