using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construct : GamePiece {

    public override void Init()
    {
        base.Init();

        stationary = true;
        canRotate = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
