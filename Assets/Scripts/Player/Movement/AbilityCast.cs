using UnityEngine;
using System.Collections;

public class AbilityCast : MonoBehaviour
{
    GameController mGameC;

    [SerializeField]
    private Transform mCanvas;
    [SerializeField]
    private Rigidbody mFireball;
    [SerializeField]
    private Rigidbody mFireballB;
    [SerializeField]
    public Animator mAnim;

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
    private bool mFinishedCast = true;


    void Awake()
    {
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


    


    void LateUpdate()
    {

        // Switch between fireball colors
        if (Input.GetKey(KeyCode.Alpha1))
        {
            mFireBallType[0] = true;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            mFireBallType[1] = true;
        }



        // Fires a projectile by pressing Mouse 1
        if (mGameC.BallActive == true)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) && !mIsCasting && mFinishedCast)
            {

                StartCasting();
                mAnim.SetTrigger("isCast");
                mAnim.SetLayerWeight(1, 1.0f);

                mDestroyFB = true;
                mFinishedCast = false;
            }
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
        }

        // If E is pressed, teleport player to current fireball
        if (Input.GetKey(KeyCode.E))
        {
            if (bulletClone == null)
                return;

            transform.position = bulletClone.position;
            mDestroyFB = true;
        }
    }




    void Bullet(float speed, RaycastHit hit, Rigidbody fire)
    {

        // Find projectile direction through raycast

        Vector3 shootDirection = hit.point - mFireBallSpawn.transform.position;
        Vector3 move = shootDirection.normalized;


        // Create projectile, and fire along planned trajectory

        bulletClone = (Rigidbody)Instantiate(fire, mFireBallSpawn.transform.position, mFireBallSpawn.transform.rotation);
        Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
        bulletClone.velocity = (move * speed) + (Vector3.up * 4);


    }


    void RaycastB()
    {


        // Skapar en raycast som kollar vilken direction raycasten ska träffa.

        RaycastHit hit;
        Vector3 direction = mTarget.position - mPivot.position;
        Ray rayLaser = new Ray(mPivot.position, direction);
        Debug.DrawRay(mPivot.position, direction * 10000);

        if (Physics.Raycast(rayLaser, out hit, 10000))
        {
            if (hit.collider.tag == "Ground" || hit.collider.tag == "Wall" || hit.collider.tag == "Trigger")
            {
                if (mFireBallType[0] == true)
                    Bullet(mBallSpeed, hit, mFireball);

                if (mFireBallType[1] == true)
                    Bullet(mBallSpeed, hit, mFireballB);
            }
        }

    }



    // Cast cycle
    public void StartCasting()
    {
        mBallE = true;

        mIsCasting = true;


        if (bulletClone != null)

        { return; }

        else
        {
            RaycastB();
        }

    }

    public void DoneCasting()
    {
        StartCoroutine(FadeWeight());
        mBallE = false;
        mIsCasting = false;
        mFinishedCast = true;
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

    // Fireball utility
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
}
