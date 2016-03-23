﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void ClickedStart()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        float mFadeTime = GameObject.Find("GameController").GetComponent<FadeScene>().BeginFade(1);
        yield return new WaitForSeconds(mFadeTime);
        SceneManager.LoadScene(1);
    }
}
