using UnityEngine;
using System.Collections;

public class ActivateFireball : MonoBehaviour
{
    GameController mGameC;
    public GameObject mLight;

    void Start ()
    {
        mGameC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //mLight.SetActive(false);
    }
	

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            mGameC.BallActive = true;
            mLight.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
