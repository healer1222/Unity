using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NumberWizard : MonoBehaviour {

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    int guess;

    // Use this for initialization
    void Start() {



        StartGame();



    }

    void StartGame()
    {

        //  guess = (max + min) / 2;
        //  guessText.text = guess.ToString();

        NextGuess();
        
        

    }

    public void OnPressHigher()
    {

        min = guess+1;
        NextGuess();
        

    }

    public void OnpressLower()
    {

        max = guess-1;
        NextGuess();
       

    }


    // Update is called once per frame
    

    void NextGuess()
    {

        //guess = (max + min) / 2;
        guess = Random.Range(min, max+1);

        guessText.text = guess.ToString();


    }

    

    

}
