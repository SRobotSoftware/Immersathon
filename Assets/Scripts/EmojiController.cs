using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiController : MonoBehaviour {
	
	public GameObject ExplosionEffect;
	private Rigidbody body;
	private int counter = 30;

	private float CreatedAt;

	// Use this for initialization
	void Start () {
		CreatedAt = Time.time;
		SetSpeed();
	}

	private void SetSpeed()
	{
		body = gameObject.GetComponent<Rigidbody>();
		body.velocity = new Vector3(10, Random.Range(0,25), 0);
	}

	void BeforeDestroy()
	{
		Instantiate(ExplosionEffect, gameObject.transform.position, gameObject.transform.rotation);
		Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
