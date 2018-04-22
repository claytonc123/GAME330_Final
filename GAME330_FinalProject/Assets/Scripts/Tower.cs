using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public float health;
    public GameObject healthBar;

	// Use this for initialization
	void Start () {
        health = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            Destroy(other.gameObject);
            health -= .05f;
            Debug.Log("hit");
            healthBar.transform.localScale = new Vector3(health , healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
    }
    
}
