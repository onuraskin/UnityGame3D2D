using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    public float speed;
    Rigidbody pyhsic;
    void Start()
    {
        pyhsic = GetComponent<Rigidbody>();
        pyhsic.velocity = transform.forward * speed;

    }
}
