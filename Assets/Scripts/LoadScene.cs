using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName = "";
    private float timer = 0;
    private bool startCountdown = false;

    private SceneSwitcher sceneSwitcher;

    void Start()
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
    }

    void Update()
    {
        if (startCountdown)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
                ChangeSceneOnClick();
        }
    }

    public void ChangeSceneOnClick()
    {
        //SceneManager.LoadScene(sceneName);
        sceneSwitcher.ChangeScene((sceneName));
    }

    public void OnClick()
    {
        startCountdown = true;
    }
}
