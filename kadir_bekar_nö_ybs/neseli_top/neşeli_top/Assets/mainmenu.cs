using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{

    public void Playgame()
    {
        SceneManager.LoadScene(1);
    }

    public void Playgame2()
    {
        SceneManager.LoadScene(2);
    }
    public void Playgame3()
    {
        SceneManager.LoadScene(3);
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}