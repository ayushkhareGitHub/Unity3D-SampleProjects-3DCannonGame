using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public Text gameText;
    public GameObject orbContainer;
    
    public string nextSceneName;
    public float endScreenDelay = 3f;

    private OrbController[] orbs;

    private int orbsToDestroy;

    private float gameTimer;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        orbs = orbContainer.GetComponentsInChildren<OrbController>();
        orbsToDestroy = orbs.Length;

        foreach(OrbController orb in orbs)
        {
            orb.onOrbDestroyed = () =>
            {
                OnOrbDestroyed();
            };
        }
    }

    void OnOrbDestroyed()
    {
        orbsToDestroy--;

        if(orbsToDestroy == 0)
        {
            isGameOver = true;
            EndGame(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (!isGameOver)
        {
            gameText.text = "Shoot the orbs!";
            gameText.text+="\nTime: " + Mathf.Floor(gameTimer);
            gameTimer += Time.deltaTime;

            if (gameTimer > 10f)
            {
                isGameOver = true;
                EndGame(false);
            }
        }
    }

    void EndGame(bool didWin)
    {
        if (didWin)
        {
            gameText.text = "You won!";
            gameText.text += "\nYour time: " + Mathf.Floor(gameTimer);
            gameText.text += "\nPress R to Play Again!";

            StartCoroutine(LoadNextSceneAfterDelay());
        }
        else
        {
            gameText.text = "You lost!";
            gameText.text += "\nTime's up!";
            gameText.text += "\nPress R to Reload!";
        }
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(endScreenDelay);
        SceneManager.LoadScene("End");
    }
}
