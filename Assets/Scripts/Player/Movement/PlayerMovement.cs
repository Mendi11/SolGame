using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    //Variables
    public float mSpeed;
    public float mJumpZ;

    [SerializeField]
    private Transform mCanvas;
    [SerializeField]
    private Rigidbody mFireball;
    [SerializeField]
    private Rigidbody mFireballB;
    [SerializeField]
    public Animator mAnim;

    GameController mGameC;
    [SerializeField]
    private float mBallSpeed;

    private Transform mPivot;
    private Transform mTarget;
    private Rigidbody mRgb;
    Rigidbody bulletClone;
    Transform mFireBallSpawn;

    private bool mDestroyFB = false;
    private bool mBallE = false;
    private bool[] mFireBallType = new bool[5];
    private bool mIsCasting = false;

    private float mTransitionDuration = 0.2f;
    private int mGrounded = 0;


    private float mXSpeed = 0.0f;
    private float mYSpeed = 0.0f;


    void Awake()
    {
        mRgb = GetComponent<Rigidbody>();
        mPivot = GameObject.FindGameObjectWithTag("CameraPivot").GetComponent<Transform>();
        mTarget = GameObject.FindGameObjectWithTag("CameraTarget").GetComponent<Transform>();
        mFireBallSpawn = GameObject.FindGameObjectWithTag("FireBallSpawn").GetComponent<Transform>();
        mGameC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }


    void Start()
    {

        mFireBallType[0] = true;
        mAnim = GetComponent<Animator>();

    }

    void FixedUpdate()//LOLasd
    {

    }


    void Update()
    {

        CursorHide();

        Vector2 velocityAdd = new Vector2(
        Input.GetAxis("Horizontal"),
        Input.GetAxis("Vertical")

    //(Input.GetKey(KeyCode.W) ? 1f : 0f) + (Input.GetKey(KeyCode.S) ? -1f : 0f),
    //(Input.GetKey(KeyCode.D) ? 1f : 0f) + (Input.GetKey(KeyCode.A) ? -1f : 0f)
    );

        mXSpeed = Mathf.Lerp(mXSpeed, velocityAdd.x, Time.deltaTime * 5.0f);
        mYSpeed = Mathf.Lerp(mYSpeed, velocityAdd.y, Time.deltaTime * 5.0f);

        // Set animation values
        mAnim.SetFloat("forwardSpeed", mYSpeed);
        mAnim.SetFloat("rightSpeed", mXSpeed);




        velocityAdd *= mSpeed;

        // Move the character
        transform.Translate(new Vector3(velocityAdd.x, 0f, velocityAdd.y));
    }


    void LateUpdate()
    {




        // Demo character movement
        /*
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(Vector3.back * mSpeed * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(Vector3.left * mSpeed * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(Vector3.right * mSpeed * Time.deltaTime);
                }
        */




        // The player is able to jump by pressing [Space]

        if (Input.GetKeyDown(KeyCode.Space) && mGrounded > 0)
        {
            //Hoppar upp med force.

            mRgb.AddForce(Vector3.up * mJumpZ);

            mAnim.SetTrigger("isJump");
        }



        // Switch between fireball colors

        if (Input.GetKey(KeyCode.Alpha1))
        {
            mFireBallType[0] = true;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            mFireBallType[1] = true;
        }



        // If E is pressed, teleport player to current fireball

        if (Input.GetKey(KeyCode.E))
        {
            if (bulletClone == null)
                return;

            transform.position = bulletClone.position;
            mDestroyFB = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && mBallE == true)
        {
            mDestroyFB = true;
        }



        // Activates/deactivates aim overlay by holding Mouse 2

        if (Input.GetKey(KeyCode.Mouse1))
        {

            mCanvas.gameObject.SetActive(true);
        }

        else
        {
            if (mCanvas == null)
            {
                return;
                    }
            mCanvas.gameObject.SetActive(false);

            //mBallE = false;

        }

        // print(mGameC.BallActive);
        print(mBallE);
        if (mGameC.BallActive == true)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) && !mIsCasting)
            {

                StartCasting();
                mAnim.SetTrigger("isCast");
                mAnim.SetLayerWeight(1, 1.0f);
            }
        }
    }






    // Check if Player.tag is colliding with ground or platform

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Platform")
        {
            mGrounded += 1;
        }
        if (col.gameObject.tag == "Powerup")
        { 
            mGameC.BallActive = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Platform")
        {
            mGrounded -= 1;
        }

    }




    void Bullet(float speed, RaycastHit hit, Rigidbody fire)
    {

        // Find projectile direction through raycast

        Vector3 shootDirection = hit.point - mFireBallSpawn.transform.position;
        Vector3 move = shootDirection.normalized;

        //mAnim.SetLayerWeight(1, 1);
        //mAnim.SetTrigger("isCast");

        // Create projectile, and fire along planned trajectory

        bulletClone = (Rigidbody)Instantiate(fire, mFireBallSpawn.transform.position, mFireBallSpawn.transform.rotation);
        Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
        bulletClone.velocity = (move * speed) + (Vector3.up * 4);


    }


    void CursorHide()
    {


        // Gömmer eller visar musen och låser den i skärm rutan.

        if (Input.GetKeyDown(KeyCode.C))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (false);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = (true);
        }
    }


    void RaycastB()
    {


        // Skapar en raycast som kollar vilken direction raycasten ska träffa.

        RaycastHit hit;
        Vector3 direction = mTarget.position - mPivot.position;
        Ray rayLaser = new Ray(mPivot.position, direction);
        Debug.DrawRay(mPivot.position, direction * 1000);

        if (Physics.Raycast(rayLaser, out hit, 1000))
        {
            if (hit.collider.tag == "Ground" || hit.collider.tag == "Wall" || hit.collider.tag == "Trigger")
            {
                if (mFireBallType[0] == true)
                    Bullet(mBallSpeed, hit, mFireball);

                if (mFireBallType[1] == true)
                    Bullet(mBallSpeed, hit, mFireballB);

                else
                {
                    //Bullet(15, hit, mFireball);
                }
            }
        }

    }




    void RestFireBall()
    {
        for (int i = 0; i < mFireBallType.Length; i++)
        {
            mFireBallType[i] = false;
        }
    }

    public bool DestroyFB
    {
        get { return mDestroyFB; }
        set { mDestroyFB = value; }
    }

    public bool DestroyB
    {
        get { return mBallE; }
        set { mBallE = value; }
    }

    public bool[] FireBallType
    {
        get { return mFireBallType; }
        set { mFireBallType = value; }
    }

    public void StartCasting()
    {
        mBallE = true;
        Debug.Log("Start casting");


        mIsCasting = true;
        

        if (bulletClone != null)

        { return; }

        else
        {
            RaycastB();
        }

    }

    public void DoneCasting()//AdsD
    {

        Debug.Log("Done casting");
        StartCoroutine(FadeWeight());
        mBallE = false;
        mIsCasting = false;
    }


    public IEnumerator FadeWeight()
    {
        float weight = 1.0f;

        while (weight > 0.0f)
        {
            weight -= Time.deltaTime * 2.0f;
            mAnim.SetLayerWeight(1, weight);

            yield return null;
        }

        yield return null;
    }
}
