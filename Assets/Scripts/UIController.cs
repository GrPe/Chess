using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image whitePawnImage;
    [SerializeField] private Image blackPawnImage;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private Image blackEnd;
    [SerializeField] private Image whiteEnd;

    public void SetBlackVisible()
    {
        whitePawnImage.enabled = false;
        blackPawnImage.enabled = true;
    }

    public void SetWhiteVisible()
    {
        whitePawnImage.enabled = true;
        blackPawnImage.enabled = false;
    }

    public void EndGame(bool white)
    {
        blackEnd.enabled = !white;
        whiteEnd.enabled = white;
        endScreen.SetActive(true);
    }

    public void OnButtonBackClick()
    {
        SceneManager.LoadScene(0);
    }
}
