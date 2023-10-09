using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour {

    public Transform Player;

    private Camera cam;

    void Start() {

        if (Player == null) {

            Player = GameObject.FindGameObjectWithTag("Player").transform;

        }

        cam = GetComponent<Camera>();

    }

    void Update() {

        Vector3 location = Player.transform.position;
        location.z = location.z - 10;

        transform.position = location;
       
    }
    
}