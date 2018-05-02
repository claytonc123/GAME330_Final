using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    float t;

    public Text timer;
    public Text timerWatch;
    public float startTime;
    public GameObject levelComplete;

    // Use this for initialization
    void Start () {
        health = maxHealth;
        mesh = GetComponent<MeshRenderer>();
        t = startTime;
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

        t -= Time.deltaTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timer.text = minutes + ":" + seconds;
        timerWatch.text = minutes + ":" + seconds;

        if (t <= 0)
        {
            timer.text = "0:0";
            timerWatch.text = "0.0";
            levelComplete.SetActive(true);
            StartCoroutine(LoadNextLevel(3));
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyR" || other.gameObject.tag == "EnemyG" || other.gameObject.tag == "EnemyB" || other.gameObject.tag == "EnemyY")
        {
            audioSource.PlayOneShot(damage, 1.5f);
            Destroy(other.gameObject);
            GetComponent<Animator>().SetTrigger("TookDamage");
            Debug.Log("hit");
            ChangeHealth(-0.1f);
        }
    }

    public void ChangeHealth(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0.0f, 1.0f);

        healthBar.transform.localScale = new Vector3(health, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        healthBarWatch.transform.localScale = new Vector3(health, healthBarWatch.transform.localScale.y, healthBarWatch.transform.localScale.z);
    }
    /*
    private IEnumerator GameOver(float delay)
    {
        yield return new WaitForSeconds(delay);

        Time.timeScale = 0;
        gameOver.SetActive(true);
    }
    */

    private IEnumerator LoadNextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        sceneNum++;
        SceneManager.LoadScene(sceneNum);

    }
}
