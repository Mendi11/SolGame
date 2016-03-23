using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 mRespawnPoint;

    // Initiate respawn value
    public Vector3 RespawnPoint
        {
            get { return mRespawnPoint; }
            set { mRespawnPoint = value; }
        }


    // Sets Player checkpoint to spawn position
	void Start ()
        {
            mRespawnPoint = transform.position;
	    }


    // Sets Player checkpoint to mCurrentCheckpoint position
    public void Respawn()
        {
            transform.rotation = new Quaternion(0,0,0,0);
          
            transform.position = RespawnPoint;
        }
}
