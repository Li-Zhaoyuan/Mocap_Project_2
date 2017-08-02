using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAnimatic : MonoBehaviour {

    public MovieTexture StartingMovie;
    public MovieTexture ChampionWin1;
    public MovieTexture ChampionWin2;
    public MovieTexture ChallengerWin1;
    public MovieTexture ChallengerWin2;

    MovieTexture CurrentMovie;
    RawImage rawImage;
    string nextSceneName = "MainMenu";

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        //rawImage = GetComponent<RawImage>();
        //PlayMovie();
	}
    void Update()
    {
        if(rawImage == null)
        {
            rawImage = FindObjectOfType<RawImage>();
        }
        if(!CurrentMovie.isPlaying)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }


    public void PlayStartingMovie(string SceneToTransitTo)
    {
        rawImage.texture = StartingMovie;
        CurrentMovie = StartingMovie;
        CurrentMovie.Play();
        nextSceneName = SceneToTransitTo;
    }

    public void PlayChampionWin(string SceneToTransitTo)
    {
        int rand = Random.Range(1, 2);
        if (rand == 1)
        {
            rawImage.texture = ChampionWin1;
            CurrentMovie = ChampionWin1;
        }
        else
        {
            rawImage.texture = ChampionWin2;
            CurrentMovie = ChampionWin2;
        }
        CurrentMovie.Play();
        nextSceneName = SceneToTransitTo;
    }

    public void PlayChallengerWin(string SceneToTransitTo)
    {
        int rand = Random.Range(1, 2);
        if (rand == 1)
        {
            rawImage.texture = ChallengerWin1;
            CurrentMovie = ChallengerWin1;
        }
        else
        {
            rawImage.texture = ChallengerWin2;
            CurrentMovie = ChallengerWin1;
        }
        CurrentMovie.Play();
        nextSceneName = SceneToTransitTo;
    }
}
