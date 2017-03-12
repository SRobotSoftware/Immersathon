using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DrumStick : MonoBehaviour
{
    public GameObject Gamer;
    public GameObject EmojiSpawner;

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    private Transform[] emojis;
    private float startTime = GameManager.startTime;

    void Awake()
    {
        trackedObj = GetComponentInParent<SteamVR_TrackedObject>();

    }

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);

    }

    void Start()
    {
        Debug.Log(device);
    }
    void OnTriggerEnter(Collider collider)
    {
        // Debug.Log("Drumstick has collided with " + collider.name);

        float force = -Mathf.Clamp(Mathf.Abs((device.angularVelocity.x) * 100), 0, 1000);


        StartCoroutine(VibrateController(0.05f, 3999));
        collider.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, force, 0));

        if (GameManager.build && collider.gameObject.name == "DrumCenter")
        {
            Debug.Log("Recorded a beat");
            Beat newBeat = new Beat(Time.time, collider.gameObject.GetComponentInChildren<DrumTop>().index, force);
            BeatRecorder.recordedBeats.Add(newBeat);
        }

        StrikeNearestEnemy(force);

    }

    private void StrikeNearestEnemy(float force)
    {
        emojis = EmojiSpawner.GetComponentsInChildren<Transform>();
        Transform NearestEnemy = GetClosestEnemy(emojis);
        Rigidbody nearestRigid = NearestEnemy.GetComponent<Rigidbody>();
        if(nearestRigid != null)
            nearestRigid.velocity = new Vector3(force / 2, 0, 0);
    }

    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            // Debug.Log(t);
            float dist = Mathf.Sqrt(Vector3.Distance(t.position, currentPos));
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    /*
    void LateUpdate()
    {
        if (colliders != null && colliders.Count > 0)
        {
            ColliderObj nextCollider = colliders.Peek();
            //Debug.Log(nextCollider.delay - Time.time);
            if (nextCollider.delay - Time.time < 0)
            {
                Debug.Log(nextCollider.collider.enabled);
                Debug.Log(nextCollider.collider.isTrigger);
                nextCollider.collider.enabled = true;
                nextCollider.collider.isTrigger = false;
                colliders.Dequeue();
            }
        }
    }
    */

    IEnumerator VibrateController(float length, float strength)
    {
        for (float i = 0; i < length; i += Time.deltaTime)
        {
            device.TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, strength));
            yield return null;
        }
    }

}
