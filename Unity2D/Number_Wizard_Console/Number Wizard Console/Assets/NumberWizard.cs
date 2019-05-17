using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {
    private int max;
    private int min;
    private int guess;
    // Use this for initialization
    void Start () {

        

        StartGame();
        
      
		
	}

    void StartGame()
    {
        max = 1000;
        min = 1;
        guess = (max + min) / 2;

        Debug.Log("Welcome to Number Wizard");
        Debug.Log("Pick a number");
        Debug.Log("Highest number is: " + max);
        Debug.Log("Lowest number is: " + min);
        Debug.Log("Tell me if your is higher or lower than " + guess);
        Debug.Log("Push Up = higher, Push Down = lower, Push Enter = Correct");

        max = max + 1;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("min: "+min);
            min = guess;
            NextGuess();

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("max: "+max);
            max = guess;
            NextGuess();



        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Correct: "+guess);
            StartGame();
            

        }      

    }

    void NextGuess()
    {

        guess = (max + min) / 2;
        Debug.Log("Tell me if your is higher or lower than " + guess);

    }

}
