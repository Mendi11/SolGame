using UnityEngine;
using System.Collections;

public class TriggerPad : MonoBehaviour {

    PlattMovement mPlat;
    [SerializeField]
    private int mPlatID;

	// Use this for initialization
	void Start () {
        mPlat = GameObject.FindGameObjectWithTag("Platform").GetComponent<PlattMovement>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (mPlat.PlattOn == true && mPlat.PlattID == mPlatID)
            {
                mPlat.PlattOn = false;
            }
            else if (mPlat.PlattOn == false && mPlat.PlattID == mPlatID)
            {
                mPlat.PlattOn = true;
            }
        }
    }
}
