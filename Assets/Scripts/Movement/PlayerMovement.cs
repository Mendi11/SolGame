using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float mSpeed = 10;
    [SerializeField]
    private Transform canvas;
    [SerializeField]
    private Rigidbody fireball;
    private Transform pivot;
   

    // Use this for initialization
    void Awake()
    {
        pivot = GameObject.FindGameObjectWithTag("CameraPivot").GetComponent<Transform>();
    }

    void Start ()
    {
        if (fireball == null)
            return;
        fireball = GameObject.FindGameObjectWithTag("Fireball").GetComponent<Rigidbody>();
        canvas = GameObject.FindGameObjectWithTag("CanvasOne").GetComponent<Transform>();
        

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fireball == null)
                    return; 

    }

    void Update () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = (false);

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
       
        if (Input.GetKey(KeyCode.Mouse1))
        {
            
            
            canvas.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Rigidbody bulletClone = (Rigidbody)Instantiate(fireball, transform.position, transform.rotation);
                Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
                print("Shoot");
            }
        }
        else
        {
         
            canvas.gameObject.SetActive(false);
            
        }
    }
}
