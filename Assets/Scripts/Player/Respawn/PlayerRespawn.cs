using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 mRespawnPoint;
    public Vector3 RespawnPoint
    {
        get { return mRespawnPoint; }
        set { mRespawnPoint = value; }
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Respawn()
    {
        transform.position = RespawnPoint;
    }
}
