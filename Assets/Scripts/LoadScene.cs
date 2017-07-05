using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName = "";
    private float timer = 0;
    private bool startCountdown = false;

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
        SceneManager.LoadScene(sceneName);
    }

    public void OnClick()
    {
        startCountdown = true;
    }
}
