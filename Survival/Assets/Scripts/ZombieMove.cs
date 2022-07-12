using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour
{
    public GameObject kalp;
    private GameObject player;
    private int zombieCan=3;
    private float mesafe;
    private OyunKontrol oKontrol;
    private int ZombiP=10;
    private AudioSource Asource;
    private bool zombieOluyor = false;
    // Start is called before the first frame update
    void Start()
    {
        Asource = GetComponent<AudioSource>();
        player = GameObject.Find("Oyuncu");
        oKontrol = GameObject.Find("_Scripts").GetComponent<OyunKontrol>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        mesafe = Vector3.Distance(transform.position, player.transform.position);
        if (mesafe < 10f)
        {
            if (!Asource.isPlaying)
                Asource.Play();
            if(!zombieOluyor)
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }
        else {
            if (!Asource.isPlaying)
                Asource.Stop();
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("mermi")){
            zombieCan-=1;
            if (zombieCan==0) {
                zombieOluyor = true;
                oKontrol.PuanArttir(ZombiP);
                Instantiate(kalp,transform.position,Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject,1.667f);
            }
        
        
        }
        
    }
}
