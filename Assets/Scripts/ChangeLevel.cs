using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        SceneManager.LoadScene("LEVEL2");
    }
}
