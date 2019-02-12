using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject missionsMenu;
    public GameObject challengesMenu;
    public GameObject shopMenu;
    //public GameObject options;
    public GameObject mainCamera;

    private Animator cameraAnim;

    private bool startCount;
    private float countToControl;

    void Start ()
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

    //Buttons In MainMenu-------------------------------------------------------------

    public void TouchToPlay()
    {
        mainMenu.SetActive(false);
        cameraAnim.Play("cameraMoving");
        startCount = true;
        ScenarioMoving.scenarioMoving = true;
    }

    public void Missions()
    {
        mainMenu.SetActive(false);
        missionsMenu.SetActive(true);
    }

    public void Challenges()
    {
        mainMenu.SetActive(false);
        challengesMenu.SetActive(true);
    }

    public void Shop()
    {
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        //optionsMenu.SetActive(true);
    }

    //Buttons in Missions Menu---------------------------------------------------

    public void homeInMissions()
    {
        missionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void challengesInMissions()
    {
        missionsMenu.SetActive(false);
        challengesMenu.SetActive(true);
    }

    public void ShopInMissions()
    {
        missionsMenu.SetActive(false);
        shopMenu.SetActive(true);
    }

    //Buttons in Challenges Menu--------------------------------------------------

    public void homeInChallenges()
    {
        challengesMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void missionsInChallenge()
    {
        challengesMenu.SetActive(false);
        missionsMenu.SetActive(true);
    }

    public void shopInChallenge()
    {
        challengesMenu.SetActive(false);
        shopMenu.SetActive(true);
    }

    //Buttons in Shop Menu------------------------------------------------------

    public void homeInShop()
    {
        shopMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void missionsInShop()
    {
        shopMenu.SetActive(false);
        missionsMenu.SetActive(true);
    }

    public void challengesInShop()
    {
        shopMenu.SetActive(false);
        challengesMenu.SetActive(true);
    }
}
