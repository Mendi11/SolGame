using UnityEngine;
using System.Collections;


  

public class GameController : MonoBehaviour {

    private bool mBallActive = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool BallActive
    {
        get { return mBallActive; }
        set { mBallActive = value; }

    }

}
