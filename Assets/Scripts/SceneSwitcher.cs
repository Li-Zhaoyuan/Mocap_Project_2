﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    public Scene currentScene;
    public Scene prevScene;
    public Scene nextScene;
    public bool goBack = false;

    private void Awake()
    {
        GameObject other = GameObject.Find("scenesystem");
        if (other == null)
        {
            gameObject.name = "scenesystem";
            DontDestroyOnLoad(this);
            //return;
        }
        else
        {
            Destroy(gameObject);
        }
        

    }
    // Use this for initialization
    void Start () {
        
        currentScene = SceneManager.GetActiveScene();
        prevScene = SceneManager.GetActiveScene();
        nextScene = SceneManager.GetActiveScene();
    }
	
    public void ChangeScene(Scene next)
    {
        SceneManager.LoadScene(next.name);
        prevScene = currentScene;
        currentScene = next;
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        prevScene = currentScene;
        currentScene = SceneManager.GetSceneByName(name);
    }

    public void SetGoBackTrue()
    {
        goBack = true;
    }

    public void SetGoBackFalse()
    {
        goBack = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeSceneToChampionFinish()
    {
        int temp = Random.Range(0, 2);
        if(temp == 0)
        {
            SceneManager.LoadScene("Champion_finisherA");
            prevScene = currentScene;
            currentScene = SceneManager.GetSceneByName("Champion_finisherA");
        }
        else
        {
            SceneManager.LoadScene("Champion_FinisherB");
            prevScene = currentScene;
            currentScene = SceneManager.GetSceneByName("Champion_FinisherB");
        }
        
    }
    public void ChangeSceneToChallengerFinish()
    {
        //challenger things not done yet
        int temp = Random.Range(0, 2);
        if (temp == 0)
        {
            SceneManager.LoadScene("Challenger_finisherB");
            prevScene = currentScene;
            currentScene = SceneManager.GetSceneByName("Challenger_finisherB");
        }
        else
        {
            SceneManager.LoadScene("Challenger_finisherA");
            prevScene = currentScene;
            currentScene = SceneManager.GetSceneByName("Challenger_finisherA");
        }

    }
    // Update is called once per frame
    //void Update () {
    //    //if(Input.GetKeyDown(KeyCode.Alpha1))
    //    //   {
    //    //       SceneManager.LoadScene("MainMenu");
    //    //   }
    //    //   else if (Input.GetKeyDown(KeyCode.Alpha2))
    //    //   {
    //    //       SceneManager.LoadScene("Credits");
    //    //   }
    //    //   else if (Input.GetKeyDown(KeyCode.Alpha3))
    //    //   {
    //    //       SceneManager.LoadScene("Animatic_test");
    //    //   }
    //    //   else if (Input.GetKeyDown(KeyCode.Alpha4))
    //    //   {
    //    //       SceneManager.LoadScene("blending_+soundmanager");
    //    //   }
    //   }
}
