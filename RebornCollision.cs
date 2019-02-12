using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebornCollision : MonoBehaviour {

    // código serve para destruir os objetos proximos do player após o player renascer

    public static bool rebornCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Inimigos")
        {
            Destroy(other.gameObject);
        }
    }
}
