using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

    Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Highlight()
    {
        text.color = Color.white;
    }

    public void StopHighlight()
    {
        text.color = new Color(56.0f / 255.0f, 56.0f / 255.0f, 56.0f / 255.0f, 1);
    }

    public void Click()
    {
        if (gameObject.name == "Retry Text") {
            Application.LoadLevel("Game");
        }
        else if (gameObject.name == "Exit Text") {
            Application.LoadLevel("Menu");
        }

    }
}
