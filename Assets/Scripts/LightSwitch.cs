using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour
{

    public GameObject mLight;

    // Sets the Light component to false at startup
    void Start ()
    {
        mLight.SetActive(false);
    }
	

    // Sets the light component to false when colliding with Player.tag
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            mLight.SetActive(true);
        }
    }

}
