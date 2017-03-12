using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossConditions : MonoBehaviour
{
    public int Score;
    public bool GameOver;
    public bool Victory;
    public GameObject Flipper;

    void Start()
    {
        GameOver = true;

    }

    void Update()
    {
        if (GameOver == true)
        {
            Flipper.SunFlip();
            if (Victory == true)
            {
                //Scene Transition to "You Win"
            }
            else if (Victory == false)
            {
                //Scene Transition to "You Lose"
            }
            else
            {
                GameOver = false;
            }
        }
    }
}
