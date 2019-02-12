using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioMoving : MonoBehaviour {

    private float speed;
    public static bool scenarioMoving;

    private void FixedUpdate()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (scenarioMoving)
        {
            speed = -20f;
            speed -= Time.deltaTime;
        }
        else
        {
            speed = 0;
        }
        limitSpeed();
    }

    public void limitSpeed()
    {
        if (speed <= -100f)
        {
            speed = -100f;
        }
    }
}
