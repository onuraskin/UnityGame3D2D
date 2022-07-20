using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject destroy;
    public GameObject playerDestroy;
    GameObject GameControl;
    GameControl Control;
    void Start()
    {
        GameControl = GameObject.FindGameObjectWithTag("conGame");
        Control = GameControl.GetComponent<GameControl>();
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate(destroy, transform.position, transform.rotation);
        Control.ScoreUpper(10);
        if (other.tag=="Player") {
            Instantiate(playerDestroy, other.transform.position, other.transform.rotation);
            Control.gameOver();
        }
    }
    
    
}
