using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void OnPvPClick()
    {
        Config.isMultiplayer = false;
        SceneManager.LoadScene(1);
    }

    public void OnAIClick()
    {
        Config.isMultiplayer = true;
        SceneManager.LoadScene(1);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
