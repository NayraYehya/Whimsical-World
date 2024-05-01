using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject Win;
    public void WinFunc()
    {
        Win.SetActive(true);
        Debug.Log("win");
    }
    public void GameOverFunc()
    {
        gameOver.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("Start Menu");
        Debug.Log("menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync("Level 2");
        Debug.Log("next");
    }
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
