using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Renderer playerRenderer;
    public bool destroyAll;
    public Vector3 originalScale;
    public GameObject tower;
    public GameObject shockwave;
    public Text timer;
    public Text timerWatch;
    public float startTime;
    public Animator towerAnim;
    public AudioSource audioSource;
    public AudioClip destroy;
    public AudioClip heal;
    public AudioClip shock;
    public AudioClip grow;
    public AudioClip power;
    public GameObject levelComplete;
    public int kills;
    public Text killsText;

    // Use this for initialization
    void Start () {
        playerRenderer = GetComponent<Renderer>();
        destroyAll = false;
        originalScale = transform.localScale;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire1"))
        {
            playerRenderer.material.color = Color.green;        }
        else if (Input.GetButton("Fire2"))
        {
            playerRenderer.material.color = Color.red;
        }
        else if (Input.GetButton("Fire3"))
        {
            playerRenderer.material.color = Color.blue;
        }
        else if (Input.GetButton("Jump"))
        {
            playerRenderer.material.color = Color.yellow;
        }

        float t = startTime - Time.time;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timer.text = minutes + ":" + seconds;
        timerWatch.text = minutes + ":" + seconds;

        if (t <= 0)
        {
            timer.text = "0:0";
            levelComplete.SetActive(true);
        }

        killsText.text = kills.ToString();
    }

    //I do not know why you need this?


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyR" && playerRenderer.material.color == Color.red)
        {
            DestroyEnemy(other.gameObject);
        }
        else if (other.gameObject.tag == "EnemyG" && playerRenderer.material.color == Color.green)
        {            
            DestroyEnemy(other.gameObject);
        }
        else if (other.gameObject.tag == "EnemyB" && playerRenderer.material.color == Color.blue)
        {
            DestroyEnemy(other.gameObject);

        }
        else if (other.gameObject.tag == "EnemyY" && playerRenderer.material.color == Color.yellow)
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
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            StartCoroutine(SuperSizeLifespan(10));
            Destroy(other.gameObject);
            audioSource.PlayOneShot(grow, 1f);
        }
        else if (other.gameObject.tag == "Health")
        {
            tower.GetComponent<Tower>().health += .2f;
            towerAnim.SetTrigger("Healed");
            Destroy(other.gameObject);
            audioSource.PlayOneShot(heal, 1f);
        }
        else if (other.gameObject.tag == "Shockwave")
        {
            Destroy(other.gameObject);
            Instantiate(shockwave, transform.position, transform.rotation);
            audioSource.PlayOneShot(shock, 1f);
        }
        else if (destroyAll && other.gameObject.tag != "ShockwavePickup")
        {
            DestroyEnemy(other.gameObject);
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
        transform.localScale = originalScale;
    }


    void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
        audioSource.PlayOneShot(destroy, 0.7f);
        kills++;
    }
}
