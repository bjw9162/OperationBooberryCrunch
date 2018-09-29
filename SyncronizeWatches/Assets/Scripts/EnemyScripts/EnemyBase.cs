using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : GamePiece {

    public class NavWaypoint {
        // has a x and y
        public float x;
        public float y;

        public NavWaypoint(float _x, float _y) {
            x = _x;
            y = _y;
        }
    }

    public float visionDistance;
    public CircleCollider2D visionBubble;

    public string enemyType;
    public bool canSee; // use this to toggle whether or not you check the vision cone. Enables blinding or disabling of sight.
    public bool hasVision; // has the ability to see

    public Interactable interactable;

    public float speed;
    public List<NavWaypoint> patrolRoute; // A list of tile positions to patrol
    public List<NavWaypoint> dynamicPath; // A list of tile positions if they need to run to

    // Use this for initialization
    void Start () {
        hasVision = true;
        canRotate = true;
        stationary = false;

        this.CreatePatrolRoute();
        // create the patrolRoute, maybe in the Unity Inspector?
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// A function that determines how this type of enemy creates a Patrol route
    /// </summary>
    /// <returns>The Patrol Route as a List of NavWaypoints</returns>
    public virtual List<NavWaypoint> CreatePatrolRoute() {
        return new List<NavWaypoint>();
    }

    /// <summary>
    /// Draw a ray from GamePiece to other
    /// </summary>
    /// <param name="other">
    ///     The other game piece you are trying to see.
    /// </param>
    /// <returns>A Bool of whether other piece can be seen.</returns>
    public bool CanSeeObject(GamePiece other)
    {
        if (hasVision == false)
            return false;
        else
        {
            // in here you draw a ray, 
            // if you collide with the gamepiece, and not something else you hit
        }

        return false; // hit this if something doesn't compute right
    }

}
