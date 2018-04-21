using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Renderer playerRenderer;
    public bool destroyAll;

    // Use this for initialization
    void Start () {
        playerRenderer = GetComponent<Renderer>();
        destroyAll = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire1"))
        {
            playerRenderer.material.color = Color.green;
        }
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
        else if (destroyAll)
        {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator DestoryAllLifespan(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        destroyAll = false;
    }
}
