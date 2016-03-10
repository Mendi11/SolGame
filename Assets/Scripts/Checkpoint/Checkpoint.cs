using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
    [SerializeField]
    private Vector3 mCurrentCheckpoint;
    
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Debug.Log(mCurrentCheckpoint);
            col.GetComponent<PlayerRespawn>().RespawnPoint = transform.position;
        }
    }
}
