using UnityEngine;
using System.Collections;

public class MouseAimCamera : MonoBehaviour
{

    // Variablar
    private Transform mTarget;
    private Transform mPivot;
    private Transform mPlayer;
    //private float mRotateSpeed = 3f;
    private float mPosY = 0;
    
    private float mPosX = 0;
    [SerializeField]
    private float mSpeedY = 10f;
    [SerializeField]
    private float mMinRotationY = -90;
    [SerializeField]
    private float mMaxRotationY = 90;
    private float mNewRotationY = 0;
    private float mOldRotationY = 0;
    [SerializeField]
    private float mSpeedX = 10f;
    private bool mCloseFar = true;


    void Start()
    {
        mTarget = GameObject.FindGameObjectWithTag("CameraTarget").transform;
        //transform.parent = target.transform;
        mPivot = GameObject.FindGameObjectWithTag("CameraPivot").transform;
        mPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {


    }
    void Update()
    {
        //Hämtar x och y pos för spelaren och plusas på.
        mPosY += Input.GetAxis("Mouse Y") * Time.deltaTime * mSpeedY;
        mPosX += Input.GetAxis("Mouse X") * Time.deltaTime * mSpeedX;
        mNewRotationY += mPosY;
        //mRotationY += mPosY;
        mNewRotationY = Mathf.Clamp(mNewRotationY, mMinRotationY, mMaxRotationY);
        float diffY = mNewRotationY - mOldRotationY;

        mPlayer.Rotate(Vector3.up, mPosX);

        Debug.Log(diffY);

        //Ändar posen på pivoten och roterar spelaren.
        //if (mNewRotationY >= mMinRotationY && mNewRotationY <= mMaxRotationY)
            mTarget.RotateAround(mPlayer.position, mPlayer.right, -diffY);
        //Vector3 move = new Vector3(mTarget.position.x, mPlayer.position.y + mPosY, mTarget.position.z);
        //mTarget.position = move;

        // Resetar x rotationen
        mPosY = 0;
        mPosX = 0;
        mNewRotationY = Mathf.Clamp(mNewRotationY, mMinRotationY, mMaxRotationY);
        mOldRotationY = mNewRotationY;
        

        // Vart kameran ska kolla
        this.transform.LookAt(mTarget);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (mCloseFar == true)
            {
                mPivot.position += mPlayer.forward * 1.5f;
                mCloseFar = false;
            }

        }
        else
        {
            if (mCloseFar == false)
            {
                mPivot.position -= mPlayer.forward * 1.5f;
                mCloseFar = true;
            }

        }
    }

    void LateUpdate()
    {
        //Vad kameran följer
        this.transform.position = mPivot.position;
    }

}