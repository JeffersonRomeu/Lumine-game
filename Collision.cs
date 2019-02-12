using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public GameObject[] Life;
    public static Light insideLight;
    public bool inLinhaEspiritual;
    public static bool Special;
    public static bool inSpecial;

    public Transform player;
    public Transform nuvem1;
    public Transform nuvem2;

    private Vector3 PlayerRespawn;
    private Vector3 nuvem1Respawn;
    private Vector3 nuvem2Respawn;

    private UIManager uiManager;
    private Pesadelos pesadelos;
    private int coins;

    private float playerLife;

    private void Start()
    {
        insideLight = this.GetComponentInChildren<Light>();
        nuvem1Respawn = nuvem1.transform.position;
        nuvem2Respawn = nuvem2.transform.position;
        PlayerRespawn = player.transform.position;

        uiManager = FindObjectOfType<UIManager>();
        pesadelos = FindObjectOfType<Pesadelos>();
    }

    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "LinhaEspiritual")
        {
            inLinhaEspiritual = true;
            insideLight.intensity += 0.01f;
            //Debug.Log("Luz em " + insideLight.intensity);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            uiManager.UpdateCoins(coins);
            other.gameObject.SetActive(false);
        }

       if (other.gameObject.tag == "Obstacle")
       {
            DeathMenu.deathState = true;
            // criar função de diminuir a vida ao colidir
       }

       if (other.gameObject.tag == "LinhaEspiritual")
       {
            inLinhaEspiritual = true;
       }

        if (other.gameObject.tag == "Inimigos")
        {
            if (!inSpecial)
            {
                playerLife--;
                Debug.Log("A vida esta em " + playerLife);

                if (playerLife < 0)
                {
                    nuvem1.transform.position = nuvem1Respawn;
                    nuvem2.transform.position = nuvem2Respawn;
                    player.transform.position = PlayerRespawn;
                    pesadelos.PositionatePesadelos();

                    playerLife = 0;
                    insideLight.intensity = 0;
                    DeathMenu.deathState = true;
                }
            }
            else
            {
                playerLife++;
                Life[0].SetActive (true);
                Debug.Log("A vida esta em " + playerLife);

                other.gameObject.SetActive(false);
            }
        }
    }

    public void Update()
    {
        if (insideLight.intensity >= 2f)
        {
            insideLight.intensity = 2f;
            Special = true;
        }
        ShowLife();
    }

    public void ShowLife()
    {
        if (playerLife == 0)
        {
            Life[0].SetActive(false);
        }
        if (playerLife == 1)
        {
            Life[0].SetActive(true);
            Life[1].SetActive(false);
        }
        if (playerLife == 2)
        {
            Life[1].SetActive(true);
            Life[2].SetActive(false);
        }
        if (playerLife == 3)
        {
            Life[2].SetActive(true);
        }
    }
}
