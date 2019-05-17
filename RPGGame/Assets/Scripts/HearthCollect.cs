using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthCollect : MonoBehaviour {

    public int rotateSpeed;
    public AudioSource collectSound;
    public GameObject thisHearth;

	// Update is called once per frame
	void Update () {
       
        transform.Rotate(0,rotateSpeed,0,Space.World);

	}

    private void OnTriggerEnter(Collider other){

        collectSound.Play();
        thisHearth.SetActive(false);

    }
}
