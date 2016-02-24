using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float mSpeed = 10;
    [SerializeField]
    private Transform mcanvas;
    [SerializeField]
    private Rigidbody mfireball;
    private Transform mpivot;
    private Rigidbody mrgb;
    private bool mgorund = false;
   

    // Use this for initialization
    void Awake()
    {
        mrgb = GetComponent<Rigidbody>();
        mpivot = GameObject.FindGameObjectWithTag("CameraPivot").GetComponent<Transform>();
        //fireball = GameObject.FindGameObjectWithTag("Fireball").GetComponent<Rigidbody>();
        //canvas = GameObject.FindGameObjectWithTag("CanvasOne").GetComponent<Transform>();
    }

    void Start ()
    {

        if (mfireball == null)
            return;
        
        

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mfireball == null)
                    return; 

    }

    void Update () {
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

        print(mgorund);

    }
    void LateUpdate()
    {

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
        if (Input.GetKeyDown(KeyCode.Space) && mgorund == true)
        {
            mrgb.AddForce(Vector3.up * 200f);
        }
       
        if (Input.GetKey(KeyCode.Mouse1))
        {                     
            mcanvas.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {  
                Rigidbody bulletClone = (Rigidbody)Instantiate(mfireball, transform.position, transform.rotation);
                Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
                print("Shoot");
            }
        }
        else
        {
            mcanvas.gameObject.SetActive(false); 
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            mgorund = true;
        }        
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            mgorund = false;
        }

    }
}
