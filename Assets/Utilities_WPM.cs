using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities_WPM : MonoBehaviour {
	
	[SerializeField]
	int keystrokes;
	[SerializeField]
	float currentTime = 0f;
	[SerializeField]
	float WPM = 0f;
	
	float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime = Time.time - startTime;
		WPM = keystrokes / (currentTime / 60f) / 5f;
	}
	
	private void OnGUI()
	{
		Event e = Event.current;
        if (e.type == EventType.KeyDown)
        {
			if (e.character  != '\0') keystrokes++;
		}
	}
}
