using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour {

    public GameObject particles;
    public GameObject player;
    public Player playerScript;
	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyShockwave(.4f));
        playerScript = player.GetComponent<Player>();
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
        }
        playerScript.Kills(1);
    }

    private IEnumerator DestroyShockwave(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
