using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiGenerator : MonoBehaviour {

	public GameObject emoji;
	private float LastGenerated;
	private bool GameOver = false;
	private float interval = 0.2f;
	// Use this for initialization
	void Start () {
		// Parent = GetComponent<
	}

	private int randomModifier {
		get {
			return Random.Range(1, 15);
		}
	}
	
	private void CreateEmoji()
	{
		Vector3 parentPosition = gameObject.transform.position;
		List<int> modifiers = new List<int>();
		Vector3 position = new Vector3(parentPosition.x + randomModifier, parentPosition.y + randomModifier, parentPosition.z + randomModifier);
		GameObject created = Instantiate(emoji, position, gameObject.transform.rotation);
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
		if(!GameOver) StartInterval();
	}
}
