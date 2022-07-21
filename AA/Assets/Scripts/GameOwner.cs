using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOwner : MonoBehaviour
{
    GameObject spinCircle;
    GameObject mainCircle;
    public Animator anim;
    public Text spinCircleLevel;
    public Text one;
    public Text two;
    public Text three;
    public int howmanycircle;
    bool control = true;
    void Start()
    {
        spinCircle = GameObject.FindGameObjectWithTag("SpinCircleTag");
        mainCircle = GameObject.FindGameObjectWithTag("mainCircle");
        spinCircleLevel.text = SceneManager.GetActiveScene().name;
        if (howmanycircle < 2)
        {
            one.text = howmanycircle + "";
        }
        else if (howmanycircle < 3)
        {
            one.text = howmanycircle + "";
            two.text = (howmanycircle - 1) + "";

        }
        else
        {
            one.text = howmanycircle + "";
            two.text = (howmanycircle - 1) + "";
            three.text = (howmanycircle - 2) + "";
        }
        if (howmanycircle==0) {
            StartCoroutine(newLevel());
        }
    }
    IEnumerator newLevel() {
        spinCircle.GetComponent<Spin>().enabled = false;
        mainCircle.GetComponent<MainCircle>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        if (control) {
            anim.SetTrigger("newLevel");
            yield return new WaitForSeconds(1.4f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
       


    }
    public void littleCircleTextShow()
    {
        howmanycircle--;
        if (howmanycircle < 2)
        {
            one.text = howmanycircle + "";
            two.text = "";
            three.text = "";
        }
        else if (howmanycircle < 3)
        {
            one.text = howmanycircle + "";
            two.text = (howmanycircle - 1) + "";
            three.text = "";
        }
        else
        {
            one.text = howmanycircle + "";
            two.text = (howmanycircle - 1) + "";
            three.text = (howmanycircle - 2) + "";
        }


    }
    public void gameFinished()
    {
        StartCoroutine(callMethod());
    }
    IEnumerator callMethod()
    {
        spinCircle.GetComponent<Spin>().enabled = false;
        mainCircle.GetComponent<MainCircle>().enabled = false;
        anim.SetTrigger("gameFinished");
        control = false;
        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene("Level2");

    }


}
