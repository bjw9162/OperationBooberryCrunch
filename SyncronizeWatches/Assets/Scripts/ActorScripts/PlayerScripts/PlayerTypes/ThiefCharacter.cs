using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefCharacter : PlayerCharacter
{
    // Use this for initialization
    public override void Init()
    {
        base.Init();
        classType = "Thief";
        subClassType = "Guy with shifty eyes and an appreciation of shiny objects.";

        speed = 1;
        direction = Quaternion.identity;

        health = 1;
    }
}
