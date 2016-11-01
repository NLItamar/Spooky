using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

    public bool clicked;
    public bool clickable;

    bool originalForm; // bool to keep track of the current state of the object so you can toggle easily
    
	void Start () {
        clickable = false;
        clicked = false;
        originalForm = true;
	}
	
	void FixedUpdate () {
	    if (clicked)
        {
            if (gameObject.name == "Left Door" || gameObject.name == "Right Door")
            {
                doubleDoorInteraction();
            }
            if (gameObject.name == "Single Door")
            {
                singleDoorInteraction();
            }
        }

        clickable = false;
        clicked = false;
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && clickable)
        {
            clicked = true;
        }
    }

    void singleDoorInteraction()
    {
        if (originalForm)
        {
            gameObject.transform.Rotate(0, 90, 0);
            originalForm = !originalForm;
        } else {
            gameObject.transform.Rotate(0, -90, 0);
            originalForm = !originalForm;
        }
    }
    void doubleDoorInteraction()
    {
        if (originalForm)
        {
            transform.parent.gameObject.transform.FindChild("Left Door").gameObject.transform.Rotate(0, 90, 0);
            transform.parent.gameObject.transform.FindChild("Right Door").gameObject.transform.Rotate(0, -90, 0);
            originalForm = false;
        }
        else
        {
            transform.parent.gameObject.transform.FindChild("Left Door").gameObject.transform.Rotate(0, -90, 0);
            transform.parent.gameObject.transform.FindChild("Right Door").gameObject.transform.Rotate(0, 90, 0);
            originalForm = true;
        }
    }
}
