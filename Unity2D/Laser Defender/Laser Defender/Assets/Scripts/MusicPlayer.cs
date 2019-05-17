using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {


        SetUpSingleton();


    }

    private void SetUpSingleton()
    {
        int musicPlayer = FindObjectsOfType<MusicPlayer>().Length; // musicplayer helyett lehet getType és akkor az aktuális típust szedi le

        if (musicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
