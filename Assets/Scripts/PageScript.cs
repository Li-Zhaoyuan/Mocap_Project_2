using UnityEngine;
using System.Collections;

public class PageScript : MonoBehaviour {

    public GameObject[] pages;
    int currentPage;

	// Use this for initialization
	void Start ()
    {
        currentPage = 0;
        UpdateCurrentPage();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextPage()
    {
        ++currentPage;
        if (currentPage >= pages.Length) currentPage = 0;

        UpdateCurrentPage();
    }

    void UpdateCurrentPage()
    {
        for (int i = 0; i < pages.Length; ++i)
        {
            pages[i].SetActive(i == currentPage);
        }
    }
}
