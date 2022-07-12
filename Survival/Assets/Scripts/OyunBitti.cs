using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunBitti : MonoBehaviour
{
    public Text puan;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        puan.text = "Puanýnýz  :"+PlayerPrefs.GetInt("puan");
        
    }
    public void yenidenOyna() {
        SceneManager.LoadScene("Game");
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
