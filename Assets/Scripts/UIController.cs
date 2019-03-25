using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image whitePawnImage;
    [SerializeField] private Image blackPawnImage;

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

    public void OnButtonBackClick()
    {
        SceneManager.LoadScene(0);
    }
}
