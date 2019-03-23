using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Pawn
{
    public override bool[,] GetPossibleMoves(Pawn[,] pawns)
    {
        bool[,] possibleMoves = new bool[8, 8];

        //left-up
        int i, j;
        for (i = XPositionOnBoard - 1, j = YPositionOnBoard - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (pawns[i, j] == null) possibleMoves[i, j] = true;
            else
            {
                if (pawns[i, j].isWhite != isWhite)
                {
                    possibleMoves[i, j] = true;
                    break;
                }
                else break;
            }
        }

        //right-up
        for (i = XPositionOnBoard + 1, j = YPositionOnBoard - 1; i < 8 && j >= 0; i++, j--)
        {
            if (pawns[i, j] == null) possibleMoves[i, j] = true;
            else
            {
                if (pawns[i, j].isWhite != isWhite)
                {
                    possibleMoves[i, j] = true;
                    break;
                }
                else break;
            }
        }

        //left-down
        for (i = XPositionOnBoard - 1, j = YPositionOnBoard + 1; i >= 0 && j < 8; i--, j++)
        {
            if (pawns[i, j] == null) possibleMoves[i, j] = true;
            else
            {
                if (pawns[i, j].isWhite != isWhite)
                {
                    possibleMoves[i, j] = true;
                    break;
                }
                else break;
            }
        }

        //right-down
        for (i = XPositionOnBoard + 1, j = YPositionOnBoard + 1; i < 8 && j < 8; i++, j++)
        {
            if (pawns[i, j] == null) possibleMoves[i, j] = true;
            else
            {
                if (pawns[i, j].isWhite != isWhite)
                {
                    possibleMoves[i, j] = true;
                    break;
                }
                else break;
            }
        }

        return possibleMoves;
    }
}