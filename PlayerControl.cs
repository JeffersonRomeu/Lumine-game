using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject player;

    public  float   speed = 5.0f;
    private float   distance;
    private float   radius = 4.5f;
    public  float   multiplier = 2f;
    private float   timer_for_double_click;
    private float   delay = 0.5f;
    private float   specialTime = 10f;

    private bool    stayTouch = false;
    private bool    one_click = false;
    public  bool    two_click = false;
    public  bool    inSpecial;
    public static bool ingame = true;

    private Vector2 pointA;
    private Vector2 pointB;
    private Vector2 centerPosition;
    private Vector2 direction;
    private Vector2 nextPosition2d;

    private Vector3 nextPosition;
    public  Vector3 referencePos;

    private Animator Anim;

    private void Start()
    {
        Anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ingame) // apenas ao clicar
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.localPosition.z));
            referencePos = player.transform.position;

            if (!one_click)
            {
                one_click = true;

                timer_for_double_click = Time.time;
            }
            else {
                one_click = false;
                two_click = true;
            }
        }
        if (Input.GetMouseButton(0) && ingame) // enquanto mantiver pressionado
        {
            stayTouch = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.localPosition.z));
        }
        else
        {
            stayTouch = false;
        }

        if (one_click)
        {
            if ((Time.time - timer_for_double_click) > delay)
            {
                one_click = false;
                two_click = false;
            }
        }

    }
    private void FixedUpdate()
    {
        if (two_click && Collision.Special)
        {
            Anim.Play("blinkLumine");
            Collision.inSpecial = true;
        }
        if (Collision.inSpecial)
        {
            specialTime -= Time.deltaTime;

            if (specialTime <= 0)
            {
                Collision.Special = false;
                Collision.inSpecial = false;
                Collision.insideLight.intensity = 0;
                specialTime = 10f;
                Anim.Play("Idle");
            }
        }

        if (stayTouch)
        {
            centerPosition = this.transform.position;//Centro da tela camera 

            direction = pointB - pointA;// direção que o player vai se movimentar

            nextPosition = referencePos + new Vector3(-direction.x, -direction.y) * multiplier; // faz com que o player se movimente nos dois eixos
            nextPosition2d = new Vector2(nextPosition.x, nextPosition.y); // Armazena nextPosition para manipular com radius

            distance = Vector2.Distance(nextPosition, centerPosition); // distancia entre o centro da camera, e a próxima posição
     
            if (distance >= radius)
            {
                Vector2 fromOriginToObject = nextPosition2d - centerPosition;
                fromOriginToObject *= radius / distance;
                nextPosition2d = centerPosition + fromOriginToObject;
            }
            player.transform.Translate(new Vector3(nextPosition2d.x, nextPosition2d.y, player.transform.position.z) - player.transform.position);
        }
    }
    Vector3 ContDistance(Vector2 direction)//contador da distancia central até o limite do Screen
    {
        return direction * speed * Time.deltaTime;
    }
}