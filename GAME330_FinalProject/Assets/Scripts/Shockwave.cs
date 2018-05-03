using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour {

    public GameObject particles;
    public GameObject player;
	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyShockwave(.4f));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyR" || other.gameObject.tag == "EnemyG" || other.gameObject.tag == "EnemyB" || other.gameObject.tag == "EnemyY" || other.gameObject.tag == "Boss")
        {
            Instantiate(particles, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
            player.GetComponent<Player>().Kills(1);
        }
    }

    private IEnumerator DestroyShockwave(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
