using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerPad : MonoBehaviour
{
    public Light lt;

    List<PlattMovement> mPlats;

    [SerializeField]
    private int mPlatID;

    CameraShake mShake;

    // Use this for initialization
    void Start()
    {
        mShake = GameObject.FindGameObjectWithTag("CameraPivot").GetComponent<CameraShake>();

        lt = GetComponent<Light>();
        lt.color = Color.red;
        // Load all platfrom on the level and save it in a list.
        mPlats = new List<PlattMovement>();
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject plat in platforms)
        {
            mPlats.Add(plat.GetComponent<PlattMovement>());
           
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player")
        {

            if (lt.color == Color.red)
            {
                lt.color = Color.green;
            }

            foreach (PlattMovement a in mPlats)
            {

                // if the trigger match the id of any in the list it trigger and changes light from red to green.
                // And unfrezzes the position that it is equal too.
                if (a.PlattID == mPlatID && a.PlattOn == false)
                {
                    mShake.Timer = 3f;
                    mShake.ShakCamera = true;
                    a.PlattOn = true;
                    if (a.PlattID == 0)
                    {
                        a.PlattRgb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
                    }
                    if (a.PlattID == 1)
                    {
                        a.PlattRgb.constraints &= ~RigidbodyConstraints.FreezePositionX;

                    }
                    if (a.PlattID == 2 || a.PlattID == 3)
                    {
                        a.PlattRgb.constraints &= ~RigidbodyConstraints.FreezePositionY;

                    }
                }
            }
        }
    }
}
