using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneManagement : MonoBehaviour {

    int prevScene;
    [SerializeField] int points = 0;
    

    private void Awake()
    {
        
        int levelCount = FindObjectsOfType<SceneManagement>().Length;

        if (levelCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    public void AddPoints(int point)
    {

        points+=point;
        
    }

    public int GetPoints()
    {
        return points;
    }

    public void ResetPoints()
    {
        points = 0;
    }

    public void SetPrevScene(int myPrevScene)
    {
        prevScene = myPrevScene;
    }

    public int GetPrevScene()
    {

        return prevScene;
    }

    

}
