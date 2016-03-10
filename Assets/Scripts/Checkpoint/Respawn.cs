using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {
    public GameObject mPlayer;

    void Awake()
    {
        GetComponent<PlayerRespawn>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Invoke("PlayerRespawn.Respawn", 2f);
            //col.GetComponent<PlayerRespawn>().Respawn();
        }
    }
}
