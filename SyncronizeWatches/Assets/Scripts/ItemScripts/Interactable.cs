using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable :MonoBehaviour{

    // register, remove, interact
    public bool IsRegistered { get; set; }
    public bool CanInteract { get; set; }
    
    public string PromptText { get; set; }

    public int Id { get; set; }

    public virtual void Interact() {
        // do the thing
    }

    public virtual void UnRegister( PlayerCharacter playerCharacter)
    {
        IsRegistered = false;
        // remove self from Interaction list of player
        for (var x = 0; x < playerCharacter.interactables.Count; x++) {
            var curObj = playerCharacter.interactables[x];
            if (curObj.Id == this.Id)
                playerCharacter.interactables.Remove(curObj);
        }
        
    }

    public virtual void Register( PlayerCharacter playerCharacter) {
        IsRegistered = true;
        // add self from Interaction list of player
        var hasDup = false;
        for (var x = 0; x < playerCharacter.interactables.Count; x++)
        {
            var curObj = playerCharacter.interactables[x];
            if (curObj.Id == this.Id)
                hasDup = true;
        }
        if (hasDup == false) { // if there is no duplicate of that item somehow
            playerCharacter.interactables.Add(this);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // :D
        PlayerCharacter Test = collision.gameObject.GetComponent<PlayerCharacter>();
        if (Test != null)
            Register(Test);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        // :(
        PlayerCharacter Test = collision.gameObject.GetComponent<PlayerCharacter>();
        if (Test != null)
            UnRegister(Test);
    }
}
