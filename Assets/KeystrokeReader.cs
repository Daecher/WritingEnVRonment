using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeystrokeReader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        
	}

    private void OnGUI()
    {
        Event e = Event.current;
        if (e != null && e.isKey)
        {
            Debug.Log("The detected keycode is: " + e.keyCode + ". The detected character is: " + e.character);
            Debug.Log(e.character == '\0');
        }
    }
}
