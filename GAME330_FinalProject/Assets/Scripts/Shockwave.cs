using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyShockwave(.4f));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyR" || other.gameObject.tag == "EnemyG" || other.gameObject.tag == "EnemyB" || other.gameObject.tag == "EnemyY")
        {

            Destroy(other.gameObject);
        }
    }

    private IEnumerator DestroyShockwave(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
