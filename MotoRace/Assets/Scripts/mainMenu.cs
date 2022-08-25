using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    public void gotoGame()
    {
        SceneManager.LoadScene("moveAblev1");

    }

    public void leavetheGame()
    {
        Application.Quit();
    }
}
