using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayAnimatic : MonoBehaviour {

    public MovieTexture movie;

    RawImage rawImage;

	// Use this for initialization
	void Start () {
        rawImage = GetComponent<RawImage>();
        PlayMovie();
	}

    void PlayMovie()
    {
        rawImage.texture = movie;
        movie.Play();
    }
}
