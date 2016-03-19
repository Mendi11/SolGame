using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField]
    private string loadLevel;


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        SceneManager.LoadScene(loadLevel);
    }
}
