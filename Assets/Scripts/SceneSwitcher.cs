using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Credits");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Animatic_test");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("blending_+soundmanager");
        }
    }
}
