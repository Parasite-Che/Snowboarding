using UnityEngine;
using Cinemachine;

public class ZoomControl : MonoBehaviour
{
    [SerializeField] GameObject cam;
    //public GameObject player;
    public float incrementalValue = 0.1f;
    public float zoomGoal;
    public float zoomMin = 40;
    public float zoomMax = 100;
    public Cinemachine.CinemachineVirtualCamera cvc;
    public Rigidbody2D rb; 
    public float rise;
    public float limit;
    private float speed1 = 0;
    private float speed2 = 0;

    void FixedUpdate()
    {
        //zoomGoal = playerMovement.SpeedX / 2.5f;
        //Mathf.Clamp(zoomGoal, zoomMin, zoomMax);
        speed2 = Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y);
        if ((cvc.m_Lens.OrthographicSize < zoomMax) && (speed2 - speed1 > 0))
        {
            //cvc.m_Lens.OrthographicSize += rise;
            if ((speed2 - speed1) < limit)
            {
                cvc.m_Lens.OrthographicSize += (speed2 - speed1) * rise;
            }
            else
            {
                cvc.m_Lens.OrthographicSize += limit * rise;
            }
        }
        else if ((cvc.m_Lens.OrthographicSize > zoomMin) && (speed2 - speed1 < 0))
        {
            //cvc.m_Lens.OrthographicSize -= rise;
            if ((speed2 - speed1) > -limit)
            {
                cvc.m_Lens.OrthographicSize += (speed2 - speed1) * rise;
            }
            else
            {
                cvc.m_Lens.OrthographicSize -= limit * rise;
            }
        }
        else if ((cvc.m_Lens.OrthographicSize > zoomMin) && (speed2 - speed1 > 0))
        {

        }
        Debug.Log(speed2 - speed1);
        Debug.Log(speed2);
        speed1 = speed2;
        
        //if ( < zoomGoal)
        //{
        //     += incrementalValue;
        //}
        //else if ( > zoomGoal)
        //{
        //     -= incrementalValue;
        //}
    }
}
