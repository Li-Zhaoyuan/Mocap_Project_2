using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    public Image championHP;
    public Image challengerHP;
    public SceneSwitcher sceneSwitcher;
    // Use this for initialization
    void Start () {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();

    }
	
	// Update is called once per frame
	void Update () {
	    if(championHP.fillAmount <= 0)
        {
            sceneSwitcher.ChangeSceneToChallengerFinish();
        }
        else if (challengerHP.fillAmount <= 0)
        {
            sceneSwitcher.ChangeSceneToChampionFinish();
        }

    }
}
