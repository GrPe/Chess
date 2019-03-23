using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnP : Pawn
{
    public override bool[,] GetPossibleMoves(Pawn[,] pawns)
    {
        if (isWhite)
        {
            bool[,] possibleMoves = new bool[8, 8];

            //forward
            if (XPositionOnBoard - 1 >= 0)
            {
                if (pawns[XPositionOnBoard - 1, YPositionOnBoard] == null)
                {
                    possibleMoves[XPositionOnBoard - 1, YPositionOnBoard] = true;

                    //first forward
                    if (XPositionOnBoard - 2 >= 0 && firstMove)
                    {
                        if (pawns[XPositionOnBoard - 2, YPositionOnBoard] == null)
                        {
                            possibleMoves[XPositionOnBoard - 2, YPositionOnBoard] = true;
                        }
                    }
                }
            }

            //attack left
            if (XPositionOnBoard - 1 >= 0 && YPositionOnBoard - 1 >= 0)
            {
                if (pawns[XPositionOnBoard - 1, YPositionOnBoard - 1] != null)
                {
                    possibleMoves[XPositionOnBoard - 1, YPositionOnBoard - 1] = true;
                }
            }

            //attack right
            if (XPositionOnBoard - 1 >= 0 && YPositionOnBoard + 1 < 8)
            {
                if (pawns[XPositionOnBoard - 1, YPositionOnBoard + 1] != null)
                {
                    possibleMoves[XPositionOnBoard - 1, YPositionOnBoard + 1] = true;
                }
            }
            return possibleMoves;
        }
        else
        {
            bool[,] possibleMoves = new bool[8, 8];

            //forward
            if (XPositionOnBoard + 1 < 8)
            {
                if (pawns[XPositionOnBoard + 1, YPositionOnBoard] == null)
                {
                    possibleMoves[XPositionOnBoard + 1, YPositionOnBoard] = true;

                    //first forward
                    if (XPositionOnBoard + 2 < 8 && firstMove)
                    {
                        if (pawns[XPositionOnBoard + 2, YPositionOnBoard] == null)
                        {
                            possibleMoves[XPositionOnBoard + 2, YPositionOnBoard] = true;
                        }
                    }
                }
            }

            //attack left
            if (XPositionOnBoard + 1 >= 0 && YPositionOnBoard - 1 >= 0)
            {
                if (pawns[XPositionOnBoard + 1, YPositionOnBoard - 1] != null)
                {
                    possibleMoves[XPositionOnBoard + 1, YPositionOnBoard - 1] = true;
                }
            }

            //attack right
            if (XPositionOnBoard + 1 >= 0 && YPositionOnBoard + 1 < 8)
            {
                if (pawns[XPositionOnBoard + 1, YPositionOnBoard + 1] != null)
                {
                    possibleMoves[XPositionOnBoard + 1, YPositionOnBoard + 1] = true;
                }
            }
            return possibleMoves;
        }
    }

}
