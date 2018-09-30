using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public Level activeLevel;

	// Use this for initialization
	void Start () {
        activeLevel.Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
