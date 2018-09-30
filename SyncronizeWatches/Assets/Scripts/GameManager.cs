using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float timerDuration;
    public float passedTime;
    public bool stillCounting;

    public Timeline timeline;
    public PlayerController playerController;

	// Use this for initialization
	void Start () {
        // // // // // // //
        // This is Temporary 
        // // // // // // // 
        // Start a timer for X seconds   
        passedTime = 0f;
        stillCounting = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (stillCounting == true)
        {
            passedTime += Time.deltaTime;

            if (passedTime >= timerDuration)
            {
                // stop the fucking presses.
                stillCounting = false;
                passedTime = 0f;
                // CompileTimeline with a list of timelineevent lists
                timeline.CompileTimeline( playerController.activeCharacter.timelineEvents );
                playerController.activeCharacter.recording = false;
            }
        }
        else {
            passedTime += Time.deltaTime;

            timeline.RunTimeline(passedTime);
            // while list of events time stamp is less than current count
            // do the things
        }

	}
}
