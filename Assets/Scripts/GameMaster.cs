using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private Board board;
    private Pawn selectedPawn = null;

    private void Update()
    {
        SelectPawn();
    }

    private void SelectPawn()
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
                        board.pawns[tile.x, tile.y] = selectedPawn;
                        board.pawns[selectedPawn.XPositionOnBoard, selectedPawn.YPositionOnBoard] = null;
                        board.pawns[tile.x, tile.y].SetPosition(tile.transform.position);
                        board.pawns[tile.x, tile.y].XPositionOnBoard = tile.x;
                        board.pawns[tile.x, tile.y].YPositionOnBoard = tile.y;
                        selectedPawn = null;
                        RemovePossibleMovement();
                    }
                }
                else if(hit.transform.tag == "BlackPawn" && selectedPawn != null)
                {
                    var hitted = hit.transform.GetComponent<Pawn>();
                    var tile = board.tiles[hitted.XPositionOnBoard, hitted.YPositionOnBoard].GetComponent<Tile>();
                    if (tile.EnableMove == true)
                    {
                        board.pawns[tile.x, tile.y] = selectedPawn;
                        board.pawns[selectedPawn.XPositionOnBoard, selectedPawn.YPositionOnBoard] = null;
                        board.pawns[tile.x, tile.y].SetPosition(tile.transform.position);
                        board.pawns[tile.x, tile.y].XPositionOnBoard = tile.x;
                        board.pawns[tile.x, tile.y].YPositionOnBoard = tile.y;
                        selectedPawn = null;
                        RemovePossibleMovement();
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
                    board.tiles[i, j].GetComponent<MeshRenderer>().material.color = Color.green;
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
                board.tiles[i, j].GetComponent<MeshRenderer>().material.color = Color.white;
                board.tiles[i, j].GetComponent<Tile>().EnableMove = false;
            }
        }
    }
}
