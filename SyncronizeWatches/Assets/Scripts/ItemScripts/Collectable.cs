using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Construct {

    public Interactable interactable; // for picking up and other stuff

    public bool keyItem;
    public float moneyValue;

    // Use this for initialization
    public override void Init()
    {
        base.Init();
        pieceName = "collectible";
        keyItem = false;
        moneyValue = 0f;
        this.State = "uncollected";
    }

    public virtual void SetStateCollected() {
        this.State = "collected";
        // probably make this thing invisible, deactivate it's colliders and such
        // probably add the value if it's in an inventory now
    }

    public virtual void SetStateDestroyed() {
        this.State = "destroyed";
        // make it invisible, trigger events
    }

    public virtual void SetStateUncollected() {
        this.State = "uncollected";
        // make it visible, trigger other events 
    }

    public virtual void SetStateDropped() {
        SetStateUncollected(); // right now we have not implemented drop
    }

    // Update is called once per frame
    void Update () {
		
	}
}
