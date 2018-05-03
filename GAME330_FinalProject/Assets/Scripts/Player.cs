using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public GameObject levelComplete;
    public GameObject tower;
    public GameObject shockwave;
    public GameObject cam;

    public Renderer playerRenderer;

    public Animator towerAnim;
    public Animator playerAnim;

    public AnimationClip growAnim;

    public AudioSource audioSource;
    public AudioClip destroy;
    public AudioClip heal;
    public AudioClip shock;
    public AudioClip grow;
    public AudioClip power;

    public Text timer;
    public Text timerWatch;
    public Text killsText;

    public Vector3 originalScale;
    public bool destroyAll;
    public float startTime;
    public int kills;

    //Color gameObject.GetComponent<Renderer>().material.color;

    // Use this for initialization
    void Start () {
        playerRenderer = GetComponent<Renderer>();
        destroyAll = false;
        originalScale = transform.localScale;
        Time.timeScale = 1;
        //startTime = 30;
        //gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire1"))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;        }
        else if (Input.GetButton("Fire2"))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (Input.GetButton("Fire3"))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (Input.GetButton("Jump"))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }

        /*float t = startTime - Time.time;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timer.text = minutes + ":" + seconds;
        timerWatch.text = minutes + ":" + seconds;

        if (t <= 0)
        {
            timer.text = "0:0";
            timerWatch.text = "0.0";
            levelComplete.SetActive(true);
            StartCoroutine(LoadNextLevel(3));
        }*/

        killsText.text = kills.ToString();
    }

    //I do not know why you need this?


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyR" && gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            DestroyEnemy(other.gameObject);
        }
        else if (other.gameObject.tag == "EnemyG" && gameObject.GetComponent<Renderer>().material.color == Color.green)
        {            
            DestroyEnemy(other.gameObject);
        }
        else if (other.gameObject.tag == "EnemyB" && gameObject.GetComponent<Renderer>().material.color == Color.blue)
        {
            DestroyEnemy(other.gameObject);

        }
        else if (other.gameObject.tag == "EnemyY" && gameObject.GetComponent<Renderer>().material.color == Color.yellow)
        {
            DestroyEnemy(other.gameObject);
        }
        else if (other.gameObject.tag == "DestroyAll")
        {
            destroyAll = true;
            StartCoroutine(DestoryAllLifespan(10));
            Destroy(other.gameObject);
            audioSource.PlayOneShot(power, 0.7f);
        }
        else if (other.gameObject.tag == "SuperSize")
        {
            //transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            playerAnim.SetTrigger("Grow");
            StartCoroutine(SuperSizeLifespan(10));
            Destroy(other.gameObject);
            audioSource.PlayOneShot(grow, 1f);
        }
        else if (other.gameObject.tag == "Health")
        {
            tower.GetComponent<Tower>().ChangeHealth(0.2f);
            towerAnim.SetTrigger("Healed");
            Destroy(other.gameObject);
            audioSource.PlayOneShot(heal, 1f);
        }
        else if (other.gameObject.tag == "Shockwave")
        {
            Destroy(other.gameObject);
            cam.GetComponent<CamShake>().Shake(.3f, .2f);
            Instantiate(shockwave, transform.position, transform.rotation);
            audioSource.PlayOneShot(shock, 1f);
        }
        else if (destroyAll && other.gameObject.tag != "ShockwavePickup")
        {
            DestroyEnemy(other.gameObject);
        }
        else if(other.gameObject.tag == "Boss")
        {
            if (other.gameObject.GetComponent<Renderer>().material.color == gameObject.GetComponent<Renderer>().material.color)
            {
                other.gameObject.GetComponent<Boss>().ChangeHealth(-.35f);
                audioSource.PlayOneShot(destroy, 0.7f);
                cam.GetComponent<CamShake>().Shake(.1f, .2f);
                Vector3 vectorToTarget = other.gameObject.transform.position - transform.position;
                gameObject.GetComponent<Rigidbody>().AddForce(-vectorToTarget * 10, ForceMode.Impulse);
            }
        }
    }

    private IEnumerator DestoryAllLifespan(float lifespan)
    {
        GetComponent<Animator>().SetTrigger("Colors");
        yield return new WaitForSeconds(lifespan);
        GetComponent<Animator>().SetTrigger("Idle");
        destroyAll = false;
    }

    private IEnumerator SuperSizeLifespan(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        playerAnim.SetTrigger("Shrink");
        //transform.localScale = originalScale;
    }

    private IEnumerator LoadNextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        sceneNum++;
        SceneManager.LoadScene(sceneNum);

    }

    void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
        //cam.GetComponent<CamShake>().Shake(.05f, .1f);
        audioSource.PlayOneShot(destroy, 0.7f);
        kills++;
    }

    public void Kills(int kill)
    {
        kills += kill;
    }
}
