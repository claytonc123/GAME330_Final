using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour {

    public float health;
    public float maxHealth;
    public GameObject healthBar;
    public GameObject healthBarWatch;
    public GameObject gameOver;
    public bool gameOverActive;
    public AudioSource audioSource;
    public AudioClip explode;
    public GameObject explosion;
    public AudioClip damage;
    public AudioClip crumble;
    MeshRenderer mesh;

    // Use this for initialization
    void Start () {
        health = maxHealth;
        mesh = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            audioSource.PlayOneShot(explode);
            audioSource.PlayOneShot(crumble);
            //StartCoroutine(GameOver(5));
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
            audioSource.PlayOneShot(damage, 1.5f);
            Destroy(other.gameObject);
            health -= .1f;
            GetComponent<Animator>().SetTrigger("TookDamage");
            Debug.Log("hit");
            healthBar.transform.localScale = new Vector3(health , healthBar.transform.localScale.y, healthBar.transform.localScale.z);
            healthBarWatch.transform.localScale = new Vector3(health, healthBarWatch.transform.localScale.y, healthBarWatch.transform.localScale.z);
        }
    }
    /*
    private IEnumerator GameOver(float delay)
    {
        yield return new WaitForSeconds(delay);

        Time.timeScale = 0;
        gameOver.SetActive(true);
    }
    */
}
