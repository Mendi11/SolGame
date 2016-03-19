using UnityEngine;
using System.Collections;

public class FireTrigger : MonoBehaviour {


    PlayerMovement player;
    [SerializeField]
    private int mFireBallTrigger;
    //fireBallSelect är vilke fireball de ska vara
   // 0 = FireballRed
    // 1 = fireballBlue 

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (mFireBallTrigger == 0)
            {
                RestFireBall();
                player.FireBallType[mFireBallTrigger] = true;
            }
            if (mFireBallTrigger == 1)
            {
                RestFireBall();
                player.FireBallType[mFireBallTrigger] = true;
            }

        }
    }
    void RestFireBall()
    {
        for (int i = 0; i < player.FireBallType.Length; i++)
        {
            player.FireBallType[i] = false;
        }
    }
}
