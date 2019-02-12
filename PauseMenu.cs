using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    //public static bool GameIsPaused;
    public bool OnResume;
    public GameObject pauseMenu;
    private float countToResume;
    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update () {

        if (OnResume)
        {
            uiManager.StringRebornCount = true;
            uiManager.UpdateCountReborn(countToResume);
        }
    }

    public void Resume ()
    {
        StartCoroutine(getReady());
        pauseMenu.SetActive(false);
    }

    IEnumerator getReady()
    {
        OnResume = true;

        countToResume = 3;
        yield return StartCoroutine(WaitForRealSeconds(1f));

        countToResume = 2;
        yield return StartCoroutine(WaitForRealSeconds(1f));

        countToResume = 1;
        yield return StartCoroutine(WaitForRealSeconds(1f));
        
        uiManager.StringRebornCount = false;
        uiManager.UpdateCountReborn(countToResume);
        OnResume = false;
        countToResume = 0;

        Time.timeScale = 1;
    }

    IEnumerator WaitForRealSeconds(float waitTime)
    {
        float endTime = Time.realtimeSinceStartup + waitTime;

        while (Time.realtimeSinceStartup < endTime)
        {
            yield return null;
        }
    }

    public void Pause ()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        //GameIsPaused = true;
    }

    public void Menu()
    {
        Debug.Log("Foi para o menu...");
    }

    public void Options()
    {
        Debug.Log("Foi para opções");
    }
    
}
