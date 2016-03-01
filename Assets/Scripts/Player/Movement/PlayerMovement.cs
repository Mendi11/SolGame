using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    //Variablar
    public float mSpeed = 10;


    [SerializeField]
    private Transform mCanvas;
    [SerializeField]
    private Rigidbody mFireball;
    [SerializeField]
    private Rigidbody mFireballB;

    private Transform mPivot;
    private Transform mTarget;
    private Rigidbody mRgb;
    private int mGorund = 0;
    Rigidbody bulletClone;
    private bool mDestroyFB = false;
    private bool mBallE = false;
    private bool[] mFireBallType = new bool[5];
    //float mPosX;




    // Use this for initialization
    void Awake()
    {
        mRgb = GetComponent<Rigidbody>();
        mPivot = GameObject.FindGameObjectWithTag("CameraPivot").GetComponent<Transform>();
        mTarget = GameObject.FindGameObjectWithTag("CameraTarget").GetComponent<Transform>();
    }

    void Start ()
    {
       // mFireball = GameObject.FindGameObjectWithTag("FireballB").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (mFireball == null)
        //            return; 

    }

    void Update () {

        CursorHide();
        print(mGorund);
    }
    void LateUpdate()
    {
        
        // Movment.
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
        if (Input.GetKeyDown(KeyCode.Space) && mGorund > 0)
        {
            //Hoppar upp med force.
            mRgb.AddForce(Vector3.up * 200f);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            mFireBallType[0] = true;

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            mFireBallType[1] = true;

        }
        if (Input.GetKey(KeyCode.E))
        {
            if (bulletClone == null)
                return;
            transform.position = bulletClone.position;
            mDestroyFB = true;
            mBallE = false;

        }
        
        if (Input.GetKey(KeyCode.Mouse1))
        {            
            //Canvas ska vara ture om man håller högers mus knapp
            mCanvas.gameObject.SetActive(true);
           
            if (Input.GetKeyDown(KeyCode.Mouse0) && mBallE == true)
            {
                mDestroyFB = true;
                mBallE = false;

            }
        }
    
        else
        {
            //Canvas ska vara false om man inte håller höger mus knapp
            mCanvas.gameObject.SetActive(false);
            mBallE = false;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            mBallE = true;
            //Vector3 shootDirection = hit.point - transform.position;
            if (bulletClone != null)
            { return; }
            else
            {
                RaycastB();

            }
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            mGorund += 1;
        }        
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            mGorund -= 1;
        }

    }
    void Bullet(float speed, RaycastHit hit, Rigidbody fire)
    {

        //Raycast hittar vad den kolliderar med hämtar positionen den kolliderar med.
        //Skjuter mot positionen. Skapar 
        Vector3 shootDirection = hit.point - transform.position;
        Vector3 move = shootDirection.normalized; 
        bulletClone = (Rigidbody)Instantiate(fire, transform.position, transform.rotation);
        Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
        bulletClone.velocity = (move * speed) + (Vector3.up * 5);

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
            if (hit.collider.tag == "Ground" || hit.collider.tag == "Wall")
            {
                if(mFireBallType[0] == true)
                    Bullet(15, hit,mFireball);
                if (mFireBallType[1] == true)
                    Bullet(15, hit, mFireballB);
                else
                {
                    Bullet(15, hit, mFireball);
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
    public bool[] FireBallType
    {
        get { return mFireBallType; }
        set { mFireBallType = value; }
    }
}
