using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject Player; //Created a public gameObject object variable
    private Vector3 offset; //Created a vector3 variable to hold the distance between the camera and the player gameobject

    void Start()
    {
        offset = gameObject.transform.position - Player.transform.position; //Set the cameraDistance variable equal to the distance between the player and the camera
    }

    void Update()
    {
        gameObject.transform.position = Player.transform.position + offset; //Sets the cameras position equal to the players position plus the offset
    }
}
