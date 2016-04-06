using UnityEngine;
using System.Collections;

public class FadeInScene : MonoBehaviour {

    public void ClickedStart()
    {
        StartCoroutine(StartGame());
    }


    // Face in scene from white background

    IEnumerator StartGame()
    {
        float mFadeTime = GameObject.Find("GameController").GetComponent<FadeScene>().BeginFade(-1);
        yield return new WaitForSeconds(mFadeTime);
    }
}
