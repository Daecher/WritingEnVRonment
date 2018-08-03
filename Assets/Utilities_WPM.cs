using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Utilities_WPM : MonoBehaviour {

    public Text WPMText;
    public Text Timer;

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
		WPM = Mathf.Round(keystrokes / (currentTime / 60f) * 20f) / 100f;
        WPMText.text = "WPM: " + Mathf.RoundToInt(WPM);
        Timer.text = "Session Time: " + Mathf.RoundToInt(currentTime / 60) + ":" + Mathf.RoundToInt(currentTime % 60);

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
