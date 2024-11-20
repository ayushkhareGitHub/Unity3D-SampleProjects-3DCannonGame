using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGAme : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("3DCannonGame");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
