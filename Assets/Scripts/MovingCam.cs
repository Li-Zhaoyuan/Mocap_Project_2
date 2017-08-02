using UnityEngine;
using System.Collections;

public class MovingCam : MonoBehaviour {
    public Transform player1;
    public Transform player2;

    //Camera cam;
    float zDisplacement;
    float xDisplacement;
	// Use this for initialization
	void Start () {
        //cam = GetComponent<Camera>();
        xDisplacement = Mathf.Abs(player1.position.z - player2.position.z);

    }

    // Update is called once per frame
    void Update () {
        zDisplacement = (player1.position.z + player2.position.z) / 2;
      
        if(Mathf.Abs(player1.position.z - player2.position.z) > 2)
            xDisplacement = Mathf.Abs(player1.position.z - player2.position.z);
        transform.position = new Vector3(xDisplacement, transform.position.y, zDisplacement);
    }
}
