using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{

    //public ParticleSystem p1;
    public BeatRecorder recorder;

    private void Start()
    {
        recorder = new BeatRecorder();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.play = true;
        GameManager.build = false;
        Debug.Log("You are Playing!");
        Rigidbody rigid = gameObject.GetComponent<Rigidbody>();
        rigid.AddForce(new Vector3(-70, 120, 0));
        rigid.AddTorque(new Vector3(20, 0, 20));
        rigid.useGravity = true;
        GameObject buildButton = GameObject.Find("Build Button");
        buildButton.SetActive(false);
        recorder.LoadMusic();

        //Instantiate(p1, other.transform.position, other.transform.rotation);
        //other.gameObject.SetActive(false);
    }    
	
	// Update is called once per frame
	void Update () {

	}
}
