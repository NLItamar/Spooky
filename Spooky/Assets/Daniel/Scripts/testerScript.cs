using UnityEngine;
using System.Collections;

public class testerScript : MonoBehaviour {

    public GameObject target;
    public Transform testLocation;
    public residentMovement residentMovementScript;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            residentMovementScript.investigate(testLocation.position);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            residentMovementScript.targetRoom = "kitchen";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            residentMovementScript.targetRoom = "lobby";
        }

    }
}
