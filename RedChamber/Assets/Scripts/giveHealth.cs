using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveHealth : MonoBehaviour
{
    public Sprite[] animationsSquare;
    SpriteRenderer spriteRenderer;
    float temp=0;
    int animTemp=0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        temp += Time.deltaTime;
        if (temp>0.1f)
        {
            spriteRenderer.sprite = animationsSquare[animTemp++];
            if (animationsSquare.Length==animTemp)
            {
                animTemp = animationsSquare.Length-1;
            }
            temp = 0;
        }
        
    }
}
