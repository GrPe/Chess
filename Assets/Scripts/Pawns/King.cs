using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Pawn
{
    public override bool[,] GetPossibleMoves(Pawn[,] pawns)
    {
        bool[,] possibleMoves = new bool[8, 8];

        int i = XPositionOnBoard - 1;
        int j = YPositionOnBoard - 1;

        for(; i <= XPositionOnBoard + 1; i++)
        {
            if (i > 7 || i < 0) continue;
            for(j = YPositionOnBoard - 1; j <= YPositionOnBoard + 1; j++)
            {
                if (j > 7 || j < 0) continue;
                if(pawns[i, j] == null)
                {
                    possibleMoves[i, j] = true;
                }
                else
                {
                    if (pawns[i, j].isWhite != isWhite)
                    {
                        possibleMoves[i, j] = true;
                    }
                }
            }
        }

        return possibleMoves;
    }
}
