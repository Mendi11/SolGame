using UnityEngine;
using System.Collections;

public class MouseAimCamera : MonoBehaviour
{

    // Variablar
    private Transform mTarget;
    private Transform mPivot;
    private Transform mPlayer;



    [SerializeField]
    private float mSpeedY = 10f;
    [SerializeField]
    private float mMinRotationY = -90;
    [SerializeField]
    private float mMaxRotationY = 90;
    [SerializeField]
    private float mSpeedX = 10f;

    private float mPosY = 0;
    private float mPosX = 0;
    private float mNewRotationY = 0;
    private float mOldRotationY = 0;
    private bool mCloseFar = true;



    




    void Start()
    {
       // Get Tranform from objects.
        mTarget = GameObject.FindGameObjectWithTag("CameraTarget").transform;
        mPivot = GameObject.FindGameObjectWithTag("CameraPivot").transform;
        mPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        //Hämtar x och y pos för spelaren och plusas på.
        mPosY += Input.GetAxis("Mouse Y") * Time.deltaTime * mSpeedY;
        mPosX += Input.GetAxis("Mouse X") * Time.deltaTime * mSpeedX;
        mNewRotationY += mPosY;


        mNewRotationY = Mathf.Clamp(mNewRotationY, mMinRotationY, mMaxRotationY);
        float diffY = mNewRotationY - mOldRotationY;

        //Player rotates after the mouseX movement.
        mPlayer.Rotate(Vector3.up, mPosX);

        //Ändar posen på pivoten och roterar spelaren.
    
        mTarget.RotateAround(mPlayer.position, mPlayer.right, -diffY);


        // Resetar x and y rotationen
        mPosY = 0;
        mPosX = 0;

        // Max and min rotation on Y axis
        mNewRotationY = Mathf.Clamp(mNewRotationY, mMinRotationY, mMaxRotationY);
        mOldRotationY = mNewRotationY;


        if (Input.GetKey(KeyCode.Mouse1))
        {
            // Hold mouse1 and the camera will move foward
            if (mCloseFar == true)
            {
                mPivot.position += mPlayer.forward * 1.5f;
                mCloseFar = false;
            }

        }
        else
        {
            // Release mouse1 and the camera will move backwards
            if (mCloseFar == false)
            {
                mPivot.position -= mPlayer.forward * 1.5f;
                mCloseFar = true;
                mPivot.localPosition = new Vector3(-0.07f, 1.35f, -15f);
            }

        }

  


    }

    void LateUpdate()
    {


       
        // Need to be in late to not lag
        // Sets camera position equal to the pivot.
        transform.position = mPivot.position;
        // Make the camera to look at Target/Crosshair
        transform.LookAt(mTarget);

    }

    
    
    

}