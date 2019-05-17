using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level : MonoBehaviour {


    
    [SerializeField] float delayInSeconds = 2f;
    
    int prevScene;


    public void SetPrevScene(int prevScene)
    {

        this.prevScene = prevScene;
    }

    public void LoadStartMenu()
    {

        SceneManager.LoadScene(0);

    }

    public void LoadNextScene()
    {

        int currentScene= SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);

    }

    public void LoadGameOver()
    {     
        
        StartCoroutine(WaitAndLoad());

    }

    IEnumerator WaitAndLoad()
    {

        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOverScene");

        
    }

    public void RestartScene()
    {
        prevScene = FindObjectOfType<SceneManagement>().GetPrevScene();
        Debug.Log("buildindex: "+prevScene);
        FindObjectOfType<SceneManagement>().ResetPoints();
        SceneManager.LoadScene(prevScene);

    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
