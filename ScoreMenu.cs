using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMenu : MonoBehaviour {

    public GameObject scoreMenu;
    public GameObject mainMenu;
    public GameObject mainCamera;
    private bool startCount;
    private float countToControl;

    private Animator cameraAnim;

    private void Start()
    {
        cameraAnim = mainCamera.GetComponent<Animator>();
    }

    void Update () {
        if (startCount)
        {
            countToControl += Time.deltaTime;

            if (countToControl >= 2f)
            {
                PlayerControl.ingame = true;
                startCount = false;
                countToControl = 0f;
                cameraAnim.Play("baseAnim");
            }
        }
	}

    public void PlayAgain()
    {
        scoreMenu.SetActive(false);
        cameraAnim.Play("cameraMoving");
        startCount = true;
        ScenarioMoving.scenarioMoving = true;
    }

    public void Home()
    {
        scoreMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
