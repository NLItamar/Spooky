using UnityEngine;
using System.Collections;

public class TempCompleteLevel : MonoBehaviour {

    public GameObject levelComplete;

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.E))
        {
            levelComplete.active = !levelComplete.active;
        }
	}
}
