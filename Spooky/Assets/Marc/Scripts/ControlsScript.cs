using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlsScript : MonoBehaviour {

    public Button back;

    void Start ()
    {
        back.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
