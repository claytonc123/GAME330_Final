using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLifetime : MonoBehaviour {

    public float lifetime;

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyPickup(lifetime));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator DestroyPickup(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
