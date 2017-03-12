using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButton : MonoBehaviour
{

    //public ParticleSystem p1;
    public BeatRecorder recorder;

    private void Start()
    {
        recorder = GetComponent<BeatRecorder>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.play = false;
        GameManager.build = true;
        Debug.Log("You are Building a new song!");
        Debug.Log(GameManager.build);
        Rigidbody rigid = gameObject.GetComponent<Rigidbody>();
        rigid.AddForce(new Vector3(-70, 120, 0));
        rigid.AddTorque(new Vector3(20, 0, 20));
        rigid.useGravity = true;
        GameObject playButton = GameObject.Find("Play Button");
        playButton.SetActive(false);

        //if(GameManager.build)

            

        //Instantiate(p1, other.transform.position, other.transform.rotation);
        //other.gameObject.SetActive(false);
    }

    // Update is called once per frame


    // Update is called once per frame
    void Update()
    {

    }
}
