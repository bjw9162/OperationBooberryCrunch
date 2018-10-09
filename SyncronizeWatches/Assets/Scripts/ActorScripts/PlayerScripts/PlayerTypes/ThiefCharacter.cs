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
        subClassType = "Test Thief";

        speed = 1;
        direction = Quaternion.identity;

        health = 1;
    }
}
