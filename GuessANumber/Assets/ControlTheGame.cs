using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTheGame : MonoBehaviour
{
    int min = 1;
    int max =100;
    int guess;
    bool startGame = false;
    
    // Start is called before the first frame update
    void Start()
    {
        print("Do you want to play game with me ? (Y/N)");
    }

    // Update is called once per frame
    void Update()
    {
        if (!startGame)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                print("Great ! Guess a number in ur mind 1 - 100 then press Enter");
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                print("You know");
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Kontrol();
                startGame = true;
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                min = guess;
                Kontrol();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                max = guess;
                Kontrol();

            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {

                print("Great I found your Number in ur mind . ");
                startGame = false;
            }
        }
        void Kontrol() {
            guess = (min + max) / 2;
            print("Ýs this Your Number ?"+ guess + "Ýs it higher press UP, lower press Down, if is it press the space");
        }
    }
}
