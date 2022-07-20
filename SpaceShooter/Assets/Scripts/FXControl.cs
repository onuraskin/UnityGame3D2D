using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXControl : MonoBehaviour
{
    public float speed;
    Rigidbody pyhsic;
    void Start()
    {
        pyhsic = GetComponent<Rigidbody>();
        pyhsic.velocity = transform.forward*speed;
        
    }

    
   
}
