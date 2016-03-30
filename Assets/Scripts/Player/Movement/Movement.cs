using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour { 

        
        public float mSpeed;                            // Movement speed 
        private float mXSpeed;          
        private float mYSpeed;

        private int mGrounded = 0;                      // if on the ground
        public float mGravityMultiplier;
        public float mJumpHeight;                       // Jump height               

        private bool mFireBallReload = false; 
        private bool mCalculateJump;                    // Perform jump in FixedUpdate
        private Rigidbody mRgb;                         // Character body

        public Animator mAnim;                          // Player character Animator

        






    void Awake()
    {
        mRgb = GetComponent<Rigidbody>();
        mCalculateJump = false;
    }

    void Start()
    {
        transform.rotation.Set(0,0,0,0);
    }

        void LateUpdate()
    {
        Vector2 velocityAdd = new Vector2(
        Input.GetAxis("Horizontal"),
        Input.GetAxis("Vertical"));

        mXSpeed = Mathf.Lerp(mXSpeed, velocityAdd.x, Time.fixedDeltaTime * 5.0f);
        mYSpeed = Mathf.Lerp(mYSpeed, velocityAdd.y, Time.fixedDeltaTime * 5.0f);

        // Set animation values
        mAnim.SetFloat("forwardSpeed", mYSpeed);
        mAnim.SetFloat("rightSpeed", mXSpeed);

        velocityAdd *= mSpeed;

        // Move the character
        transform.Translate(new Vector3(velocityAdd.x, 0f, velocityAdd.y));

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 rayOrigin = GetComponent<Collider>().bounds.center;
            float rayDistance = GetComponent<Collider>().bounds.extents.y + 0.1f;

            RaycastHit hitInfo;
            Debug.DrawRay(transform.position, Vector3.up, Color.green);

            if (Physics.Raycast(rayOrigin, Vector3.down, out hitInfo, rayDistance) && !mCalculateJump)
            {
                if (hitInfo.collider.tag == "Ground" || hitInfo.collider.tag == "Platform")
                {
                    mCalculateJump = true;
                }
            }
        }



    }

    void FixedUpdate()
    {
        // Calculate jump force
        if (mCalculateJump == true)
        {
            mRgb.AddForce(Vector3.up * mJumpHeight);
            mAnim.SetTrigger("isJump");
            mCalculateJump = false;
        }

        if (mGrounded <= 1)
        {
            HandleAirborneMovement();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Platform")
        {
            mGrounded += 1;
            mFireBallReload = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Platform")
        {
            mGrounded -= 1;
        }

    }

    void HandleAirborneMovement()
    {
        // Apply extra gravity from multiplier:
        Vector3 extraGravityForce = (Physics.gravity * mGravityMultiplier) - Physics.gravity;
        mRgb.AddForce(extraGravityForce);
    }

    public bool FireBallReload
    {
        get { return mFireBallReload;}
        set { mFireBallReload = value; }

    }

}

