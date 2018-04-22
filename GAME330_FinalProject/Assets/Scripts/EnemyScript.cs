using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public enum FlockingMode
    {
        ChaseTarget,
        FleeTarget,
        MaintainDistance,
        DoNothing
    }

    public float SpeedPerSecond = 4.0f;
    public GameObject Tower;
    public FlockingMode CurrentFlockingMode = FlockingMode.ChaseTarget;
    public float DesiredDistanceFromTarget_Min = 3.5f;
    public float DesiredDistanceFromTarget_Max = 4.5f;

    // Use this for initialization
    void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 desiredDirection = new Vector3();

        Vector3 vectorToTarget = Tower.transform.position - transform.position;
        float distanceToTarget = vectorToTarget.magnitude;
        
        switch (CurrentFlockingMode)
        {
            case FlockingMode.ChaseTarget:
                desiredDirection = vectorToTarget;          //Move towards target
                break;
            case FlockingMode.FleeTarget:
				desiredDirection = -vectorToTarget;
                //LAB TASK #1: Implement FleeTarget
                //TODO: Move away from target
                break;
            case FlockingMode.MaintainDistance:
                {if(distanceToTarget < DesiredDistanceFromTarget_Min)
					desiredDirection = -vectorToTarget;
						else if(distanceToTarget > DesiredDistanceFromTarget_Max)
							desiredDirection = vectorToTarget;
                    //LAB TASK #2: Implement MaintainDistance
                    //TODO: If distance to target is less than DesiredDistanceFromTarget_Min, move away from target
                    //TODO: Otherwise, if distance to target is more than DesiredDistanceFromTarget_Max, move towards target
                }
                break;
            case FlockingMode.DoNothing:
                desiredDirection = Vector3.zero;
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ShockwavePickup")
        {
            Destroy(gameObject);
        }
    }

}