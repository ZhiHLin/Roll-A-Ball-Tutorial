using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        transform.position = new Vector3(PingPong(Time.time * speed, -1, 2), transform.position.y, transform.position.z);
    }

    float PingPong(float t, float minLength, float maxLength)
    {
        return Mathf.PingPong(t, maxLength - minLength) + minLength;
    }
}
