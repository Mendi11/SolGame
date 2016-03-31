using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    GameController mGameController;

    void Start()
    {
        mGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }

    public void ClickedStart()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = (false);
        StartCoroutine(StartGame());
    }
    public void ClickedQuit()
    {
        Application.Quit();

    }

        IEnumerator StartGame()
    {

        mGameController.BallActive = false;
        float mFadeTime = GameObject.Find("GameController").GetComponent<FadeScene>().BeginFade(1);
        yield return new WaitForSeconds(mFadeTime);
        SceneManager.LoadScene(1);
    }
}
