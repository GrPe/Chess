using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Pawn
{
    public override bool[,] GetPossibleMoves(Pawn[,] pawns)
    {
        bool[,] possibleMoves = new bool[8, 8];

        //forward
        for(int i = XPositionOnBoard - 1; i >=0; i--)
        {
            if (pawns[i, YPositionOnBoard] == null) possibleMoves[i, YPositionOnBoard] = true;
            else
            {
                if (pawns[i, YPositionOnBoard].isWhite != isWhite) possibleMoves[i, YPositionOnBoard] = true;
                break;
            }
        }

        //backward
        for (int i = XPositionOnBoard + 1; i < 8; i++)
        {
            if (pawns[i, YPositionOnBoard] == null) possibleMoves[i, YPositionOnBoard] = true;
            else
            {
                if (pawns[i, YPositionOnBoard].isWhite != isWhite) possibleMoves[i, YPositionOnBoard] = true;
                break;
            }
        }

        //left
        for (int i = YPositionOnBoard - 1; i >= 0; i--)
        {
            if (pawns[XPositionOnBoard, i] == null) possibleMoves[XPositionOnBoard, i] = true;
            else
            {
                if (pawns[XPositionOnBoard, i].isWhite != isWhite) possibleMoves[XPositionOnBoard, i] = true;
                break;
            }
        }

        //right
        for (int i = YPositionOnBoard + 1; i < 8; i++)
        {
            if (pawns[XPositionOnBoard, i] == null) possibleMoves[XPositionOnBoard, i] = true;
            else
            {
                if (pawns[XPositionOnBoard, i].isWhite != isWhite) possibleMoves[XPositionOnBoard, i] = true;
                break;
            }
        }

        return possibleMoves;

    }
}
