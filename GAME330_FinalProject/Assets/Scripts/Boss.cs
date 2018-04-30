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

        InvokeRepeating("ChangeColor", 1f, 4f);
	}

    void ChangeColor()
    {
        float id = Random.Range(0f, 4f);
        gameObject.GetComponent<Renderer>().material.color = colors[Mathf.RoundToInt(id)];
        //gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
}
