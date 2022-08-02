using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    [SerializeField]
    private float directSpeed;
    [SerializeField]
    private float leftorRightSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal")*leftorRightSpeed*Time.deltaTime;
        this.transform.Translate(horizontal,0,directSpeed*Time.deltaTime);
    }
}
