using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {
    public GameObject mPlayer;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PlayerRespawn>().Respawn();
        }
    }
}
