using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDrumStick : MonoBehaviour
{
    public GameObject Gamer;
    public GameObject EmojiSpawner;

    public Transform[] emojis;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        emojis = EmojiSpawner.GetComponentsInChildren<Transform>();
        Debug.Log("Drumstick has collided with " + collider.name);        
        
        float force = -1;
        collider.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, force, 0));
        if (GameManager.build == true && collider.gameObject.name == "DrumCenter")
        {
            Debug.Log("Added beat");
            Beat newBeat = new Beat(Time.time, collider.gameObject.GetComponentInChildren<DrumTop>().index, force);
            BeatRecorder.recordedBeats.Add(newBeat);
        }

        Transform NearestEnemy = GetClosestEnemy(emojis);
        Rigidbody nearestRigid = NearestEnemy.GetComponent<Rigidbody>();
        if (nearestRigid != null)
            nearestRigid.velocity = new Vector3(force / 2, 0, 0);

    }
    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Mathf.Sqrt(Vector3.Distance(t.position, currentPos));
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

}
