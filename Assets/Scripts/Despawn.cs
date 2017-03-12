using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour {
    public ParticleSystem p1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        Instantiate(p1, collider.transform.position, collider.transform.rotation);
        Destroy(collider.gameObject);
        Debug.Log("Kaboom!");
    }
}
