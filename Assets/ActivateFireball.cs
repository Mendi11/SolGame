using UnityEngine;
using System.Collections;

public class ActivateFireball : MonoBehaviour
{

	void Start ()
    {
	
	}
	

	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
