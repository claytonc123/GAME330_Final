using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyBasic;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
	public float spawnDelay = 3f;
    public Vector3 enposition;
	public Transform Wall;


    void Start ()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating ("Spawn", spawnDelay, spawnTime);
    }


    void Spawn ()
    {
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate (EnemyBasic, Wall.position, Wall.rotation);
    }
}