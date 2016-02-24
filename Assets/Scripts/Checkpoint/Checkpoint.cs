using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
    [SerializeField]
    private Vector3 mCurrentCheckpoint;
    
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<PlayerRespawn>().RespawnPoint = transform.position;
        }
    }
}
