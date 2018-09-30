using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineEventBase {

    public double timestamp;
    public string eventDescripton;

    // Might need the actors involved?
    // Needs the action duplication/result

    /// <summary>
    /// The function that gets called to replicate the event
    /// </summary>
    public virtual void Resolve()
    {

    }

}
