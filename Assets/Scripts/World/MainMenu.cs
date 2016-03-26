using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    GameController mGameController;


    public void ClickedStart()
    {
        mGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {

        mGameController.BallActive = false;
        float mFadeTime = GameObject.Find("GameController").GetComponent<FadeScene>().BeginFade(1);
        yield return new WaitForSeconds(mFadeTime);
        SceneManager.LoadScene(1);
    }
}
