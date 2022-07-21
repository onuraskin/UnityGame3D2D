using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    public void goToGame() {

        SceneManager.LoadScene("1");
    }
    public void leave() {
        Application.Quit();
    }
    
}
