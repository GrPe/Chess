using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Pawn
{
    public override bool[,] GetPossibleMoves(Pawn[,] pawns)
    {
        bool[,] possibleMoves = new bool[8, 8];

        int i = 0;
        int j = 0;

        #region Bishop
        //left-up
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
        #endregion

        #region Rook
        //forward
        for (i = XPositionOnBoard - 1; i >= 0; i--)
        {
            if (pawns[i, YPositionOnBoard] == null) possibleMoves[i, YPositionOnBoard] = true;
            else
            {
                if (pawns[i, YPositionOnBoard].isWhite != isWhite) possibleMoves[i, YPositionOnBoard] = true;
                break;
            }
        }

        //backward
        for (i = XPositionOnBoard + 1; i < 8; i++)
        {
            if (pawns[i, YPositionOnBoard] == null) possibleMoves[i, YPositionOnBoard] = true;
            else
            {
                if (pawns[i, YPositionOnBoard].isWhite != isWhite) possibleMoves[i, YPositionOnBoard] = true;
                break;
            }
        }

        //left
        for (i = YPositionOnBoard - 1; i >= 0; i--)
        {
            if (pawns[XPositionOnBoard, i] == null) possibleMoves[XPositionOnBoard, i] = true;
            else
            {
                if (pawns[XPositionOnBoard, i].isWhite != isWhite) possibleMoves[XPositionOnBoard, i] = true;
                break;
            }
        }

        //right
        for (i = YPositionOnBoard + 1; i < 8; i++)
        {
            if (pawns[XPositionOnBoard, i] == null) possibleMoves[XPositionOnBoard, i] = true;
            else
            {
                if (pawns[XPositionOnBoard, i].isWhite != isWhite) possibleMoves[XPositionOnBoard, i] = true;
                break;
            }
        }
        #endregion

        return possibleMoves;
    }
}
