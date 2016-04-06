using UnityEngine;
using System.Collections;


  

public class GameController : MonoBehaviour {

    GameController mGameC;
    static GameController mInstance = null;

    [SerializeField]
    private bool mBallActive = false;



    void Awake()
    {
        mGameC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        // GameObject do not destroy.
        if (mInstance == null)
        {
            mInstance = this;
        }
        else
            DestroyObject(gameObject);

        // GameObject do not destroy.
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        CursorHide();


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = (true);


        }
    }


    public bool BallActive
    {
        get { return mBallActive; }
        set { mBallActive = value; }

    }


    // Activate cast ability
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Powerup")
        {
            mGameC.BallActive = true;
        }
    }

    void CursorHide()
    {


        // Toggle show/hide mouse cursor

        if (Input.GetKeyDown(KeyCode.C))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (false);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = (true);
        }
    }

}
