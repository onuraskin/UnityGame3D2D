using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTheBall : MonoBehaviour
{
    Rigidbody pyhsic;
    public int speed;
    int sayac = 0;
    public int collected›temsNum;
    public Text temp;
    public Text GameFinished;
    // Start is called before the first frame update
    void Start()
    {
        pyhsic = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yatay = Input.GetAxisRaw("Horizontal");
        float dikey = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(yatay,0,dikey);
        pyhsic.AddForce(vec*speed);

        //Debug.Log("yatay : " + yatay+"dikey : " +dikey);

    }
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Danger") {
            other.gameObject.SetActive(false);
            sayac++;
            temp.text = "Temp : " + sayac;
            if (sayac==collected›temsNum) {
                GameFinished.text = "Game Finished";
                
            }
        }
    }
}
