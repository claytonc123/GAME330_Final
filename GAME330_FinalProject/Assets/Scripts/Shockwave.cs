using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip destroy;

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
            audioSource.PlayOneShot(destroy);
        }
    }

    private IEnumerator DestroyShockwave(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
