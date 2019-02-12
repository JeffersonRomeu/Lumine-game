using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspiritualLine : MonoBehaviour {

    private bool goingMagnetic;

    public GameObject target;

    public float speed;
    private float x, y, z; // z não será atribuido valor
    private float timerOnMagnetic;
    private int randomValue;

    private Vector3 magneticPos;
    private Vector3 EspiritualPos;

    public void Start()
    {
        z = target.transform.position.z;
	}

    void Update ()
    {
        if (!goingMagnetic)
        {
            randomValue = Random.Range(0, 51);

            if (randomValue == 1)
            {
                x = Random.Range(-4f, 4f);
                y = Random.Range(-4f, 4f);
            }
        }
        else
        {
            timerOnMagnetic += Time.deltaTime;

            if (timerOnMagnetic >= 3)
            {
                goingMagnetic = false;
                timerOnMagnetic = 0f;
            }
        }

        Vector3 inTarget = new Vector3(x, y, z);
        target.transform.position = inTarget;
        this.transform.position = Vector3.MoveTowards(this.transform.position, inTarget, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Magnetic")
        {
            x = other.transform.position.x;
            y = other.transform.position.y;

            goingMagnetic = true; 
        }
    }
}
