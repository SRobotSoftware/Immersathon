using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiController : MonoBehaviour {
	
	public GameObject ExplosionEffect;
	private Rigidbody body;

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

	public void Explode()
	{
		// Instantiate(ExplosionEffect, gameObject.transform.position, gameObject.transform.rotation);
		Destroy(gameObject);
		Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.y<0f) Explode();
	}
}
