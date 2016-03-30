using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    AbilityCast mPlayer;
    private GameObject mCamera;
    float mTime;

    // Use this for initialization
    void Awake()
    {
        
    }

        void Start ()
    {

        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityCast>();
        mTime = 10;
        mCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mCamera.GetComponent<MouseAimCamera>().cameraTarget = "CameraTarget2";
        mCamera.GetComponent<MouseAimCamera>().cameraPivot = "CameraPivot2";
        mCamera.GetComponent<MouseAimCamera>().cameraObject = "Fireball";
    }
	
	// Update is called once per frame
	void Update ()
    {
        mTime -= Time.deltaTime;
        if (mPlayer.DestroyFB == true)
        {
            // mPlayer.DestroyB = false;
            mCamera.GetComponent<MouseAimCamera>().cameraTarget = "CameraTarget";
            mCamera.GetComponent<MouseAimCamera>().cameraPivot = "CameraPivot";
            mCamera.GetComponent<MouseAimCamera>().cameraObject = "Player";

            Destroy(gameObject);
            mPlayer.DestroyFB = false;
            
        }
        if (mTime <= 0.5)
        {
            mPlayer.DestroyB = false;
            Destroy(gameObject);          
        }
        
                                  
	}

    //void OnCollisionEnter()
    //{
    //        Destroy(gameObject);
    //        mPlayer.DestroyFB = false;
    //        mPlayer.mFinishedCast = true;
    //}
}
