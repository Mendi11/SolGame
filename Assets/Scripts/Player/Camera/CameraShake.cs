using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    
    Transform mPivot;

    bool mResetPos = false;
    bool mIsShakeOn = false;
    Vector3 moriginalCameraPosition;
    float mshakeAmt = 0;
    float mTimer = 3;
    //private Camera mmainCamera;

    void Awake()
    {
        mPivot = GameObject.FindGameObjectWithTag("CameraPivot").transform;
        //moriginalCameraPosition = mPivot.position;

        //mmainCamera = Camera.main;
        mshakeAmt = 0.05f;
        InvokeRepeating("CameeraShake", 0, 0.01f);
        //Invoke("StopShaking", 0.001f);
       

    }

    void CameeraShake()
    {

        if (mshakeAmt > 0 && mIsShakeOn == true)
        {
            float quakeAmt = Random.value * mshakeAmt * 2 - mshakeAmt;
            Vector3 pp = mPivot.position;
            pp.y += quakeAmt; // can also add to x and/or z
            pp.x += quakeAmt;
            mPivot.position = pp;
            if (mTimer <= 0.5f)
            {
                mIsShakeOn = false;
                mResetPos = true;
            }
        }
    }

    void Update()
    {
        mTimer -= Time.deltaTime;
        if (mResetPos == true)
        {
            mPivot.localPosition = new Vector3(-0.07f, 1.35f, -13f);
            mResetPos = false;

        }
    }
    void StopShaking()
    {
        
        CancelInvoke("CameeraShake");
       // mPivot.position = moriginalCameraPosition;
        //mIsShakeOn = false;

    }

    public bool ShakCamera
    {
        get { return mIsShakeOn; }
        set { mIsShakeOn = value; }

    }
    public float Timer
    {
        get { return mTimer; }
        set { mTimer = value; }

    }

}