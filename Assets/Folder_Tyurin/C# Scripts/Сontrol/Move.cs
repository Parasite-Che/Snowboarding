using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float Power;
    public float SpeedX;
    public float SpeedY;
    public float MaxSpeedX;
    public float MaxSpeedY;
    public float dist;
    public float TimeDeath;
    public float Interval;
    public float speedModifier;

    public bool die;
    public GameObject control;
    public bool grounded;
    public RaycastHit2D hit;
    public Ray2D ray;
    public Text myText;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    public AvalancheMove avalancheMovement;
    public Text Speed;

    public void Start()
    {
        //CreateInv = GameObject.Find("InvControl").GetComponent<Inventory>();
        //CreateInv.AddGraphics();
        control = GameObject.Find("Control");
        die = false;
        rb = this.GetComponent<Rigidbody2D>();
        avalancheMovement = GameObject.FindWithTag("Avalanche").GetComponent<AvalancheMove>();
    }

    private void FixedUpdate()
    {
        grounded = rb.IsTouchingLayers(groundLayer.value);
        
        if (grounded & (rb.velocity.x <= MaxSpeedX))
        {
            Force(new Vector3(1.0f * speedModifier, 0.0f, 0.0f));
        }

        if ((grounded == false) & (rb.velocity.y + 20 <= MaxSpeedX))
        {
            Force(new Vector3(0.0f, -1.0f, 0.0f) * 1.2f);
        }

        if (rb.velocity.x > MaxSpeedX & rb.velocity.y < -MaxSpeedY)
        {
            Force(new Vector3(-1.0f, 0.0f, 0.0f) * 10);
            Force(new Vector3(0.0f, 1.0f, 0.0f) * 10);
        }
        else if (rb.velocity.x > MaxSpeedX & rb.velocity.y > -MaxSpeedY)
        {
            Force(new Vector3(-1.0f, 0.0f, 0.0f) * 10);
        }
        else if (rb.velocity.x < MaxSpeedX & rb.velocity.y < -MaxSpeedY)
        {
            Force(new Vector3(0.0f, 1.0f, 0.0f) * 20);
        }

        SpeedX = rb.velocity.x;
        SpeedY = rb.velocity.y;
        ray = new Ray2D(this.transform.position, -transform.up);
        hit = Physics2D.Raycast(this.transform.position, new Vector2(0, -1), 5000, groundLayer);
        dist = Vector3.Distance(this.transform.position, hit.point);
        myText.text = "Height: " + (int)dist;

        if (dist > 1000)
        {
            TimeDeath += Interval;
        }
        else
            TimeDeath = 0;

        if (TimeDeath >= 50 & die == false)
        {
            die = true;
            this.GetComponent<Death>().Die = true;
        }

        Speed.text = "Speed: " + ((float)((int)Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + (int)Mathf.Pow(rb.velocity.y, 2))) / 10).ToString();
    }

    private void Force(Vector3 movement)
    { 
        rb.AddForce(movement * Power);
    }
}
