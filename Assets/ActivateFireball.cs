using UnityEngine;
using System.Collections;

public class ActivateFireball : MonoBehaviour
{

    public GameObject mLight;

    void Start ()
    {
        mLight.SetActive(false);
    }
	

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            mLight.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
