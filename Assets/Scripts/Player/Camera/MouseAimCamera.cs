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

    private RaycastHit hit;
    private float detectionRadius = 0.15f;
    private string[] maskedTags;
    




    void Start()
    {
       
        mTarget = GameObject.FindGameObjectWithTag("CameraTarget").transform;
     
        mPivot = GameObject.FindGameObjectWithTag("CameraPivot").transform;
        mPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        //maskedTags[0] = "Player";
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

        //Debug.Log(diffY);

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
        transform.LookAt(mTarget);

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

        ////distance between camFollow and camSpot
        //float distFromCamSpot = Vector3.Distance(mTarget.position ,mPivot.position);
        ////distance between camFollow and camera
        //float distFromCamera = Vector3.Distance(mTarget.position, mPivot.position);
       // CameraCollision();


    }

    void LateUpdate()
    {
        //Vad kameran följer
        transform.position = mPivot.position;
        print(mPivot.position);
    }

    void CameraCollision()
    {
        //distance between camFollow and camSpot
        float distFromCamSpot = Vector3.Distance(mPlayer.position,mPivot.position);
        //distance between camFollow and camera
        float distFromCamera = Vector3.Distance(mPlayer.position, mPivot.position);

        //ShereCast from camFollow to camSpot
        if (Physics.SphereCast(mPlayer.position, detectionRadius, mPlayer.forward, out hit, distFromCamSpot))
        {
            //**MAKE SURE YOUR PLAYER IS NOT BETWEEN THE FOCUS-POINT AND CAMERA**
            //get distance betwen camFollow and hitPoint of raycast
            var distFromHit = Vector3.Distance(mPlayer.position, hit.point);
            //if camera is behind an object, immediately put it in front
            if (distFromHit < distFromCamera)
            {
                //if player is ver close to a wall, bring camera inward, 
                //but do not exceed the camFollow's position (dont put camera in front of player)
                bool maskedHit = false;
                //check to see if what we hit was tagged
                
                    if (hit.transform.tag == "Player")
                    {
                        maskedHit = true;
                    }
                
                if (maskedHit == false)
                {
                    if (distFromCamera > 1)
                    {
                        mPivot.position = hit.point + 1 * -mPlayer.forward;
                    }
                    else
                    {
                        mPivot.position = mPlayer.position;
                    }
                }
            }
            else
            {
                //if player is ver close to a wall, bring camera inward, 
                //but do not exceed the camFollow's position (dont put camera in front of player)
                bool maskedHit = false;
                //check to see if what we hit was tagged                
                    if (hit.transform.tag == "Player")
                    {
                        maskedHit = true;
                    }
                
                if (maskedHit == false)
                {
                    if (distFromCamera > 1)
                    {
                        mPivot.position = Vector3.MoveTowards(mPivot.position, hit.point + 1 * -mPlayer.forward, 5 * Time.deltaTime);
                    }
                    else
                    {
                        mPivot.position = Vector3.MoveTowards( mPlayer.position, mPivot.position, 5 * Time.deltaTime);
                    }
                }
            }
        }
        else
        {
            //ease camera back to camSpot
            mPivot.position = Vector3.MoveTowards(mPlayer.position, mPivot.position, 5 * Time.deltaTime);
            
        }
    }
  

}