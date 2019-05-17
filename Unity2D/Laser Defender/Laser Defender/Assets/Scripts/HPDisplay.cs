using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPDisplay : MonoBehaviour {

    TextMeshProUGUI hpText;


    // Use this for initialization
    void Start () {

        hpText = GetComponent<TextMeshProUGUI>();

	}
	
	// Update is called once per frame
	void Update () {

        if (FindObjectOfType<Player>() == true)
        {
            hpText.text = FindObjectOfType<Player>().GetHP().ToString();
        }
        else
        {
            hpText.text = "0";
        }

	}
}
