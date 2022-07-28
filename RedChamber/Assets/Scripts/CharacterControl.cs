using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
public class CharacterControl : MonoBehaviour
{
    public Sprite[] waitAnim;
    public Sprite[] jumpAnim;
    public Sprite[] runAnim;
    int waitTemp = 0;
    int runTemp = 0;
    SpriteRenderer spriteRenderer;
    float horizontal = 0;
    float waitAnimTime = 0;
    float runAnimTime = 0;
    Rigidbody2D physic;
    Vector3 vec;
    Vector3 camLastPost;
    Vector3 camfirstPost;
    bool onceJump = true;
    GameObject cameras;
    public Text healthText;
    public Text goldText;
    public Image darkBackG;
    int health = 100;
    float darkTemp;
    float goToMainTime;
    int goldTemp = 0;
    
    
    
    void Start()
    {
        darkBackG.gameObject.SetActive(false);
        Time.timeScale = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        physic = GetComponent<Rigidbody2D>();
        cameras = GameObject.FindGameObjectWithTag("MainCamera");
        if (SceneManager.GetActiveScene().buildIndex> PlayerPrefs.GetInt("whichlevel"))
        {
            PlayerPrefs.SetInt("whichlevel", SceneManager.GetActiveScene().buildIndex);
        }
        
        camfirstPost = cameras.transform.position-transform.position;
        healthText.text = "Healt : " + health;
        goldText.text = "Gold_9-" + goldTemp;



    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (onceJump)
            {
                physic.AddForce(new Vector2(0,450));
                onceJump = false;
            }

        }
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        onceJump = true;
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="ammo") {
            health--;
            healthText.text = "Health  :" + health;
        }
        if (collision.gameObject.tag == "enne")
        {
            health-=10;
            healthText.text = "Health  :" + health;
        }
        if (collision.gameObject.tag == "saw")
        {
            health -= 20;
            healthText.text = "Health  :" + health;
        }
        if (collision.gameObject.tag == "gameFinished")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        if (collision.gameObject.tag =="giveHealth")
        {
            
                
            
            health += 10;
            healthText.text = "Health  :" + health;
            collision.GetComponent<BoxCollider2D>().enabled = false;
            collision.GetComponent<giveHealth>().enabled = true;
            Destroy(collision.gameObject,2f);
           
           

        }
        if (collision.gameObject.tag == "gold")
        {
            goldTemp++;
            goldText.text = "9-" + goldTemp;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "water")
        {
            health = 0;
            transform.Rotate(0,0,-90);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        chamberMove();
        Animation();
        if (health<=0)
        {
            Time.timeScale = 0.5f;
            healthText.enabled = false;
            darkTemp += 0.03f;
            darkBackG.gameObject.SetActive(true);
            darkBackG.color = new Color(0,0,0,darkTemp);
            goToMainTime += Time.deltaTime;
            if (goToMainTime>1)
            {
                SceneManager.LoadScene("MainMenu");
            }

        }
    }
    void LateUpdate()
    {
        camContorl(); 
    }
    void chamberMove()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vec = new Vector3(horizontal * 10, physic.velocity.y, 0);
        physic.velocity = vec;
    }
    void camContorl() {
        camLastPost = camfirstPost + transform.position;
        cameras.transform.position = Vector3.Lerp(cameras.transform.position,camLastPost,0.09f);
    
    
    }
    void Animation()
    {
        if (onceJump)
        {
            if (horizontal == 0)
            {
                waitAnimTime += Time.deltaTime;
                if (waitAnimTime > 0.05f)
                {
                    spriteRenderer.sprite = waitAnim[waitTemp++];
                    if (waitTemp == waitAnim.Length)
                    {
                        waitTemp = 0;
                    }
                    waitAnimTime = 0;
                }

            }
            else if (horizontal > 0)
            {
                runAnimTime += Time.deltaTime;
                if (runAnimTime > 0.01f)
                {
                    spriteRenderer.sprite = runAnim[runTemp++];
                    if (runTemp == runAnim.Length)
                    {
                        runTemp = 0;
                    }
                    runAnimTime = 0;
                }
                transform.localScale = new Vector3(1, 1, 1);


            }
            else if (horizontal < 0)
            {
                runAnimTime += Time.deltaTime;
                if (runAnimTime > 0.01f)
                {
                    spriteRenderer.sprite = runAnim[runTemp++];
                    if (runTemp == runAnim.Length)
                    {
                        runTemp = 0;
                    }
                    runAnimTime = 0;
                }
                transform.localScale = new Vector3(-1, 1, 1);


            }
        }
        else
        {     //jump anim up and down
            if (physic.velocity.y > 0)
            {
                spriteRenderer.sprite = jumpAnim[0];
            }


            else
            {
                spriteRenderer.sprite = jumpAnim[1];
            }
            if (horizontal > 0) {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0) {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

}
