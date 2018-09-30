using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float timerDuration;

    public Timeline timeline;
    public PlayerController playerController;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
        // if it exceeds the duration
        if (Timeline.timeElapsed >= timerDuration)
        {
            // stop the fucking presses.
            Timeline.timeElapsed = 0f;

            // select the next person
            playerController.NextCharacter();

            // CompileTimeline with a list of timelineevent lists
            timeline.CompileTimeline( playerController.GetAllTimelines(false) );
        }

        timeline.RunTimeline();
    }
	
}
