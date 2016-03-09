using UnityEngine;
using System.Collections;

public class MovementTest : MonoBehaviour
{

    public float mSpeed;
    public float mJumpHeight;
    public float mMaxForce;

    private Rigidbody mRgb;

    private int mGrounded = 0;

    void Start()
    {
        mRgb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            for (int i = 0; i < mMaxForce; i++)
            {
                mRgb.AddForce(Vector3.forward * mSpeed);
            }
            mRgb.MovePosition(transform.position + transform.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            for (int i = 0; i < mMaxForce; i++)
            {
                mRgb.AddForce(Vector3.left * mSpeed);
            }
            mRgb.MovePosition(transform.position - transform.right * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            for (int i = 0; i < mMaxForce; i++)
            {
                mRgb.AddForce(Vector3.back * mSpeed);
            }
            mRgb.MovePosition(transform.position - transform.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            for (int i = 0; i < mMaxForce; i++)
            {
                mRgb.AddForce(Vector3.right * mSpeed);
            }
            mRgb.MovePosition(transform.position + transform.right * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && mGrounded > 0)
        {
            //Hoppar upp med force.
            mRgb.AddForce(Vector3.up * mJumpHeight);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            mGrounded += 1;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            mGrounded -= 1;
        }

    }

}
