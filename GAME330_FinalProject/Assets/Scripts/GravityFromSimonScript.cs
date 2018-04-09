using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFromSimonScript : MonoBehaviour {

    public float GravityMagnitude = 9.81f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Physics.gravity = SimonXInterface.GetDownVector() * GravityMagnitude;
	}
}
