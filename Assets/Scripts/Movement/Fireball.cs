using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    Rigidbody rgb;
    Transform target;

	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("CameraTarget").transform;
        rgb = GetComponent<Rigidbody>();
        Vector3 move = target.position - transform.position;
        rgb.velocity = move * 10;

    }
	
	// Update is called once per frame
	void Update ()
    {
        
          
	}
}
