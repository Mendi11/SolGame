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
       // Makes the mouse invisible and lock it to the screen.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = (false);

        // Start the Courotine Startgame.
        StartCoroutine(StartGame());
    }
    public void ClickedQuit()
    {

        // Close the game.
        Application.Quit();

    }

        IEnumerator StartGame()
    {
        // Start fade time. And makes the ball inactive.
        // and starts level 1
        mGameController.BallActive = false;
        float mFadeTime = GameObject.Find("GameController").GetComponent<FadeScene>().BeginFade(1);
        yield return new WaitForSeconds(mFadeTime);
        SceneManager.LoadScene(1);
    }
}
