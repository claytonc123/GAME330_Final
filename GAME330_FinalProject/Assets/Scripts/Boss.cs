using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public float health;
    int id;
    Color[] colors;
    public Color enemyColor;

	// Use this for initialization
	void Start () {
        health = 1f;
        InvokeRepeating("ChangeColor", 1f, 4f);
        colors = new Color[4];
        colors[0] = Color.red;
        colors[1] = Color.green;
        colors[2] = Color.blue;
        colors[3] = Color.yellow;
    }
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}

    void ChangeColor()
    {
        int id = Random.Range(0, 4);
        gameObject.GetComponent<Renderer>().material.color = colors[id];
        //gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    public void ChangeHealth(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0.0f, 1.0f);
    }
}
