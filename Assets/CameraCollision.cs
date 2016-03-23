using UnityEngine;
using System.Collections;

public class CameraCollision : MonoBehaviour {

    private bool mCameraCollision = false;
    private int mCollisionTimes = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        //if (mCollisionTimes >= 0)
        //{
            
        //}
        //if (mCollisionTimes <= 0)
        //{
        //    if(transform.position.z != -4.06)
        //        transform.position += new Vector3(-0.209f, 2.25f, -4.06f);
        //}

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Wall")
        {
            if (transform.position.z != -0.5)
                transform.position += new Vector3(0, 0, 0.5f);
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Wall")
        {
            if (transform.position.z != -0.5)
                transform.position += new Vector3(0, 0, -0.5f);
        }

    }
}
