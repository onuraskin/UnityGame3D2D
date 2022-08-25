using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public enum Axel { 
    Front,
    Rear

}
[Serializable]
public struct Wheel {
    public GameObject model;
    public WheelCollider collider;
    public Axel axel;
    
}


public class MotoControl : MonoBehaviour
{
    [SerializeField]
    private float maxAccelaration ;
    [SerializeField]
    private float maxSteerAngle;
    [SerializeField]
    private Vector3 centerOfMass;
    [SerializeField]
    private List<Wheel> wheels;

    public Transform a;
    public Transform b;
    public Transform c;

    private float inputX;
    private Rigidbody rbMotor;
    public float turningRate = 5f;
    private Quaternion _targetRotation = Quaternion.identity;
    private bool fall = false;
   



    private void Start()
    {
        rbMotor = GetComponent<Rigidbody>();
        rbMotor.centerOfMass = centerOfMass;
      


        wheels[0].collider.motorTorque = maxAccelaration * 1000 * Time.deltaTime;
        wheels[1].collider.motorTorque = maxAccelaration * 1000 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

        AnimateWheels();
        GetInputs();
        fallDown();


    }
    private void fallDown() {
        if ((gameObject.transform.localPosition.y<-5)&&fall==false)
        {
            
            gameObject.transform.localPosition=new Vector3(0,0,0);
            gameObject.transform.localRotation = Quaternion.Euler(0,0,0);
            
        }
    
    
    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Road") )
        {
            
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
           

        }
        if (collision.gameObject.tag.Equals("Obstacle") )
        {
            
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z - 3);
            collision.gameObject.SetActive(false); 
           
        }
        if (collision.gameObject.tag.Equals("Finish")) {

            SceneManager.LoadScene("finishMenu");

        }
    }

    private void LateUpdate()
    {
        Move();
        Turn();
    }

    float Remap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    float rotationSpeed = 0.5f;
    float delta;
    Vector2 firstInput;
    private void GetInputs() {
        
        //inputX = SimpleInput.GetAxis("Horizontal");

        if (Input.GetMouseButtonDown(0))
        {
            firstInput = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            delta = Vector3.Distance(firstInput, Input.mousePosition);
                
            if (firstInput.x - Input.mousePosition.x < 0)
            {
                inputX = Remap(delta, 0, Screen.width - firstInput.x, 0, 1);
            }
            else
            {
                inputX = Remap(delta, 0, Screen.width - firstInput.x, 0, -1);
            }
        }
        else
        {
            delta = 0;
            inputX = 0;
        }



        if (inputX > 0)
        {
            //transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0,0, -90f), turningRate * Time.deltaTime);

            a.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -50), rotationSpeed * Time.deltaTime);
            b.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -50), rotationSpeed * Time.deltaTime);
            c.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -50), rotationSpeed * Time.deltaTime);

        }
        else if (inputX < 0)
        {
            a.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 50), rotationSpeed * Time.deltaTime);
            b.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 50), rotationSpeed * Time.deltaTime);
            c.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 50), rotationSpeed * Time.deltaTime);
            //transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, 0, 90f), turningRate * Time.deltaTime);

        }
        else if (inputX == 0)
        {
            a.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotationSpeed * Time.deltaTime);
            b.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotationSpeed * Time.deltaTime);
            c.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotationSpeed * Time.deltaTime);
            rbMotor.angularVelocity = Vector3.Lerp(rbMotor.angularVelocity, Vector3.zero, rotationSpeed * 10 * Time.deltaTime);

            //float yIndex;
            //yIndex = transform.localRotation.y;
            //Debug.Log(yIndex);
            //transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, 0, 0), turningRate * Time.deltaTime);
        }


        //transform.rotation= Quaternion.Euler(this.transform.rotation.eulerAngles.x,
        //   Mathf.Clamp(this.transform.rotation.eulerAngles.y,255,285), this.transform.rotation.eulerAngles.z);
        //Debug.Log(this.transform.rotation.eulerAngles.y);


        //if (inputX > 0)
        //{

        //  transform.rotation= Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -90, -42), turningRate * Time.deltaTime);


        //}
        //else if (inputX < 0)
        //{
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -90, 42), turningRate * Time.deltaTime);
        //}
        //else if(inputX == 0) {


        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -90, 0), turningRate*2* Time.deltaTime);

        //}


    }

  

    private void Move() {

        //foreach (var wheel in wheels)
        //{
        //    wheel.collider.motorTorque = maxAccelaration*750*Time.deltaTime ;

        //}
    
    //-75 -115
    }
    private void Turn() {
        foreach (var wheel in wheels)
        {
            if (wheel.axel==Axel.Front)
            {
                if (inputX == 0)
                {
                    wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle,0, 2f);
                    //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), turningRate * Time.deltaTime);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), turningRate * Time.deltaTime);
                }
                else
                {
                    float _steerAngel = inputX * 5 * maxSteerAngle;
                    wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngel, 0.5f);

                    //Debug.Log("Wheel :" + wheel.collider.steerAngle);
                }
            }
        }
    }
   
    private void AnimateWheels() {

        foreach (var wheel in wheels)
        {
           
            Quaternion rot;
            Vector3 pos;
            wheel.collider.GetWorldPose(out pos, out rot);
            wheel.model.transform.position = pos;
            wheel.model.transform.rotation = rot;

        }
    
    }
}
