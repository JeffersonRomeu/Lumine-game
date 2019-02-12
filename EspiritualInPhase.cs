using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspiritualInPhase : MonoBehaviour {

    public GameObject EspiritualLine;
    public GameObject target;

    private float timerToShow;
    private float TimeDuration;
    private float limitDuration = 24f;

    private bool showLine;

    void Update ()
    {
        if (!showLine)
        {
            timerToShow = Random.Range(1, 501);
        }
        else
        {
            TimeDuration += Time.deltaTime;
        }

        if (timerToShow == 10)
        {
            showLine = true;
            EspiritualLine.SetActive(true);
            target.SetActive(true);
            timerToShow = 0;
        }

        if (TimeDuration >= limitDuration)
        {
            EspiritualLine.SetActive(false);
            target.SetActive(false);
            showLine = false;
            TimeDuration = 0;
        }
    }
}
