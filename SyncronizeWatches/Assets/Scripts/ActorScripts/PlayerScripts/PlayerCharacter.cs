using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Root class for all characters, Theif, Hacker, etc.
/// </summary>
public class PlayerCharacter : ActorBase {
    
    public List<Interactable> interactables;
    public float moneyAmount; // make sure you round the money amount up two places after decimal
    public bool recording;
    public Color color;

	// Use this for initialization
	public override void Init() {
        base.Init();
        moneyAmount = 0f;
        direction = Vector3.right;
        interactables = new List<Interactable>();

        // temporary
        spriteRenderer.color = color;
	}
	
	// Update is called once per frame
	void Update () {
        ProcessMovement();
    }

    public void Collect(Collectable collectable) {
        collectable.SetStateCollected();
        // collectable.moneyValue; // add value to the money pool 
    }


    /// <summary>
    /// Call the Interact function of the Players closest Interactible.
    /// </summary>
    public void Interact()
    {
        var count = interactables.Count;

        if (count <= 0) return;

        // set the variables to the first thing by default (since there is more than none)
        var selectedInteractable = interactables[0];
        var shortestDistance = Vector3.Distance(this.Position, selectedInteractable.gameObject.transform.position);
        if (count > 1)
        {
            // sort through which one is closest 
            for (var x = 0; x < count; x++) {
                // make a new distance for comparison.
                var tempDistance = Vector3.Distance(this.Position, interactables[x].gameObject.transform.position);
                if (tempDistance < shortestDistance) {
                    // it's closer so that is the closest right now
                    shortestDistance = tempDistance;
                    selectedInteractable = interactables[x];
                }
            }
        }

        // Do this regardless of how many are in the list
        // as long as it's not 0
        if (selectedInteractable.CanInteract == true)
        {
            selectedInteractable.Interact();
        }
        else {
            return;
        }

    }

    /// <summary>
    /// After Updating the Velocity seperately, apply the velocity to the position of this character, then reset the velocity value.
    /// You should calculate velocity elsewhere, based on the inputs.
    /// </summary>
    public void ProcessMovement() {
        // take the velocity and apply it to the position;

        Position += Velocity * Time.deltaTime; 
        Velocity = Vector3.zero;
        transform.position = Position;

        if (recording == true)
            timelineEvents.Add(new MovementTimelineEvent(this, this.Position)); // add the event to your personal list to be compiled later.
    }
}
