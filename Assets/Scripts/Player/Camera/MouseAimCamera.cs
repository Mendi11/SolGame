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
    
    }
    void LateUpdate()
    {
        
        //Hämtar x och y pos för spelaren och plusas på.
        mPosY += Input.GetAxis("Mouse Y") * Time.deltaTime * mSpeedY;
        mPosX += Input.GetAxis("Mouse X") * Time.deltaTime * mSpeedX;

        //Ändar posen på pivoten och roterar spelaren.
        Vector3 move = new Vector3(mTarget.position.x, mPosY, mTarget.position.z);
        mTarget.position = move;
        mPlayer.Rotate(Vector3.up, mPosX);
        // Resetar x rotationen
        mPosX = 0;


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
        


        // Vart kameran ska kolla
        this.transform.LookAt(mTarget);
        //Vad kameran följer
        this.transform.position = mPivot.position;
       

    }

}