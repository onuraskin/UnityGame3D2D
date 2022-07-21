using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleCircle : MonoBehaviour
{
    public float speed;
    Rigidbody2D physic;
    bool moveCont = false;
    GameObject game0wner;

    // Start is called before the first frame update
    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        game0wner = GameObject.FindGameObjectWithTag("gameOwnerTag");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!moveCont) { 
        physic.MovePosition(physic.position+Vector2.up*speed*Time.deltaTime);
        }
    }
     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "SpinCircleTag") {
            transform.SetParent(col.transform);
            moveCont = true;
           
        }
        if (col.tag=="littleCircleTag") {
            game0wner.GetComponent<GameOwner>().gameFinished();
        }
        

    }
}
