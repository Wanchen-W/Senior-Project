using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    
    private GameObject respawn;
    //private bool activated = false;
	
	void Start () {

        respawn = GameObject.FindGameObjectWithTag("Respawn");

	}

    private void OnTriggerEnter2D(Collider2D collision) {

        //if (!activated) {
            
        if (collision.CompareTag("Player")) {

            respawn.transform.position = transform.position;

        }

        //}

    }

}
