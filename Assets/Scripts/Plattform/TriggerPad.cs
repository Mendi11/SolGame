using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerPad : MonoBehaviour
{
    public Light lt;

    List<PlattMovement> mPlats;

    [SerializeField]
    private int mPlatID;

    // Use this for initialization
    void Start()
    {

        lt = GetComponent<Light>();
        lt.color = Color.blue;
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

                    if (lt.color == Color.blue)
                    {
                        lt.color = Color.green;
                    }
                    else if (lt.color == Color.green)
                    {
                        lt.color = Color.blue;
                    }

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
