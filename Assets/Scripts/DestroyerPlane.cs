using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionExit(Collision other)
	{
		Destroy(other.gameObject);		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
