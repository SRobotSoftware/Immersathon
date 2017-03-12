using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumActivator : MonoBehaviour {

    public float startDelay = 0.3f;
    public float hitInterval = 0.3f;

    public List<GameObject> DrumTops;

    private BeatRecorder recorder;
    private List<Beat> beats;

    private Queue<Renderer> currentBeats;
    private Queue<float> currentBeatTimes;



    private int index;
    private float startTime = GameManager.startTime;


    // Use this for initialization
    void Awake() {
        recorder = gameObject.GetComponent<BeatRecorder>();
        currentBeats = new Queue<Renderer>();
        currentBeatTimes = new Queue<float>();
        index = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        beats = BeatRecorder.recordedBeats;
        Debug.Log(beats.Count);

        if (index < beats.Count && beats.Count > 0)
        {
            if (beats[index].beatTime < Time.time - startTime - startDelay)
            {
                
                int drumIndex = beats[index].drumRef;
                Renderer rend = DrumTops[drumIndex].GetComponent<Renderer>();
                Debug.Log(rend);
                rend.material.SetFloat("_MKGlowTexStrength", 5.0f);
                currentBeats.Enqueue(rend);
                currentBeatTimes.Enqueue(Time.time);
                //Debug.Log(beats[index].beatTime);
                index++;
            }
        }

        if(currentBeatTimes.Count > 0 && currentBeatTimes.Peek() < Time.time - startTime - startDelay)
        {
            Renderer nextRend = currentBeats.Dequeue();
            currentBeatTimes.Dequeue();
            nextRend.material.SetFloat("_MKGlowTexStrength", 0f);
        }


	}

}
