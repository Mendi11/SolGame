using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerPad : MonoBehaviour
{
    public Light lt;
    public Light lt2;


    List<PlattMovement> mPlats;

    [SerializeField]
    private int mPlatID;

    CameraShake mShake;

    // Use this for initialization
    void Start()
    {
        mShake = GameObject.FindGameObjectWithTag("CameraPivot").GetComponent<CameraShake>();

        lt = GetComponent<Light>();
        lt.color = Color.blue;

        lt2 = GameObject.FindGameObjectWithTag("PlatformLight").GetComponent<Light>();
        lt2.color = Color.blue;


        mPlats = new List<PlattMovement>();
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject plat in platforms)
        {
            mPlats.Add(plat.GetComponent<PlattMovement>());
            print("1");
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

            if (lt.color == Color.blue)
            {
                lt.color = Color.green;
                lt2.color = Color.green;
            }


            foreach (PlattMovement a in mPlats)
            {
                if (a.PlattID == mPlatID && a.PlattOn == false)
                {
                    mShake.Timer = 3f;
                    mShake.ShakCamera = true;
                    a.PlattOn = true;
                }
            }
        }
    }
}
