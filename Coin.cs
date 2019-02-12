using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public GameObject[] coin;
    public Vector2 numberOfCoins;
    public List<GameObject> newCoins;

    private float posXMin = -3.5f;
    private float posYMin = -3.5f;
    private float posXMax = 3.5f;
    private float posYMax = 3.5f;

    void Start () {

        float choiceCoin = Random.Range(0, 3);
        int newNumberOfCoins = (int)Random.Range(numberOfCoins.x, numberOfCoins.y);

        if (choiceCoin == 0)
        {
            for (int i = 0; i < newNumberOfCoins; i++)
            {
                newCoins.Add(Instantiate(coin[0], transform));
                newCoins[i].SetActive(false);
            }
            PositionateCoins();
        }

        if (choiceCoin == 1)
        {
            for (int i = 0; i < newNumberOfCoins; i++)
            {
                newCoins.Add(Instantiate(coin[1], transform)); // instanciar outra coin
                newCoins[i].SetActive(false);
            }
            PositionateCoins();
        }

        if (choiceCoin == 2)
        {
            for (int i = 0; i < newNumberOfCoins; i++)
            {
                newCoins.Add(Instantiate(coin[2], transform)); // instanciar outra coin
                newCoins[i].SetActive(false);
            }
            PositionateWaveCoins();
        }
	}

    void PositionateCoins()
    {
        for (int i = 0; i < newCoins.Count; i++)
        {
            float posZMin = (700f / newCoins.Count) + (700f / newCoins.Count) * i;
            float posZMax = (700f / newCoins.Count) + (700f / newCoins.Count) * i + 1;

            float randomZPos = Random.Range(posZMin, posZMax);
            float randomXPos = Random.Range(posXMin, posXMax);
            float randomYPos = Random.Range(posYMin, posYMax);

            newCoins[i].transform.localPosition = new Vector3(randomXPos, randomYPos, randomZPos);
            newCoins[i].SetActive(true);
        }
    }

    void PositionateWaveCoins()
    {
        for(int i = 0; i < newCoins.Count; i++)
        {
            float posZMin = (700f / newCoins.Count) + (700f / newCoins.Count) * i;
            float posZMax = (700f / newCoins.Count) + (700f / newCoins.Count) * i + 1;
            float randomZPos = Random.Range(posZMin, posZMax);

            newCoins[i].transform.localPosition = new Vector3(0, 0, randomZPos);
            newCoins[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PositionateCoins();
        }
    }

    void Update () {
		
	}
}
