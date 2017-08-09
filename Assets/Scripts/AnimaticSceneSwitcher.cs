using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimaticSceneSwitcher : MonoBehaviour {
    public SceneSwitcher sceneSwitcher;
    public Animator panningCam;
    public bool isOpening;
    // Use this for initialization
    void Start () {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        panningCam = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //panningCam.GetCurrentAnimatorStateInfo(0).IsTag("End")
        Debug.Log(panningCam.GetCurrentAnimatorStateInfo(0).length);
        if (panningCam.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f || Input.GetKeyDown(KeyCode.Space))
        {
            if (isOpening)
            {
                if (sceneSwitcher.goBack)
                {
                    sceneSwitcher.goBack = false;
                    sceneSwitcher.ChangeScene("MainMenu");
                }
                else
                {
                    sceneSwitcher.ChangeScene("blending_+soundmanager");
                }
            }
            else
            {
                sceneSwitcher.ChangeScene("MainMenu");
            }
        }
	}
}
