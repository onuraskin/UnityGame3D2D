using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    AudioSource audios;
    Rigidbody physic;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float speed;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float aim;
    public float dTime;
    public GameObject Ammo;
    public Transform startPosAmmo;
    float gunTime = 0;
    void Start()
    {
        physic = GetComponent<Rigidbody>();
        audios = GetComponent<AudioSource>();
    }
     void Update()
    {
        if (Input.GetButton("Fire1")&& Time.time>gunTime) {
            audios.Play();
            gunTime = Time.time + dTime;
           GameObject laserClone =Instantiate(Ammo,startPosAmmo.position,Quaternion.identity )as GameObject;
            Destroy(laserClone, 3f);
        }
        
    }


    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal,0,vertical);
        physic.velocity = vec*speed;
        physic.position = new Vector3(Mathf.Clamp(physic.position.x,minX,maxX),0.0f,
            Mathf.Clamp(physic.position.z,minZ,maxZ));
        physic.rotation = Quaternion.Euler(0f,0f,physic.velocity.x*-aim);
    }
}
