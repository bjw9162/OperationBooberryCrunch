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
        subClassType = "Guy with a Hoodie";

        speed = 1;
        direction = Vector3.right;

        health = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }


}
