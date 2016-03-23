using UnityEngine;
using System.Collections;

public class FadeInScene : MonoBehaviour {

    public void ClickedStart()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        float mFadeTime = GameObject.Find("GameController").GetComponent<FadeScene>().BeginFade(-1);
        yield return new WaitForSeconds(mFadeTime);
    }
}
