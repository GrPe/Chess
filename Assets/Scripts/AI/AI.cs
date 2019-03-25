using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AI
{
    static int Minimax(Board board, int depth, bool isMax)
    {
        if (depth == 0) return Evaluate(board);

        int bestVal = isMax ? int.MinValue : int.MaxValue;

        var moves = GetAllPossibleMoves(board, isMax);

        foreach (Move move in moves)
        {
            //perform movement;
            Pawn temp = board.pawns[move.ToX, move.ToY];
            board.pawns[move.ToX, move.ToY] = board.pawns[move.FromX, move.FromY];
            board.pawns[move.FromX, move.FromY] = null;
            board.pawns[move.ToX, move.ToY].XPositionOnBoard = move.ToX;
            board.pawns[move.ToX, move.ToY].YPositionOnBoard = move.ToY;

            //minimax
            int moveVal = isMax ? Mathf.Max(bestVal, Minimax(board, depth - 1, !isMax)) : Mathf.Min(bestVal, Minimax(board, depth -1, !isMax));

            //undo movement
            board.pawns[move.FromX, move.FromY] = board.pawns[move.ToX, move.ToY];
            board.pawns[move.ToX, move.ToY] = temp;
            board.pawns[move.FromX, move.FromY].XPositionOnBoard = move.FromX;
            board.pawns[move.FromX, move.FromY].YPositionOnBoard = move.FromY;

            //check best move
            if (moveVal > bestVal)
            {
                bestVal = moveVal;
            }
        }

        return bestVal;
    }

    public static Move FindBestMove(Board board)
    {
        int bestVal = int.MinValue;
        Move bestMove = new Move();

        var moves = GetAllPossibleMoves(board, true);

        foreach (Move move in moves)
        {
            //perform movement;
            Pawn temp = board.pawns[move.ToX, move.ToY];
            board.pawns[move.ToX, move.ToY] = board.pawns[move.FromX, move.FromY];
            board.pawns[move.FromX, move.FromY] = null;
            board.pawns[move.ToX, move.ToY].XPositionOnBoard = move.ToX;
            board.pawns[move.ToX, move.ToY].YPositionOnBoard = move.ToY;

            //minimax
            int moveVal = Evaluate(board);//Minimax(board, 2, false);

            //undo movement
            board.pawns[move.FromX, move.FromY] = board.pawns[move.ToX, move.ToY];
            board.pawns[move.ToX, move.ToY] = temp;
            board.pawns[move.FromX, move.FromY].XPositionOnBoard = move.FromX;
            board.pawns[move.FromX, move.FromY].YPositionOnBoard = move.FromY;

            //check best move
            if (moveVal > bestVal)
            {
                bestMove = move;
                bestVal = moveVal;
            }
        }

        return bestMove;
    }



    public static int Evaluate(Board board)
    {
        int score = 0;

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if (board.pawns[i, j] != null)
                {
                    
                    if (board.pawns[i, j] is PawnP)
                    {
                        if (board.pawns[i, j].tag == "BlackPawn") score += 10;
                        else score -= 10;
                    }
                    else if (board.pawns[i, j] is Bishop ||
                             board.pawns[i, j] is Rook ||
                             board.pawns[i, j] is Knight)
                    {
                        if (board.pawns[i, j].tag == "BlackPawn") score += 30;
                        else score -= 30;
                    }
                    else if (board.pawns[i, j] is Queen)
                    {
                        if (board.pawns[i, j].tag == "BlackPawn") score += 100;
                        else score -= 100;
                    }
                    else if(board.pawns[i, j] is King)
                    {
                        Debug.Log("Find King");
                        if (board.pawns[i, j].tag == "BlackPawn") score += 4000;
                        else score -= 4000;
                    }
                }
                
            }
        }

        return score;
    }

    private static List<Move> GetAllPossibleMoves(Board board, bool isBlack)
    {
        string tag = isBlack ? "BlackPawn" : "PlayerPawn";
        List<Move> possibleMoves = new List<Move>();

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board.pawns[i, j] != null && board.pawns[i, j].tag == tag)
                {
                    bool[,] possibleMovement = board.pawns[i, j].GetPossibleMoves(board.pawns);

                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            if (possibleMovement[x, y])
                            {
                                possibleMoves.Add(new Move(i, j, x, y));
                            }
                        }
                    }
                }
            }
        }

        return possibleMoves;
    }
}
