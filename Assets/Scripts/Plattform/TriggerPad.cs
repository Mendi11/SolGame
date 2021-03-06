﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerPad : MonoBehaviour
{

    List<PlattMovement> mPlats;

    [SerializeField]
    private int mPlatID;

    // Use this for initialization
    void Start()
    {
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
            //if (b.IsMoving == true)
            //{
            //    return;
            //}
            //else if(b.IsMoving == false)
            //{
                if (col.gameObject.tag == "Player")
                {
                    foreach (PlattMovement a in mPlats)
                    {
                        if (a.PlattID == mPlatID && a.PlattOn == true)
                        {
                            a.PlattOn = false;

                        }
                        else if (a.PlattID == mPlatID && a.PlattOn == false)
                        {
                            a.PlattOn = true;
                        }
                    }
                }                  
    }
}
