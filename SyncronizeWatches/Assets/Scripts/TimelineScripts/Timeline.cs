using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour {

    protected List<TimelineEventBase> timelineEvents = new List<TimelineEventBase>();
    public static double timeElapsed;
    protected List<TimeLineRunner> timeLineRunners = new List<TimeLineRunner>();

	// Use this for initialization
	void Start () {
        Timeline.timeElapsed = 0.0;
	}
	
	// Update is called once per frame
	void Update () {
        Timeline.timeElapsed += Time.deltaTime;
	}

    /// <summary>
    /// Using all the Lists of TimelineEventBase, create timeLineRunners that can play them back.
    /// </summary>
    /// <param name="timelines"> Any number of TimelineEventBase Lists, seperated by a comma.</param>
    public void CompileTimeline(params List<TimelineEventBase>[] timelines) {
        foreach (List<TimelineEventBase> current_timeline in timelines) {
            timeLineRunners.Add(new TimeLineRunner(current_timeline));
        }
    }

    /// <summary>
    /// Run this after you use CompileTimeline.
    /// This function goes through each TimelineRunner, and uses it 
    /// to resolve all of the events that should have happened already in the timeline.
    /// </summary>
    /// <param name="elapsedTime">A float representing elapsed time. Using an outside timer.</param>
    public void RunTimeline(float elapsedTime) {
        foreach (TimeLineRunner runner in timeLineRunners) { // for each runner
            while (runner.playbackIndex < runner.timelineEvents.Count &&
                runner.timelineEvents[runner.playbackIndex].timestamp < elapsedTime ) { 
                // while your event is still in the past
                // resolve that event.
                runner.timelineEvents[runner.playbackIndex].Resolve();

                // add one to the playbackIndex;
                runner.playbackIndex++;
                // make sure you don't accidentally overflow using the while loop
                if (runner.playbackIndex >= runner.timelineEvents.Count)
                {
                    break;
                }
            }
        }
    }

    public class TimeLineRunner {
        public List<TimelineEventBase> timelineEvents;
        public int playbackIndex;

        public TimeLineRunner(List<TimelineEventBase> timelineEvents)
        {
            this.timelineEvents = timelineEvents;
            this.playbackIndex = 0;
        }
    }

}
