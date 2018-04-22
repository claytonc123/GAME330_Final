using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour {

    public float health;
    public float maxHealth;
    public GameObject healthBar;
    public GameObject gameOver;
    public bool gameOverActive;

    // Use this for initialization
    void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
        else if (health > 1)
        {
            health = maxHealth;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyR" || other.gameObject.tag == "EnemyG" || other.gameObject.tag == "EnemyB" || other.gameObject.tag == "EnemyY")
        {
            Destroy(other.gameObject);
            health -= .05f;
            Debug.Log("hit");
            healthBar.transform.localScale = new Vector3(health , healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
    }
    
}
