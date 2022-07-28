using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterAnim : MonoBehaviour
{
    public Sprite[] animationsSquare;
    SpriteRenderer spriteRenderer;
    float temp = 0;
    int animTemp = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        temp += Time.deltaTime;
        if (temp > 0.03f)
        {
            spriteRenderer.sprite = animationsSquare[animTemp++];
            if (animationsSquare.Length == animTemp)
            {
                animTemp = 0;
            }
            temp = 0;
        }

    }
}