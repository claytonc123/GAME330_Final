using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{

    Vector3 shakeStartPosition;
    float shakeMagnitude;
    float shakeSecondsLeft;

    // Use this for initialization
    void Start()
    {
        shakeMagnitude = 0.0f;
        shakeSecondsLeft = 0.0f;
        shakeStartPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeSecondsLeft > 0.0f)
        {
            shakeSecondsLeft -= Time.deltaTime;
            Vector2 shakeVector = Random.insideUnitCircle * shakeMagnitude;
            transform.localPosition = new Vector3(
                    shakeStartPosition.x,
                    shakeStartPosition.y + shakeVector.y,
                    shakeStartPosition.z + shakeVector.x
                );
        }
        else
        {
            shakeSecondsLeft = 0.0f;
            transform.localPosition = shakeStartPosition;
        }
    }

    public void Shake(float inMagnitude, float inShakeSeconds)
    {
        shakeMagnitude = inMagnitude;
        shakeSecondsLeft = inShakeSeconds;
        shakeStartPosition = transform.localPosition;
    }
}
