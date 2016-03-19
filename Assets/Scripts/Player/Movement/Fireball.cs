using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    AbilityCast mPlayer;
    float mTime;

    // Use this for initialization
    void Awake()
    {
        
    }

        void Start ()
    {

        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityCast>();
        mTime = 10;
    }
	
	// Update is called once per frame
	void Update ()
    {
        mTime -= Time.deltaTime;
        if (mPlayer.DestroyFB == true)
        {
           // mPlayer.DestroyB = false;
            Destroy(gameObject);
            mPlayer.DestroyFB = false;
            
        }
        if (mTime <= 0.5)
        {
            mPlayer.DestroyB = false;
            Destroy(gameObject);          
        }               
                 
	}
}
