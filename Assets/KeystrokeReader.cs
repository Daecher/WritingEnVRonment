using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeystrokeReader : MonoBehaviour {

    [SerializeField]
    Transform keyboard;
    [SerializeField]
    InputField inf;

	// Use this for initialization
	void Start () {
        //EventSystem.current.SetSelectedGameObject(inf.gameObject, null);
        //inf.OnPointerClick(new PointerEventData(EventSystem.current));
        //inf.ActivateInputField();
	}

    // Update is called once per frame
    void Update() {
        
	}

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown)
        {
            //if (e.keyCode == KeyCode.None) Debug.Log("The detected character is: " + e.character);
            //if (e.character == '\0') Debug.Log("The detected keycode is: " + e.keyCode);
            foreach (Transform key in keyboard)
            {
                if (key.name == e.keyCode.ToString())
                {
                    key.gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
                    //key.position = new Vector3(key.position.x, key.position.y - 0.01f, key.position.z);
                }
            }

            //Debug.Log("The detected keycode is: " + e.keyCode + ". The detected character is: " + e.character);
            //Debug.Log(e.character == '\0');
        }
        else if (e.type == EventType.KeyUp)
        {
            foreach (Transform key in keyboard)
            {
                if (key.name == e.keyCode.ToString())
                {
                    key.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                    //key.position = new Vector3(key.position.x, key.position.y + 0.01f, key.position.z);
                }
            }
        }
        else if (e.shift)
        {
            //Debug.Log(e.character + " " + e.keyCode);
        }
    }
}
