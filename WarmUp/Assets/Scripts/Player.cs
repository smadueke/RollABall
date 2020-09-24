//using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed; //Created a public variable that will determine speed (will allow me to adjust the players speed privately and publicly)
    private Vector3 movement; //Created a Vector3 variable (will allow me to store and change the 3d position of my gameObject)
    private Rigidbody rb; //Created a rigidbody variable (will allow me to add physics to the gameobject)    
    private Vector3 playerOrigin;

    private int score; //Create a int variable to hold the player's score
    public TMP_Text ScoreText; //Create a text object variable to hold the Score text
    public TMP_Text WinnerText; //Created a text objcet variable to hold the Winner text

    private PlayerController controls; //Created a variable that will hold the InputActionsAsset object "PlayerController". This will give me access to the InputActionsAsset object I created

    void Awake() //Function is called when the script instance is being loaded (for active gameobjects this is when the scene is loading)
    {
        rb = GetComponent<Rigidbody>(); //Retrieved the rigidbody component attached to the gameobject
        controls = new PlayerController(); //Set the variable equal to a new instance of the InputActionsAsset object "PlayerController"
        score = 0; //Set the initial value of score to 0
        ScoreText.text = "Score: 0"; //Set the initial text for ScoreText
    }

    private void OnEnable()
    {
        controls.Enable(); //Activates the entire "controls" InputAction
    }

    private void OnDisable()
    {
        controls.Disable(); //Deactivates the entire "controls" InputAction
    }


    void FixedUpdate() 
    {
        Vector2 move = controls.Controls.Movement.ReadValue<Vector2>(); //Created a Vector2 variable that stores the Vector2 values that come once the movement action is performed
        movement = new Vector3(move.x, 0.0f, move.y); //Set the "move" Vector2 x and y values as the "movement" Vector3 x and z values

        if (movement != Vector3.zero) //Checks whether or not the movement Vector3 variable is zero or not (essentially checks whether or not any input has been recorded)
        {
            rb.AddForce(movement * speed); //Adds a force to the rigidbody determined by the forces applied in the x, y, and z worlds axis. These forces are further amplified by the speed variable
        }
    }

    private void Update()
    {
        if (controls.Controls.ResetButton.triggered) //Checks to see whether the ResetButton action, within the Controls ActionMap of the controls ActionMapAsset, has been triggered
        {
            SceneManager.LoadScene("SampleScene"); //Loads the specified scene
        }

        if (score == 10) //Checks to see whether the score is equal to 10
        {
            WinnerText.text = "Congratulations! You Win! Chucky, you programmed this game on your own! I knew you could do it! Great Job! Now onto the Vultiverse!"; //Assigns text to the text within the WinnerText object
        }
    }

    private void OnTriggerEnter(Collider other) //Runs once the gameObject has collided with another gameObject collider with a trigger enabled 
    {
        other.gameObject.SetActive(false); //Deactivates the gameObject that was run into
        ScoreText.text = ($"Score: {score+=1}"); //Updates the ScoreText text with the current score
    }
}
