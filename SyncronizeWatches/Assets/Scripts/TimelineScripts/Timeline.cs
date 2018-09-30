using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour {

    protected List<TimelineEventBase> timelineEvents;
    public static double timeElapsed;

	// Use this for initialization
	void Start () {
        Timeline.timeElapsed = 0.0;
	}
	
	// Update is called once per frame
	void Update () {
        Timeline.timeElapsed += Time.deltaTime;
	}

    /// <summary>
    /// Take in several Lists of Events
    /// Then add them all together, chronologically.
    /// </summary>
    public void CompileTimeLine() {
        
    }
}
