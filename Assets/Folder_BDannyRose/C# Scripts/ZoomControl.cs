using UnityEngine;
using Cinemachine;

public class ZoomControl : MonoBehaviour
{
    [SerializeField] GameObject cam;
    //public GameObject player;
    public Move playerMovement;
    public float incrementalValue = 0.1f;
    public float zoomGoal;
    public float zoomMin = 40;
    public float zoomMax = 100;
    public CinemachineVirtualCamera cvc;

    private void Awake()
    {
        cvc = GetComponent<CinemachineVirtualCamera>();
    }
    void Start()
    {
        playerMovement = GetComponent<Move>();
    }

    void FixedUpdate()
    {
        zoomGoal = playerMovement.SpeedX / 2.5f;
        Mathf.Clamp(zoomGoal, zoomMin, zoomMax);
        
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
