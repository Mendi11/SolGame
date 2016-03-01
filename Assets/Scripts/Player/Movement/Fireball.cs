using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    PlayerMovement mPlayer;
    float mTime;

	// Use this for initialization
	void Start ()
    {

        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        mTime = 10;
    }
	
	// Update is called once per frame
	void Update ()
    {
        mTime -= Time.deltaTime;
        if (mPlayer.DestroyFB == true)
        {
            Destroy(gameObject);
            mPlayer.DestroyFB = false;    
        }
        if (mTime <= 0.5)
        {
            Destroy(gameObject);

        }
        
        
        
          
	}
}
