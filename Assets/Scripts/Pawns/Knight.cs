using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Pawn
{
    public override bool[,] GetPossibleMoves(Pawn[,] pawns)
    {
        bool[,] possibleMoves = new bool[8, 8];

        //top-left
        int x = XPositionOnBoard - 2;
        int y = YPositionOnBoard - 1;
        if(x >= 0 && y >= 0)
        {
            if (pawns[x, y] == null) possibleMoves[x, y] = true;
            else if(pawns[x, y].isWhite != isWhite)
            {
                possibleMoves[x, y] = true;
            }
        }

        x = XPositionOnBoard - 1;
        y = YPositionOnBoard - 2;
        if (x >= 0 && y >= 0)
        {
            if (pawns[x, y] == null) possibleMoves[x, y] = true;
            else if (pawns[x, y].isWhite != isWhite)
            {
                possibleMoves[x, y] = true;
            }
        }

        //top-right
        x = XPositionOnBoard + 2;
        y = YPositionOnBoard - 1;
        if (x < 8 && y >= 0)
        {
            if (pawns[x, y] == null) possibleMoves[x, y] = true;
            else if (pawns[x, y].isWhite != isWhite)
            {
                possibleMoves[x, y] = true;
            }
        }

        x = XPositionOnBoard + 1;
        y = YPositionOnBoard - 2;
        if (x < 8 && y >= 0)
        {
            if (pawns[x, y] == null) possibleMoves[x, y] = true;
            else if (pawns[x, y].isWhite != isWhite)
            {
                possibleMoves[x, y] = true;
            }
        }

        //down-left
        x = XPositionOnBoard - 2;
        y = YPositionOnBoard + 1;
        if (x >= 0 && y < 8)
        {
            if (pawns[x, y] == null) possibleMoves[x, y] = true;
            else if (pawns[x, y].isWhite != isWhite)
            {
                possibleMoves[x, y] = true;
            }
        }

        x = XPositionOnBoard - 1;
        y = YPositionOnBoard + 2;
        if (x >= 0 && y < 8)
        {
            if (pawns[x, y] == null) possibleMoves[x, y] = true;
            else if (pawns[x, y].isWhite != isWhite)
            {
                possibleMoves[x, y] = true;
            }
        }

        //down-right
        x = XPositionOnBoard + 2;
        y = YPositionOnBoard + 1;
        if (x < 8 && y < 8)
        {
            if (pawns[x, y] == null) possibleMoves[x, y] = true;
            else if (pawns[x, y].isWhite != isWhite)
            {
                possibleMoves[x, y] = true;
            }
        }

        x = XPositionOnBoard + 1;
        y = YPositionOnBoard + 2;
        if (x < 8 && y < 8)
        {
            if (pawns[x, y] == null) possibleMoves[x, y] = true;
            else if (pawns[x, y].isWhite != isWhite)
            {
                possibleMoves[x, y] = true;
            }
        }

        return possibleMoves;
    }
}
