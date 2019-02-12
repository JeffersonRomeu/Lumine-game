using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public GameObject deathMenu;
    public GameObject rewardMenu;
    public GameObject scoreMenu;
    public GameObject player;
    public GameObject phase1;
    public GameObject rebornCollider;
    public GameObject mainCamera;
    public GameObject cenario;
    public GameObject linhaEspiritual;

    private Vector3 cameraInitialPos;
    private Quaternion cameraRotatePos;
    private Vector3 cenarioInitialPos;
    private Vector3 playerInitialPos;

    public static bool deathState;
    private bool rebornState;
    private bool returnControl;
    private bool HasReward = true; // precisa de database

    private float countToReborn = 3;
    private float timer;

    private UIManager uiManager;

    void Start()
    {
        playerInitialPos = player.transform.position;
        cameraInitialPos = mainCamera.transform.position;
        cameraRotatePos = mainCamera.transform.rotation;
        cenarioInitialPos = cenario.transform.position;
        uiManager = FindObjectOfType<UIManager>();  
    }

    void Update ()
    {
        if (deathState)
        {
            Death();
            timer += Time.deltaTime;

            if (timer >= 5)
            {
                timer = 0f;
                deathMenu.SetActive(false);
                deathState = false;
                linhaEspiritual.SetActive(false);

                //fazer todo cenário voltar ao inicio
                mainCamera.transform.position = cameraInitialPos;
                mainCamera.transform.rotation = cameraRotatePos;
                cenario.transform.position = cenarioInitialPos;
                player.transform.position = playerInitialPos;

                if (HasReward)
                {
                    rewardMenu.SetActive(true);
                }
                else
                {
                    scoreMenu.SetActive(true);
                }
            }
        }

        if (rebornState)
        {
            uiManager.StringRebornCount = true;
            uiManager.UpdateCountReborn(countToReborn);
        }

        if (returnControl)
        {
            returnControl = false;
            ScenarioMoving.scenarioMoving = true;
            PlayerControl.ingame = true;
            phase1.GetComponent<EspiritualInPhase>().enabled = true;

            rebornCollider.SetActive(false);
            player.GetComponent<MeshCollider>().enabled = true;
        }
    }

    public void Death ()
    {
        deathMenu.SetActive(true);
        ScenarioMoving.scenarioMoving = false;
        PlayerControl.ingame = false;
        phase1.GetComponent<EspiritualInPhase>().enabled = false;
    }

    public void Reborn()
    {
        //criar if para poder ressucitar se tiver o item
        deathMenu.SetActive(false);
        deathState = false;
        timer = 0f;
        StartCoroutine(getReady());
    }
    // criar função para ressucitar com propaganda

    IEnumerator getReady()
    {
        rebornState = true;

        countToReborn = 3;
        yield return StartCoroutine(WaitForRealSeconds(1f));

        countToReborn = 2;
        yield return StartCoroutine(WaitForRealSeconds(1f));

        countToReborn = 1;
        yield return StartCoroutine(WaitForRealSeconds(1f));

        uiManager.StringRebornCount = false;
        uiManager.UpdateCountReborn(countToReborn);
        rebornState = false;
        countToReborn = 0;

        Time.timeScale = 1;

        returnControl = true;    

        player.GetComponent<MeshCollider>().enabled = false;
        rebornCollider.SetActive(true);
    }

    IEnumerator WaitForRealSeconds(float waitTime)
    {
        float endTime = Time.realtimeSinceStartup + waitTime;

        while (Time.realtimeSinceStartup < endTime)
        {
            yield return null;
        }
    }
}
