using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    public GameObject obstacle;
    [SerializeField] private Vector3 _rotation;
    private float speed = 1;
    // Start is called before the first frame update
   
    private void FixedUpdate()
    {
        obstacle.transform.Rotate(_rotation * speed * Time.deltaTime);
    }
}
