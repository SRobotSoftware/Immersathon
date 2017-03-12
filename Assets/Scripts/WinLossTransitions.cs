using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossTransitions : MonoBehaviour
{
    public Light Sun;

    public void SunFlip()
    {
        Sun.transform.eulerAngles = new Vector3(270f, 0f, 0f);
    }
    // Use this for initialization
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
