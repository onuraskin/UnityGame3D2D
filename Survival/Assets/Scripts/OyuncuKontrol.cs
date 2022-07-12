using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyuncuKontrol : MonoBehaviour
{
    public Transform mermiPos;
    public GameObject mermi;
    public GameObject patlama;
    public Image canImajý;
    private float canDegeri = 100f;
    public OyunKontrol finish;
    public AudioClip AtisSesi, olmeSesi, CanAlmaSesi, yaralanmaSesi;
    private AudioSource Asource;
    
    // Start is called before the first frame update
    void Start()
    {
        Asource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            Asource.PlayOneShot(AtisSesi,1f);
            GameObject go = Instantiate(mermi, mermiPos.position, mermiPos.rotation) as GameObject;
            GameObject gopatlama = Instantiate(patlama, mermiPos.position, mermiPos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 25f;
            Destroy(go.gameObject, 2f);
            Destroy(gopatlama.gameObject, 2f);

        }
    }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("zombi"))
            {
            Asource.PlayOneShot(yaralanmaSesi, 1f);
            Debug.Log("Dokundu");
                canDegeri -= 10f;
                float x = canDegeri / 100f;
                canImajý.fillAmount = x;
                canImajý.color = Color.Lerp(Color.red,Color.green,x);
            if (canDegeri <= 0) {
                Asource.PlayOneShot(olmeSesi,1f);
                finish.oyunBitti();

            }
        }
                }
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("kalp")) {
            Asource.PlayOneShot(CanAlmaSesi, 1f);
            if (canDegeri<100f)
            canDegeri += 10f;
            float x = canDegeri / 100f;
            canImajý.fillAmount = x;
            canImajý.color = Color.Lerp(Color.red, Color.green, x);
        }
        
    }
    

}
        

