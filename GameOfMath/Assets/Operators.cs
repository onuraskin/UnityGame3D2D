using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operators : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Text FirstNum, SecNum, Operator, Answer, Result;
    int OpResult;
    int num1, num2, OpSymbol;

    void Start()
    {
        newQuestation();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnswerCheck() {
        if (int.Parse(Answer.text)==OpResult) {
            Result.text = "Dogru";
        }
        else {
            Result.text = "Yanlis";
        }
    
    
    }
    public void newQuestation() {
        num1 = Random.Range(1, 10);
        num2 = Random.Range(1, 10);
        OpSymbol = Random.Range(1, 4);
        switch (OpSymbol)
        {
            case 1:
                Operator.text = "+";
                OpResult = num1 + num2;
                break;
            case 2:
                Operator.text = "-";
                OpResult = num1 - num2;
                break;
            case 3:
                Operator.text = "/";
                OpResult = num1 / num2;
                break;
            case 4:
                Operator.text = "x";
                OpResult = num1 * num2;
                break;

        }
        FirstNum.text = num1 + "";
        SecNum.text = num2 + "";








    }
}
