using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public PlayerCharacter activeCharacter;
    public List<PlayerCharacter> characters;
    public InputManager inputManager;

	// Use this for initialization
	void Start () {
        if (activeCharacter == null && characters.Count > 0)
            activeCharacter = characters[0];
        inputManager.Init();
	}
	
	// Update is called once per frame
	void Update () {
        // ¯\_(ツ)_/¯

        HandleInputs();
        activeCharacter.ProcessMovement();
    }


    /// <summary>
    /// Use this function to sift through all the inputs in the PlayerControllers InputManager.
    /// </summary>
    protected void HandleInputs()
    {
        // if the input manager has been set elsewheres
        if (inputManager != null) {

            //make a temp variable
            var playerDirection = Vector3.zero;

            if (inputManager.buttons["Up"].down) {
                // move up 
                playerDirection += Vector3.up;
            }
            if (inputManager.buttons["Left"].down)
            {
                // move left 
                playerDirection += Vector3.left;
            }
            if (inputManager.buttons["Right"].down)
            {
                // move right
                playerDirection += Vector3.right;
            }
            if (inputManager.buttons["Down"].down)
            {
                // double down
                // move down
                playerDirection += Vector3.down;
            }

            // Store the characters velocity
            activeCharacter.Velocity = playerDirection.normalized * activeCharacter.speed;

            if (inputManager.buttons["Interact"].press) {
                // Interact 
                activeCharacter.Interact();
            }
        }
    }

}
