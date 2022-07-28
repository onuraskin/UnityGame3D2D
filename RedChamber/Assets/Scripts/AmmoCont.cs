using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCont : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyControl enemy;
    Rigidbody2D physic;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enne").GetComponent<EnemyControl>();
        physic = GetComponent<Rigidbody2D>();
        physic.AddForce(enemy.getWay()*500) ;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
