using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pesadelos : MonoBehaviour {

    public GameObject pesadelos;
    public Vector2 numberOfPesadelos;
    public List<GameObject> newPesadelos;
    private float posXMin = -3.5f;
    private float posYMin = -3.5f;
    private float posXMax = 3.5f;
    private float posYMax = 3.5f;


    void Start ()
    {
        int newNumberOfPesadelos = (int)Random.Range(numberOfPesadelos.x, numberOfPesadelos.y);

        for (int i = 0; i < newNumberOfPesadelos; i++)
        {
            newPesadelos.Add(Instantiate(pesadelos, transform));
            newPesadelos[i].SetActive(false);
        }
        PositionatePesadelos();
	}

    public void PositionatePesadelos()
    {
        for (int i = 0; i < newPesadelos.Count; i++)
        {
            float posZMin = (730f / newPesadelos.Count) + (730f / newPesadelos.Count) * i;
            float posZMax = (730f / newPesadelos.Count) + (730f / newPesadelos.Count) * i + 1;

            float randomZPos = Random.Range(posZMin, posZMax);
            float randomXPos = Random.Range(posXMin, posXMax);
            float randomYPos = Random.Range(posYMin, posYMax);

            newPesadelos[i].transform.localPosition = new Vector3(randomXPos, randomYPos, randomZPos);
            newPesadelos[i].SetActive(true);
        }
        
    }
}
