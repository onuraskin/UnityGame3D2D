using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mainMenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    
    GameObject levels;
    GameObject locks;
    void Start()
    {
       
       
        levels = GameObject.Find("Levels");
        locks = GameObject.Find("locks");
        
        for (int i = 0; i < levels.transform.childCount; i++)
        {
            levels.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < locks.transform.childCount; i++)
        {
            locks.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < PlayerPrefs.GetInt("whichlevel"); i++)
        {
            levels.transform.GetChild(i).GetComponent<Button>().interactable = true; ;
        }
    }
    public void selectButton(int button)
    {
        if (button == 1)
        {
            SceneManager.LoadScene(1);
        }
        else if (button == 2)
        {
            for (int i = 0; i < locks.transform.childCount; i++)
            {
                locks.transform.GetChild(i).gameObject.SetActive(true);
            }
            for (int i = 0; i < levels.transform.childCount; i++)
            {
                levels.transform.GetChild(i).gameObject.SetActive(true);
            }

            for (int i = 0; i < PlayerPrefs.GetInt("whichlevel"); i++)
            {
                locks.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (button == 3)
        {
            Application.Quit();
        }

       

    }
    // Update is called once per frame
    public void levelsButton(int comeL)
    {
        SceneManager.LoadScene(comeL);


    }
}
