using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour
{
    [SerializeField]
    private Light mLight;

	// Use this for initialization
	void Start ()
    {
        mLight = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            mLight.enabled = false;
        }
    }

}
