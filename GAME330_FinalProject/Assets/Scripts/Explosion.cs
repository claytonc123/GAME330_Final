using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip explosion;
    public GameObject tower;

	// Use this for initialization
	void Start () {
        audioSource.PlayOneShot(explosion);
        Destroy(tower);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
