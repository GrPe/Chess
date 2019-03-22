using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

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

    public float xOffset = 2f;
    public float yOffset = 2f;

    public Pawn[,] pawns;


    public void Start()
    {
        pawns = new Pawn[8, 8];

        //black - first line
        pawns[0, 0] = Instantiate(BlackRook, transform.position + new Vector3(0 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[0, 1] = Instantiate(BlackKnight, transform.position + new Vector3(1 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[0, 2] = Instantiate(BlackBishop, transform.position + new Vector3(2 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[0, 3] = Instantiate(BlackQueen, transform.position + new Vector3(3 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[0, 4] = Instantiate(BlackKing, transform.position + new Vector3(4 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[0, 5] = Instantiate(BlackBishop, transform.position + new Vector3(5 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[0, 6] = Instantiate(BlackKnight, transform.position + new Vector3(6 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[0, 7] = Instantiate(BlackRook, transform.position + new Vector3(7 * xOffset, 0, 0 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();


        //black - second line
        for (int i = 0; i < 8; i++)
        {
            pawns[1, i] = Instantiate(BlackPawn, transform.position + new Vector3(i * xOffset, 0, 1 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        }

        //white - second line
        for (int i = 0; i < 8; i++)
        {
            pawns[6, i] = Instantiate(WhitePawn, transform.position + new Vector3(i * xOffset, 0, 6 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        }

        //white - first line
        pawns[7, 0] = Instantiate(WhiteRook, transform.position + new Vector3(0 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[7, 1] = Instantiate(WhiteKnight, transform.position + new Vector3(1 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[7, 2] = Instantiate(WhiteBishop, transform.position + new Vector3(2 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[7, 3] = Instantiate(WhiteQueen, transform.position + new Vector3(3 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[7, 4] = Instantiate(WhiteKing, transform.position + new Vector3(4 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[7, 5] = Instantiate(WhiteBishop, transform.position + new Vector3(5 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[7, 6] = Instantiate(WhiteKnight, transform.position + new Vector3(6 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();
        pawns[7, 7] = Instantiate(WhiteRook, transform.position + new Vector3(7 * xOffset, 0, 7 * yOffset), Quaternion.identity, transform).GetComponent<Pawn>();


    }


}
