using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private string loadLevel;


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            StartCoroutine(StartGame());
        }
    }

    IEnumerator StartGame()
    {
        float mFadeTime = GameObject.Find("GameController").GetComponent<FadeScene>().BeginFade(1);
        yield return new WaitForSeconds(mFadeTime);
        SceneManager.LoadScene(loadLevel);
    }
}
