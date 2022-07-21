using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircle : MonoBehaviour
{
    public GameObject littCircle;
    GameObject GameOwner;
    // Start is called before the first frame update
    void Start()
    {
        GameOwner = GameObject.FindGameObjectWithTag("gameOwnerTag");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            littleCircleCreator();

        }

    }
    void littleCircleCreator(){
        Instantiate(littCircle,transform.position,transform.rotation);
        GameOwner.GetComponent<GameOwner>().littleCircleTextShow();
    
    }
}
