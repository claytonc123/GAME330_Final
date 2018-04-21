using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] Enemies;
    public float spawnTime = 1f;            // How long between each spawn.
	public float spawnDelay = 1f;
    public Vector3 enposition;

    void Start ()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating ("Spawn", spawnDelay, spawnTime);
    }


    void Spawn ()
    {
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.

        Instantiate (Enemies[Random.Range(0,4)], transform.position, transform.rotation);
    }
}