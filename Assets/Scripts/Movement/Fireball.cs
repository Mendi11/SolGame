using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    Rigidbody mrgb;
    Transform mtarget;
    private float mspeed = 10;

	// Use this for initialization
	void Start ()
    {
        mtarget = GameObject.FindGameObjectWithTag("CameraTarget").transform;
        mrgb = GetComponent<Rigidbody>();
        Vector3 move = (mtarget.position - transform.position) + new Vector3(0,0,0);
        mrgb.velocity = move * mspeed;

    }
	
	// Update is called once per frame
	void Update ()
    {
        
          
	}
}
