using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tower : MonoBehaviour {

    public GameObject healthBar;
    public GameObject healthBarWatch;
    public GameObject gameOver;
    public GameObject explosion;
    public GameObject levelComplete;
    public GameObject particles;

    public AudioSource audioSource;

    public AudioClip explode;
    public AudioClip damage;
    public AudioClip crumble;

    public Text timer;
    public Text timerWatch;

    public MeshRenderer mesh;

    public float health;
    public float maxHealth;
    public float t;
    public float startTime;

    public bool gameOverActive;

    List<object> listOfEnemies;

    // Use this for initialization
    void Start () {
        health = maxHealth;
        mesh = GetComponent<MeshRenderer>();
        t = startTime;
    }
	
	// Update is called once per frame
	void Update () {

        t -= Time.deltaTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timer.text = minutes + ":" + seconds;
        timerWatch.text = minutes + ":" + seconds;

        if (health <= 0)
        {
            audioSource.PlayOneShot(explode);
            audioSource.PlayOneShot(crumble);
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

        if (t <= 0)
        {
            timer.text = "0:00";
            timerWatch.text = "0.00";
            levelComplete.SetActive(true);
            StartCoroutine(LoadNextLevel(3));

            FlockerScript[] enemies = FindObjectsOfType<FlockerScript>();
            foreach (FlockerScript enemy in enemies)
            {
                Instantiate(particles, enemy.transform.position, enemy.transform.rotation);
                Destroy(enemy.gameObject);
            }

            Time.timeScale = .5f;
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

        if(other.gameObject.tag == "Boss")
        {
            audioSource.PlayOneShot(damage, 1.5f);
            audioSource.PlayOneShot(crumble, 1.5f);
            Destroy(other.gameObject);
            GetComponent<Animator>().SetTrigger("TookDamage");
            Debug.Log("hit");
            ChangeHealth(-0.3f);
        }      
    }

    public void ChangeHealth(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0.0f, 1.0f);

        healthBar.transform.localScale = new Vector3(health, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        healthBarWatch.transform.localScale = new Vector3(health, healthBarWatch.transform.localScale.y, healthBarWatch.transform.localScale.z);

        if(amount < 0)
        {
            gameObject.GetComponent<CamShake>().Shake(.1f, .1f);
        }
    }

    private IEnumerator LoadNextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            int sceneNum = SceneManager.GetActiveScene().buildIndex;
            sceneNum++;
            SceneManager.LoadScene(sceneNum);
        }
    }
}
