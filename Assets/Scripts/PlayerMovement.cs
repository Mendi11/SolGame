using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody pRdb;

	// Use this for initialization
	void Start () {
        pRdb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);


        Vector3 vel = pRdb.velocity;
        vel = move.normalized;
        pRdb.velocity = vel * 2f;
   

	
	}
}
