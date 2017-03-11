using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseConditions : MonoBehaviour
{
    public int Score;
    public bool GameOver;
    public bool Victory;

    void Start()
    {
        GameOver = false;
    }

    void Update()
    {
        if (GameOver == true)
        {
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
