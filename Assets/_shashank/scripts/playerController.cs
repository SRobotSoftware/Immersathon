using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	public ParticleSystem p1;

	private int count;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText ();
		winText.text = "";
	}

	// physics code for calculations
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Pick Up"))
		{
			Instantiate (p1, other.transform.position, other.transform.rotation);
			other.gameObject.SetActive(false);
			count++;
			setCountText ();
		}
	}


	void setCountText(){
		countText.text = "Count: " + count.ToString();
		if (count >= 10) {
			winText.text = "You win!";
		}
	}
}
