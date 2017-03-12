using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiGenerator : MonoBehaviour {

	public GameObject emoji;
	private float LastGenerated;
	private bool GameOver = false;
	private float interval = 1f;
	public Light Sun;

	// Use this for initialization
	void Start () {
		// Parent = GetComponent<
	}

	private int randomModifier {
		get {
			return Random.Range(1, 55);
		}
	}
	
	private void CreateEmoji()
	{
		Vector3 parentPosition = gameObject.transform.position;
		List<int> modifiers = new List<int>();
		Vector3 position = new Vector3(parentPosition.x + randomModifier, parentPosition.y, parentPosition.z + randomModifier);
		GameObject created = Instantiate(emoji, position, Random.rotation);
	}

	private void StartInterval()
	{
		if(LastGenerated+interval < Time.time) // If a second has passed since the last emoji was generated
		{
			CreateEmoji();
			LastGenerated = Time.time;
		}
	}
	// Update is called once per frame
	void Update () {
		Sun.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
		if(!GameOver) StartInterval();
	}
}
