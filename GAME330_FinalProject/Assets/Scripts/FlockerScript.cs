using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockerScript : MonoBehaviour {

    public enum FlockingMode
    {
        ChaseTarget,
        FleeTarget,
        MaintainDistance,
        DoNothing
    }

    public float SpeedPerSecond = 4.0f;
    public GameObject FlockingTarget;
    public FlockingMode CurrentFlockingMode = FlockingMode.ChaseTarget;
    public float DesiredDistanceFromTarget_Min = 3.5f;
    public float DesiredDistanceFromTarget_Max = 4.5f;
    public float DistanceFromHazard;
    public GameObject player;

    public bool AvoidHazards = true;

    // Use this for initialization
    void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 desiredDirection = new Vector3();

        Vector3 vectorToTarget = FlockingTarget.transform.position - transform.position;
        float distanceToTarget = vectorToTarget.magnitude;
        
        switch (CurrentFlockingMode)
        {
            case FlockingMode.ChaseTarget:
                desiredDirection = vectorToTarget;          //Move towards target
                break;
            case FlockingMode.FleeTarget:
                //LAB TASK #1: Implement FleeTarget
                //TODO: Move away from target

                desiredDirection = vectorToTarget * -1;
                
                break;
            case FlockingMode.MaintainDistance:
                {
                    //LAB TASK #2: Implement MaintainDistance
                    //TODO: If distance to target is less than DesiredDistanceFromTarget_Min, move away from target
                    //TODO: Otherwise, if distance to target is more than DesiredDistanceFromTarget_Max, move towards target

                    if (distanceToTarget < DesiredDistanceFromTarget_Min) {
                        desiredDirection = vectorToTarget * -1;
                    } else {
                        desiredDirection = vectorToTarget;
                    }
                }
                break;
            case FlockingMode.DoNothing:
                desiredDirection = Vector3.zero; 
                break;
        }

        if(AvoidHazards)
        {
            HazardScript[] hazards = FindObjectsOfType<HazardScript>();

            Vector3 avoidanceVector = Vector3.zero;
            for (int i = 0; i < hazards.Length; ++i)
            {
                Vector3 vectorToHazard = hazards[i].transform.position - transform.position;
                if (vectorToHazard.magnitude < DistanceFromHazard)
                {
                    Vector3 vectorAwayFromHazard = -vectorToHazard;
                    //LAB TASK #3: Implement hazard avoidance, part 1
                    //TODO: Accumulate vectors away from hazards in avoidance vector (i.e. add all the vectorAwayFromHazard into avoidanceVector)

                    avoidanceVector = avoidanceVector + vectorAwayFromHazard;
                }
            }

            if(avoidanceVector != Vector3.zero)
            {
                desiredDirection.Normalize();
                avoidanceVector.Normalize();

                //LAB TASK #4: Implement hazard avoidance, part 2
                //TODO: Set the value of desiredDirection to 50% desiredDirection and 50% avoidanceVector

                desiredDirection = desiredDirection / 2 + avoidanceVector / 2;
            }
        }

        desiredDirection.Normalize();
        transform.position += desiredDirection * SpeedPerSecond * Time.deltaTime;
    }

    private void OnDestroy()
    {
        //player.GetComponent<Player>().kills ++;
    }

   /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ShockwavePickup")
        {
            //audioSource.PlayOneShot(destroy);
            Destroy(gameObject);
            player.GetComponent<Player>().kills++;
        }
    }*/
}
