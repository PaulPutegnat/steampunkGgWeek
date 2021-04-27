using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameManager gameManager;

    public void LoadGameScene() {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextDay()
    {
        gameManager.NextDay();
        this.gameObject.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Exit!");
    }
}
