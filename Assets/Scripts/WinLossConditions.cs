using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossConditions : MonoBehaviour
{
    public int Score;
    public bool GameOver;
    public bool Victory;
    public GameObject Flipper;
    public Light Sun;
    public void SunFlip()
    {
        Sun.transform.eulerAngles = new Vector3(270f, 0f, 0f);
    }


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
