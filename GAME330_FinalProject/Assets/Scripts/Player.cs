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
    public float startTime;

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

        //string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        //timer.text = minutes + ":" + seconds;
        timer.text = seconds;
        /*
                if(destroyAll)
                {
                    playerRenderer.material.color = Color.Lerp(Color.red, Color.green, Mathf.PingPong(Time.time, 1));
                }
                */
    }

    //I do not know why you need this?


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyR" && playerRenderer.material.color == Color.red)
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "EnemyG" && playerRenderer.material.color == Color.green)
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "EnemyB" && playerRenderer.material.color == Color.blue)
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "EnemyY" && playerRenderer.material.color == Color.yellow)
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "DestroyAll")
        {
            destroyAll = true;
            StartCoroutine(DestoryAllLifespan(10));
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "SuperSize")
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            StartCoroutine(SuperSizeLifespan(10));
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Health")
        {
            tower.GetComponent<Tower>().health += .2f;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Shockwave")
        {
            Destroy(other.gameObject);
            Instantiate(shockwave, transform.position, transform.rotation);
        }
        else if (destroyAll && other.gameObject.tag != "ShockwavePickup")
        {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator DestoryAllLifespan(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        destroyAll = false;
    }

    private IEnumerator SuperSizeLifespan(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        transform.localScale = originalScale;
    }

}
