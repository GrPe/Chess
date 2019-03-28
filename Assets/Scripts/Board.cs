using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject WhiteTile;
    [SerializeField] private GameObject BlackTile;

    #region Pawns
    [SerializeField] private GameObject WhiteKing;
    [SerializeField] private GameObject WhiteRook;
    [SerializeField] private GameObject WhiteBishop;
    [SerializeField] private GameObject WhiteQueen;
    [SerializeField] private GameObject WhiteKnight;
    [SerializeField] private GameObject WhitePawn;

    [SerializeField] private GameObject BlackKing;
    [SerializeField] private GameObject BlackRook;
    [SerializeField] private GameObject BlackBishop;
    [SerializeField] private GameObject BlackQueen;
    [SerializeField] private GameObject BlackKnight;
    [SerializeField] private GameObject BlackPawn;
    #endregion

    public float xOffset = -2f;
    public float yOffset = -2f;

    public Pawn[,] pawns;

    public GameObject[,] tiles;


    public void Start()
    {
        SpawnTiles();
        SpawnPawns();
    }

    public void InstantiateQueen(Vector3 position, bool isWhite, int x, int y)
    {
        if (isWhite)
        {
            pawns[x, y] = Instantiate(WhiteQueen, position, Quaternion.identity).GetComponent<Queen>();
            pawns[x, y].XPositionOnBoard = x;
            pawns[x, y].YPositionOnBoard = y;
        }
        else
        {
            pawns[x, y] = Instantiate(BlackQueen, position, Quaternion.identity).GetComponent<Queen>();
            pawns[x, y].XPositionOnBoard = x;
            pawns[x, y].YPositionOnBoard = y;
        }
    }

    private void SpawnTiles()
    {
        bool whiteToSpawn = true;
        tiles = new GameObject[8, 8];

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if(whiteToSpawn)
                {
                    tiles[j, i] = Instantiate(WhiteTile, transform.position + new Vector3(j * xOffset, 0, i * yOffset), Quaternion.identity, transform.parent);
                    tiles[j, i].GetComponent<Tile>().x = i;
                    tiles[j, i].GetComponent<Tile>().y = j;
                    whiteToSpawn = false;
                }
                else
                {
                    tiles[j, i] = Instantiate(BlackTile, transform.position + new Vector3(j * xOffset, 0, i * yOffset), Quaternion.identity, transform.parent);
                    tiles[j, i].GetComponent<Tile>().x = i;
                    tiles[j, i].GetComponent<Tile>().y = j;
                    whiteToSpawn = true;
                }
            }
            whiteToSpawn = !whiteToSpawn;
        }
    }
     
    private void SpawnPawns()
    {
        pawns = new Pawn[8, 8];

        FillWithNull(pawns);

        //black - first line
        pawns[0, 0] = Instantiate(BlackRook, transform.position + new Vector3(0 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Rook>();
        pawns[0, 1] = Instantiate(BlackKnight, transform.position + new Vector3(1 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Knight>();
        pawns[0, 2] = Instantiate(BlackBishop, transform.position + new Vector3(2 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Bishop>();
        pawns[0, 3] = Instantiate(BlackQueen, transform.position + new Vector3(3 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Queen>();
        pawns[0, 4] = Instantiate(BlackKing, transform.position + new Vector3(4 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<King>();
        pawns[0, 5] = Instantiate(BlackBishop, transform.position + new Vector3(5 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Bishop>();
        pawns[0, 6] = Instantiate(BlackKnight, transform.position + new Vector3(6 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Knight>();
        pawns[0, 7] = Instantiate(BlackRook, transform.position + new Vector3(7 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Rook>();

        for (int i = 0; i < 8; i++) { pawns[0, i].XPositionOnBoard = 0; pawns[0, i].YPositionOnBoard = i; }


        //black - second line
        for (int i = 0; i < 8; i++)
        {
            pawns[1, i] = Instantiate(BlackPawn, transform.position + new Vector3(i * xOffset, 0, 1 * yOffset), Quaternion.identity, transform).GetComponent<PawnP>();
            pawns[1, i].XPositionOnBoard = 1; pawns[1, i].YPositionOnBoard = i;
        }

        //white - second line
        for (int i = 0; i < 8; i++)
        {
            pawns[6, i] = Instantiate(WhitePawn, transform.position + new Vector3(i * xOffset, 0, 6 * yOffset), Quaternion.identity, transform).GetComponent<PawnP>();
            pawns[6, i].XPositionOnBoard = 6; pawns[6, i].YPositionOnBoard = i;
        }

        //white - first line
        pawns[7, 0] = Instantiate(WhiteRook, transform.position + new Vector3(0 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Rook>();
        pawns[7, 1] = Instantiate(WhiteKnight, transform.position + new Vector3(1 * xOffset, 0, 7 * yOffset), Quaternion.Euler(0, 180, 0), transform).GetComponent<Knight>();
        pawns[7, 2] = Instantiate(WhiteBishop, transform.position + new Vector3(2 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Bishop>();
        pawns[7, 3] = Instantiate(WhiteQueen, transform.position + new Vector3(3 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Queen>();
        pawns[7, 4] = Instantiate(WhiteKing, transform.position + new Vector3(4 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<King>();
        pawns[7, 5] = Instantiate(WhiteBishop, transform.position + new Vector3(5 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Bishop>();
        pawns[7, 6] = Instantiate(WhiteKnight, transform.position + new Vector3(6 * xOffset, 0, 7 * yOffset), Quaternion.Euler(0, 180, 0), transform).GetComponent<Knight>();
        pawns[7, 7] = Instantiate(WhiteRook, transform.position + new Vector3(7 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Rook>();
        for (int i = 0; i < 8; i++) { pawns[7, i].XPositionOnBoard = 7; pawns[7, i].YPositionOnBoard = i; }

    }

    private void FillWithNull(Pawn[,] pawns)
    {
        for(int i = 0; i < pawns.GetLength(0); i++)
        {
            for(int j = 0; j < pawns.GetLength(1); j++)
            {
                pawns[i, j] = null;
            }
        }
    }
}
