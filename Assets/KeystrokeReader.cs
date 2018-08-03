using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        inf.ActivateInputField();
	}

    // Update is called once per frame
    void Update() {
        // Debug.Log(inf.text);
        
        /*foreach(string line in text)
        {
            Debug.Log(line);
        }*/
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

            if (e.keyCode == KeyCode.F1)
            {
                var text = inf.text.Split('\n');
                string testPath = Application.dataPath + "/../ExportedSessions/";
                if (!Directory.Exists(testPath))
                {
                    Directory.CreateDirectory(testPath);
                }
                File.WriteAllLines(testPath + System.DateTime.Now.ToString("dd-MM-yyyy--H-mm-ss") + ".txt", text);
                Debug.Log(System.DateTime.Now.ToString("dd-MM-yyyy--H-mm-ss"));
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
