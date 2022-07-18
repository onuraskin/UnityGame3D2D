using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public GameObject ball;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = ball.transform.position+distance;
    }
}
