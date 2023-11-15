using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour {

    public Transform Player;

    public float minX, maxX, minY, maxY;

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

        if (location.x < minX)
        {
            location.x = minX;
        }
        if (location.x > maxX)
        {
            location.x = maxX;
        }
        if (location.y < minY)
        {
            location.y = minY;
        }
        if (location.y > maxY)
        {
            location.y = maxY;
        }

        transform.position = location;
       
    }
    
}