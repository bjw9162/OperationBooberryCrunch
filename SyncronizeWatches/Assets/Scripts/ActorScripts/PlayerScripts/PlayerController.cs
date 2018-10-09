using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public PlayerCharacter activeCharacter;
    public List<PlayerCharacter> characters;
    private int currentCharacterIndex = 0;
    public InputManager inputManager;

    public Text text;


	// Use this for initialization
	void Start () {
        if (activeCharacter == null && characters.Count > 0)
            activeCharacter = characters[currentCharacterIndex];
        activeCharacter.recording = true;
        inputManager.Init();
	}
	
	// Update is called once per frame
	void Update () {
        // ¯\_(ツ)_/¯
        UpdatePlayerUI();
        HandleInputs();
    }

    /// <summary>
    /// Select the next character in the characters list
    /// by incrementing the index of current character.
    /// Also toggle who is recording.
    /// </summary>
    public void NextCharacter( bool toggleRecording = true)
    {
        currentCharacterIndex++;
        if (currentCharacterIndex >= characters.Count) {
            currentCharacterIndex = 0;
        }

        if (toggleRecording)
        {
            // set the currently activeCharacter to stop recording
            activeCharacter.recording = false;

            // switch the activeCharacter and turn the new ones recoring on
            activeCharacter = characters[currentCharacterIndex];
            activeCharacter.recording = true;
        }
        else {
            activeCharacter = characters[currentCharacterIndex];
        }
    }

    /// <summary>
    /// Select the last person on the queue of active characters.
    /// We don't have a use case for this yet, but I made it just in case.
    /// Also toggle who is recording.
    /// </summary>
    public void PrevCharacter(bool toggleRecording = true) {
        // adjust the index
        currentCharacterIndex--;
        if (currentCharacterIndex < 0){
            currentCharacterIndex = characters.Count - 1;
        }

        if (toggleRecording)
        {
            // set the currently activeCharacter to stop recording
            activeCharacter.recording = false;

            // switch the activeCharacter and turn the new ones recoring on
            activeCharacter = characters[currentCharacterIndex];
            activeCharacter.recording = true;
        }
        else
        {
            activeCharacter = characters[currentCharacterIndex];
        }
    }

    /// <summary>
    /// Use to get the timelines of all characters in the controller.
    /// </summary>
    /// <returns>An Array of List\<TimelineEventBase\> objects. </TimeLineEventBase></returns>
    public List<TimelineEventBase>[] GetAllTimelines(bool includeActive = true) {


        List<List<TimelineEventBase>> allTimelines = new List<List<TimelineEventBase>>();
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i] == activeCharacter && includeActive == false) { continue; }
            allTimelines.Add(characters[i].timelineEvents);
        }
        return allTimelines.ToArray();
    }

    public void UpdatePlayerUI() {
        text.color = activeCharacter.color;
        text.text = activeCharacter.classType;
        if (activeCharacter.subClassType != "") text.text += ": " + activeCharacter.subClassType;
    }

    /// <summary>
    /// Use this function to sift through all the inputs in the PlayerControllers InputManager.
    /// </summary>
    protected void HandleInputs()
    {
        if (Input.mousePosition != null) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 perpendicular = transform.position - mousePos;
            activeCharacter.direction = Quaternion.LookRotation(Vector3.forward, perpendicular);
        }

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
