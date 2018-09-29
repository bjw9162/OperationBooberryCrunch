using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The Class that is shared for Enemies, Characters, and other NPC's
/// </summary>
public class ActorBase : GamePiece {

    public string classType;
    public string subClassType;

    public float speed;
    public Vector3 direction;

    public int health = 1;

    public List<Collectable> inventory;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Call this when health runs to nothing.
    /// Either getting arrested or dying or something.
    /// </summary>
    public virtual void Defeat() {
        // like fade away, maybe be destroyed. 
        // trigger other events.
    }
}
