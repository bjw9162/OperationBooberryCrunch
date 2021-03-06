﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTimelineEvent : TimelineEventBase {

    /// <summary>
    /// The Player character who is moving.
    /// </summary>
    PlayerCharacter pc;
    /// <summary>
    /// The place they moved from, a Vector3.
    /// </summary>
    Vector3 origin;
    /// <summary>
    /// The place they moved to, a Vector3.
    /// </summary>
    Vector3 destination;
    /// <summary>
    /// What direction they were looking
    /// </summary>
    Quaternion rotation;


    /// <summary>
    /// Create a MovementTimelineEvent to be put onto the global timeline
    /// </summary>
    /// <param name="playerCharacter">The Player who is moving</param>
    /// <param name="_origin"> The place the player moved from</param>
    /// <param name="_destination"> The place the player moved to</param>
    /// <param name="_rotation"> A Quat that represents the rotation of the character</param>
    public MovementTimelineEvent(PlayerCharacter playerCharacter, Vector3 _destination, Quaternion _rotation) {
        pc = playerCharacter;
        destination = _destination;
        rotation = _rotation;
        timestamp = Timeline.timeElapsed;
        eventDescripton = string.Format("Player {0} moved to {1} at {2}", playerCharacter.pieceName, playerCharacter.Position, timestamp);
    }

    /// <summary>
    /// Warp the PlayerCharacter assosciated with TimelineEvent to the destination.
    /// This happens almost every frame, so it's fine to warp them instead of walk them.
    /// </summary>
    public override void Resolve() {
        // Move the character from A to B
        pc.Position = destination;
        pc.transform.rotation = rotation;
        //Debug.Log(eventDescripton);
    }
}
