using UnityEngine;
using System.Collections;

public class PlattMovement : MonoBehaviour {


   

    // In unity you set the speed/direction och set the end postion.
    [SerializeField]
    private float mDirSpeedX = 0;
    [SerializeField]
    private float mDirSpeedY = 0;
    [SerializeField]
    private float mDirSpeedZ = 0;
    [SerializeField]
    private float mEndPosX = 0;
    [SerializeField]
    private float mEndPosY = 0;
    [SerializeField]
    private float mEndPosZ = 0;
    [SerializeField]
    private int mPlatID = 0;
    [SerializeField]
    private bool mOn = true;
    [SerializeField]
    private bool mLoop = true;

    // Variablar
    private Rigidbody mPlattRgb;
    private bool mIsMoving = false;
    Vector3 mMove;
    Vector3 mStartPos;
    private bool mDownUpDir = true;
    private bool mLeftRightDir = true;
    private bool mFowardBackDir = true;
    // Use this for initialization
  
    void Start()
    {
        mPlattRgb = GetComponent<Rigidbody>();
        mStartPos = mPlattRgb.position;
        mPlattRgb.position += new Vector3(1, 1, 1);
        // Move po
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get wich direction it should move.
        mDirSpeedX = Platform(mEndPosX, mDirSpeedX, mLeftRightDir, mPlattRgb.position.x, mStartPos.x,"x");
        mDirSpeedY = Platform(mEndPosY, mDirSpeedY, mDownUpDir, mPlattRgb.position.y, mStartPos.y, "y");
        mDirSpeedZ = Platform(mEndPosZ, mDirSpeedZ, mFowardBackDir, mPlattRgb.position.z, mStartPos.z,"z");
        if (mOn == true)
        {
            //if mOn is true.Then its should move at the direction it has.
            mMove = new Vector3(mDirSpeedX, mDirSpeedY, mDirSpeedZ);
            mPlattRgb.velocity = mMove;
            mIsMoving = true;
           // mPlattRgb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        }
        else if (mOn == false)
        {
            //if mOn is false Then its should stay still.
            mMove = new Vector3(0, 0, 0);
            mPlattRgb.velocity = mMove;
            mIsMoving = false;
            mPlattRgb.constraints = RigidbodyConstraints.FreezeAll;

        }
    }

    //Get and setters.
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

    float Platform(float maxPos , float speedDir, bool dir, float platform,float startPos,string xyz)
    {
        //Get the platforms position and check it if its greater than maxPos.
        if (platform >= maxPos && dir == true)
        {
            // Make the direction negetiv or positiv
            speedDir = speedDir * -1;
            dir = false;
            if (mLoop == false)
            {
                mOn = false;
            }
        }
        else if (platform <= (startPos - 0.5) && dir == false)
        {
            // Make the direction negetiv or positiv
            speedDir = speedDir * -1;
            dir = true;
            if (mLoop == false)
            {
                mOn = false;
            }
        }
        Direction(xyz,dir);

        return speedDir;
    }
    void Direction(string xyz,bool dir)
        {
        if (xyz == "x")
        {
            mLeftRightDir = dir;
            
        }
        else if (xyz == "y")
        {
            mDownUpDir = dir;
        }
        else if (xyz == "z")
        {
            mFowardBackDir = dir;

        }

    }

    public bool IsMoving
    {
        get { return mIsMoving; }
    }
    public bool Loop
    {
        get { return mLoop; }

    }
    public Rigidbody PlattRgb
    {
        get { return mPlattRgb; }
        set { mPlattRgb = value; }

    }

}
