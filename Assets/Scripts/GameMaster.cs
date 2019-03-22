using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //Board board = new Board();
    private Movement selectedPawn = null;

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
                    if (selectedPawn != null)
                    {
                        selectedPawn.OnDiselect();
                    }
                    selectedPawn = hit.transform.gameObject.GetComponent<Movement>();
                    selectedPawn.OnSelect();
                }
                else if(hit.transform.tag == "FreeTile" && selectedPawn != null)
                {
                    selectedPawn.Move(hit.transform.position);
                    selectedPawn.OnDiselect();
                    selectedPawn = null;
                }
                else
                {
                    selectedPawn = null;
                }
            }
        }
    }
}
