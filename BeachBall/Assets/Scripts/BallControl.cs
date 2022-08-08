using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float forcePower=10f;
    public float maxDrag=5f;
    Rigidbody2D rb;
    LineRenderer lr;
    public Text speedText;

    Vector3 dragStartPos;
    Touch touch;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        lr = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = rb.velocity.magnitude.ToString();
        if (Input.touchCount>0) { //Ýf touched the screen
            touch = Input.GetTouch(0);
            if (touch.phase==TouchPhase.Began)
            {
                dragStart();
            }if (touch.phase==TouchPhase.Moved)
            {
                Dragging();
            }if (touch.phase==TouchPhase.Ended)
            {
                dragRelease();
            }
        
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hole")) {
            if (rb.velocity.magnitude<1.4f)
            {
                gameObject.SetActive(false);
            }
          
        }
        if (collision.gameObject.CompareTag("Diken"))
        {
            gameObject.SetActive(false);
        }
    }
    void dragStart() {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0;
        lr.positionCount = 1;
        lr.SetPosition(0,dragStartPos);
    
    }
    void Dragging() { 
    
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0;
        lr.positionCount = 2;
        lr.SetPosition(1,draggingPos);

    }
    void dragRelease() {
        lr.positionCount = 0;
        Vector3 dragReleasePos= Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0;

        Vector3 forceVec = dragStartPos - dragReleasePos;
        rb.AddForce(forceVec*forcePower);

    }
}
