using UnityEngine;
using System.Collections;


  

public class GameController : MonoBehaviour {

    static GameController mInstance = null;
    [SerializeField]
    private bool mBallActive = false;
    // Use this for initialization
    void Awake()
    {
        // Så den gameobjectet förstörs inte.
        if (mInstance == null)
        {
            mInstance = this;
        }
        else
            DestroyObject(gameObject);

        // Så den gameobjectet förstörs inte.
        DontDestroyOnLoad(gameObject);
    }
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
