using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour {

    public Texture2D mFadeOutTexture;
    public float mFadeSpeed;

    private int mDrawDepth = -1000;
    private float mAlpha = 1.0f;
    private int mFadeDir = -1;
	

    // Set background and fade values

    void OnGUI()
    {
        mAlpha += mFadeDir * mFadeSpeed * Time.deltaTime;
        mAlpha = Mathf.Clamp01(mAlpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, mAlpha);
        GUI.depth = mDrawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), mFadeOutTexture);
    }




    public float BeginFade (int direction)
    {
        mFadeDir = direction;
        return (mFadeSpeed);
    }

    void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }
}
