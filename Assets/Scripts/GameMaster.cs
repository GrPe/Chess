﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private UIController uiController;

    [SerializeField] private Material standardTileMaterial;
    [SerializeField] private Material emissiveTileMaterial;

    [SerializeField] private Board board;
    private Pawn selectedPawn = null;

    private bool white = true;
    private bool enemyThinking = false;

    private void Update()
    {
        if (white)
        {
            PlayerWhiteSelect();
        }
        else if(Config.isMultiplayer)
        {
            if (!enemyThinking)
            {
                enemyThinking = true;
                Move move = AI.FindBestMove(board);
                AIMove(move);
                uiController.SetWhiteVisible();
            }
        }
        else
        {
            BlackPlayerSelect();
        }
    }

    private void PromotePawns()
    {
        for(int i = 0; i < 8; ++i)
        {
            for(int j = 0; j < 8; j++)
            {
                if (board.pawns[i, j] != null &&  board.pawns[i, j] is PawnP)
                {
                    if (board.pawns[i, j].tag == "PlayerPawn" && i == 0)
                    {
                        Vector3 position = board.pawns[i, j].transform.position;
                        Destroy(board.pawns[i, j].gameObject);
                        board.InstantiateQueen(position, true, i, j);
                    }
                    else if (board.pawns[i, j].tag == "BlackPawn" && i == 7)
                    {
                        Vector3 position = board.pawns[i, j].transform.position;
                        Destroy(board.pawns[i, j].gameObject);
                        board.InstantiateQueen(position, false, i, j);
                    }
                }
            }
        }
    }

    private void EndOfMove()
    {
        PromotePawns();
        selectedPawn = null;
        RemovePossibleMovement();
        white = !white;
        uiController.SetBlackVisible();
        WinnerCheck();
    }

    private void WinnerCheck()
    {
        int result = AI.Evaluate(board);
        if(result > 3000)
        {
            uiController.EndGame(false); //black win
        }
        else if (result < -3000)
        {
            uiController.EndGame(true); //white win
        }
    }

    private void AIMove(Move move)
    {
        //destroy
        if(board.pawns[move.ToX, move.ToY] != null)
        {
            Destroy(board.pawns[move.ToX, move.ToY].gameObject);
        }

        //move
        board.pawns[move.ToX, move.ToY] = board.pawns[move.FromX, move.FromY];
        board.pawns[move.FromX, move.FromY] = null;
        board.pawns[move.ToX, move.ToY].XPositionOnBoard = move.ToX;
        board.pawns[move.ToX, move.ToY].YPositionOnBoard = move.ToY;
        board.pawns[move.ToX, move.ToY].SetPosition(board.tiles[move.ToY, move.ToX].transform.position);

        EndOfMove();
        enemyThinking = false;
    }

    private void PlayerWhiteSelect()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if(hit.transform.tag == "PlayerPawn")
                {
                    if (selectedPawn != null) RemovePossibleMovement();
                    selectedPawn = hit.transform.GetComponent<Pawn>();
                    DrawPossibleMovement();
                }
                else if(hit.transform.tag == "FreeTile" && selectedPawn != null)
                {
                    var tile = hit.transform.GetComponent<Tile>();
                    if(tile.EnableMove == true)
                    {
                        //destroy enemy pawn
                        if(board.pawns[tile.x, tile.y] != null)
                        {
                            Destroy(board.pawns[tile.x, tile.y].gameObject);
                        }

                        //move pawn
                        board.pawns[tile.x, tile.y] = selectedPawn;
                        board.pawns[selectedPawn.XPositionOnBoard, selectedPawn.YPositionOnBoard] = null;
                        board.pawns[tile.x, tile.y].SetPosition(tile.transform.position);
                        board.pawns[tile.x, tile.y].XPositionOnBoard = tile.x;
                        board.pawns[tile.x, tile.y].YPositionOnBoard = tile.y;
                        EndOfMove();
                    }
                }
                else if(hit.transform.tag == "BlackPawn" && selectedPawn != null)
                {
                    Pawn hitted = hit.transform.GetComponent<Pawn>();
                    Tile tile = board.tiles[hitted.YPositionOnBoard, hitted.XPositionOnBoard].GetComponent<Tile>();
                    if (tile.EnableMove == true)
                    {
                        //destroy enemy pawn
                        if (board.pawns[tile.x, tile.y] != null)
                        {
                            Destroy(board.pawns[tile.x, tile.y].gameObject);
                        }

                        board.pawns[tile.x, tile.y] = selectedPawn;
                        board.pawns[selectedPawn.XPositionOnBoard, selectedPawn.YPositionOnBoard] = null;
                        board.pawns[tile.x, tile.y].SetPosition(tile.transform.position);
                        board.pawns[tile.x, tile.y].XPositionOnBoard = tile.x;
                        board.pawns[tile.x, tile.y].YPositionOnBoard = tile.y;
                        EndOfMove();
                    }
                }
                else
                {
                    selectedPawn = null;
                    RemovePossibleMovement();
                }
            }
        }
    }

    private void BlackPlayerSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.tag == "BlackPawn")
                {
                    if (selectedPawn != null) RemovePossibleMovement();
                    selectedPawn = hit.transform.GetComponent<Pawn>();
                    DrawPossibleMovement();
                }
                else if (hit.transform.tag == "FreeTile" && selectedPawn != null)
                {
                    var tile = hit.transform.GetComponent<Tile>();
                    if (tile.EnableMove == true)
                    {
                        //destroy enemy pawn
                        if (board.pawns[tile.x, tile.y] != null)
                        {
                            Destroy(board.pawns[tile.x, tile.y].gameObject);
                        }

                        board.pawns[tile.x, tile.y] = selectedPawn;
                        board.pawns[selectedPawn.XPositionOnBoard, selectedPawn.YPositionOnBoard] = null;
                        board.pawns[tile.x, tile.y].SetPosition(tile.transform.position);
                        board.pawns[tile.x, tile.y].XPositionOnBoard = tile.x;
                        board.pawns[tile.x, tile.y].YPositionOnBoard = tile.y;
                        EndOfMove();
                    }
                }
                else if (hit.transform.tag == "PlayerPawn" && selectedPawn != null)
                {
                    Pawn hitted = hit.transform.GetComponent<Pawn>();
                    Tile tile = board.tiles[hitted.YPositionOnBoard, hitted.XPositionOnBoard].GetComponent<Tile>();
                    if (tile.EnableMove == true)
                    {
                        //destroy enemy pawn
                        if (board.pawns[tile.x, tile.y] != null)
                        {
                            Destroy(board.pawns[tile.x, tile.y].gameObject);
                        }

                        board.pawns[tile.x, tile.y] = selectedPawn;
                        board.pawns[selectedPawn.XPositionOnBoard, selectedPawn.YPositionOnBoard] = null;
                        board.pawns[tile.x, tile.y].SetPosition(tile.transform.position);
                        board.pawns[tile.x, tile.y].XPositionOnBoard = tile.x;
                        board.pawns[tile.x, tile.y].YPositionOnBoard = tile.y;
                        EndOfMove();
                    }
                }
                else
                {
                    selectedPawn = null;
                    RemovePossibleMovement();
                }
            }
        }
    }

    private void DrawPossibleMovement()
    {
        bool[,] possibleMoves = selectedPawn.GetPossibleMoves(board.pawns);

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if(possibleMoves[j,i])
                {
                    board.tiles[i, j].GetComponent<MeshRenderer>().material = emissiveTileMaterial;
                    board.tiles[i, j].GetComponent<Tile>().EnableMove = true;
                }
            }
        }

    }

    private void RemovePossibleMovement()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board.tiles[i, j].GetComponent<MeshRenderer>().material = standardTileMaterial;
                board.tiles[i, j].GetComponent<Tile>().EnableMove = false;
            }
        }
    }
}
    