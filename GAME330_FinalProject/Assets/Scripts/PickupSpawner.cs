using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour {

    public Vector3 center;
    public Vector3 size;
    public GameObject[] Pickups;
    public float spawnTime = 1f;            // How long between each spawn.
    public float spawnDelay = 1f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(Pickups[Random.Range(0, 4)], pos, Quaternion.identity);
        spawnTime = Random.Range(10f, 15f);
    }
}
