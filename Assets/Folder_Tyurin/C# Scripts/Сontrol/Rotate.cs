using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Rotate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private GameObject player;
    public bool click = false;
    public bool grounded = false;
    public float RotateForce;
    public float JumpForce;
    public float JumpForceModifier;
    public float maxAngularSpeed;
    public int k;
    private float z;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    public Rigidbody2D RbDirection;
    public Rigidbody2D RbBackDirection;
    public Vector2 DotDirection;
    public Vector2 DotDirectionUp;
    public Vector2 BackDotDirection;
    public Vector2 BackDotDirectionUp;

    public void Start()
    {
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        click = true;
        player = GameObject.FindWithTag("Player");
        JumpLogic( Vector3.up);
        GetComponent<Graphic>().color = new Color32(0, 255, 0, 70);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        click = false;
        GetComponent<Graphic>().color = new Color32(255, 255, 255, 70);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        click = false;
        GetComponent<Graphic>().color = new Color32(255, 255, 255, 70);
    }

    public void FixedUpdate()
    {
        DotDirectionUp = GameObject.Find("Direction up").transform.position;
        DotDirection = GameObject.Find("Direction").transform.position;
        Vector2 Direction = DotDirection - DotDirectionUp;
        BackDotDirectionUp = GameObject.Find("-Direction up").transform.position;
        BackDotDirection = GameObject.Find("-Direction").transform.position;
        Vector2 BackDirection = BackDotDirection - BackDotDirectionUp;

        grounded = GameObject.FindWithTag("Player").GetComponent<Collider2D>().IsTouchingLayers(groundLayer.value);
        if (click & (grounded == false))
        {
            if ((rb.angularVelocity < maxAngularSpeed) && (rb.angularVelocity > -maxAngularSpeed))
            {
                rb.AddForceAtPosition(Direction * RotateForce, DotDirection);
                rb.AddForceAtPosition(BackDirection * -RotateForce, BackDotDirection);
            }
        }
        if(rb.angularVelocity > maxAngularSpeed)
        {
            rb.AddForceAtPosition(Direction * RotateForce * k, DotDirection);
            rb.AddForceAtPosition(BackDirection * -RotateForce * k, BackDotDirection);
        }
        else if (rb.angularVelocity < -maxAngularSpeed)
        {
            rb.AddForceAtPosition(Direction * -RotateForce * k, DotDirection);
            rb.AddForceAtPosition(BackDirection * RotateForce * k, BackDotDirection);
        }
    }

    public void JumpLogic(Vector3 direction)
    {
        if (grounded)
        {
            rb.AddForce(direction * JumpForce * JumpForceModifier * 10);
        }
    }
    public void JumpSave()
    {
        rb.AddForce(Vector2.up * JumpForce * 10);
    }
}
