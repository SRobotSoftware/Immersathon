using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossConditions : MonoBehaviour
{
    public int Score;
    public bool GameOver;
    public bool Victory;
    public Light Sun;
    public GameObject YouWin;
    public GameObject YouLose;
    public void SunFlip()
    {
        Sun.transform.eulerAngles = new Vector3(270f, 0f, 0f);
    }


    void Start()
    {
        GameOver = false;
        YouWin.SetActive(false);
        YouLose.SetActive(false);


    }

    void Update()
    {
        if (GameOver == true)
        {
            if (Victory == true)
            {
                YouWin.SetActive(true);
                SunFlip();
                //Scene Transition to "You Win"
            }
            else if (Victory == false)
            {
                YouLose.SetActive(true);
                SunFlip();
                //Scene Transition to "You Lose"
            }
            else
            {
                GameOver = false;
            }
        }
    }
}
