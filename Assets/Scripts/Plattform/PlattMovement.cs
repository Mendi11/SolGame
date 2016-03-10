using UnityEngine;
using System.Collections;

public class PlattMovement : MonoBehaviour {


    private Rigidbody mPlattRgb;
    [SerializeField]
    private float mPosX = 0;
    [SerializeField]
    private float mPosY = 0;
    [SerializeField]
    private float mPosZ = 0;
    [SerializeField]
    private float mEPosX = 0;
    [SerializeField]
    private float mEPosY = 0;
    [SerializeField]
    private float mEPosZ = 0;
    [SerializeField]
    private bool mOn = true;
    [SerializeField]
    private int mPlatID = 0;



    Vector3 mMove;
    Vector3 mStartPos;
    private bool mDownUp = true;
    private bool mLeftRight = true;
    private bool mFowardBack = true;
    // Use this for initialization
    void Start ()
    {
        mPlattRgb = GetComponent<Rigidbody>();
        mStartPos = mPlattRgb.position;
        mPlattRgb.position += new Vector3(1, 1, 1);
    }
	
	// Update is called once per frame
	void Update ()
    {
       
            if (mPlattRgb.position.y >= mEPosY && mDownUp == true)
            {
            mPosY = mPosY * -1;
            mDownUp = false;
                }
        else if (mPlattRgb.position.y <= (mStartPos.y - 0.5) && mDownUp == false)
        {
            mPosY = mPosY * -1;
            mDownUp = true;

        }
        if (mPlattRgb.position.x >= mEPosX && mLeftRight == true)
        {
            mPosX = mPosX * -1;
            mLeftRight = false;
        }
        else if (mPlattRgb.position.x <= (mStartPos.y - 0.5) && mLeftRight == false)
        {
            mPosX = mPosX * -1;
            mLeftRight = true;

        }
        if (mPlattRgb.position.z >= mEPosZ && mFowardBack == true)
        {
            mPosZ = mPosZ * -1;
            mFowardBack = false;
        }
        else if (mPlattRgb.position.z <= (mStartPos.y - 0.5) && mFowardBack == false)
        {
            mPosZ = mPosZ * -1;
            mFowardBack = true;
        }



        if (mOn == true)
        {
            mMove = new Vector3(mPosX, mPosY, mPosZ);
            mPlattRgb.velocity = mMove;
        }
        else if (mOn == false)
        {
            mMove = new Vector3(0, 0, 0);
            mPlattRgb.velocity = mMove;

        }
    }

    public bool PlattOn
    {
        get { return mOn; }
        set { mOn = value; }

    }
    public int PlattID
    {
        get { return mPlatID; }
        set { mPlatID = value; }

    }
}
