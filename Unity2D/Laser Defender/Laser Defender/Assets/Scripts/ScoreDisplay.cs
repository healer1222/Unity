using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour {

    TextMeshProUGUI pointsText;


    // Use this for initialization
    void Start () {

        pointsText= GetComponent<TextMeshProUGUI>();


    }
	
	// Update is called once per frame
	void Update () {

        pointsText.text = FindObjectOfType<SceneManagement>().GetPoints().ToString();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            pointsText.enabled = false;
        }

    }
}
