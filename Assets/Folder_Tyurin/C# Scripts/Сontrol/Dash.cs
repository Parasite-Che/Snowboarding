using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class Dash : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player;
    public Bonuses bonuses;
    public float refuelModifier;
    public float fuel;
    public float fuelMax;
    public bool click;
    public Rigidbody2D rb;
    public float Power;
    public float Reload;
    public float Timer;
    public GameObject Panel;
    public Vector2 DotDirection;
    public Vector2 PosPlayer;

    public void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        bonuses = player.GetComponent<Bonuses>();
        rb = player.GetComponent<Rigidbody2D>();
        Panel = GameObject.Find("Dash");
        refuelModifier = bonuses.bonuses.fuel.refuelModifier;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        click = true;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        click = false;
    }

    public void FixedUpdate()
    {
        PosPlayer = player.transform.position;
        DotDirection = GameObject.Find("Direction").transform.position;
        Vector2 Direction = DotDirection - PosPlayer;
        if (fuel < fuelMax)
        {
            fuel += 0.001f * fuelMax * (bonuses.bonuses.fuel.active ? refuelModifier : 1);
        }
        
        if (click && (fuel > 0))
        {
            StartCoroutine(HoldDash(Direction));
        }
        else
        {
            StopCoroutine(HoldDash(Direction));
        }

        if (fuel > 0)
        {
            Panel.GetComponent<Graphic>().color = new Color32(255, 255, 255, 70);
        }
        else
        {
            Panel.GetComponent<Graphic>().color = new Color32(0, 0, 0, 50);
        }
    }

    IEnumerator HoldDash(Vector2 dir)
    {
        fuel -= 2f;
        Dsh(dir);
        yield return null;
    }

    public void Dsh(Vector2 movement)
    {
        rb.AddForce(movement * Power);
    }
}
