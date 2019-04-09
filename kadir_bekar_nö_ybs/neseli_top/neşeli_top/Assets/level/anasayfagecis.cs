using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anasayfagecis : MonoBehaviour
{

    public void Playgame()
    {
        SceneManager.LoadScene("menu");
    }
    public void Quitgame()
    {
        Application.Quit();
    }
}