using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class ColliderObj
{
    public Collider collider { get; protected set; }
    public float delay { get; protected set; }

    public ColliderObj(Collider _collider, float delay)
    {
        collider = _collider;
        delay = Time.time + delay;
    }
}
*/


public class DrumStick : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

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
        Debug.Log("Drumstick has collided with " + collider.name);

        //collider.enabled = false;
        //collider.isTrigger = true;
        //Debug.Log(collider.enabled);
        //Debug.Log(collider.isTrigger);
        //ColliderObj colliderObj = new ColliderObj(collider, colliderDelay);
        //colliders.Enqueue(colliderObj);
        StartCoroutine(VibrateController(0.05f, 3999));
        ;
        float force = -Mathf.Clamp(Mathf.Abs((device.angularVelocity.x) * 100), 0, 1000);
        Debug.Log(force);
        collider.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, force, 0));

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
