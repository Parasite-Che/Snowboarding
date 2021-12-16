using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    private Vector3 left= new Vector3(-1f, 0, 0);
    private Vector3 right = new Vector3(1f, 0, 0);
    public Transform player;
    private float dangerZone = 300;
    private float speed;

    public enum animalType { small, big };
    public animalType type;

    


    [SerializeField]
    private bool aggressive, peaceful, cowardly;

    public void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        speed = this.GetComponent<ObjectID>().speed;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.position) < dangerZone)
        {
            MovementLogic();
        }
    }

    private void MovementLogic()
    {
        // player -- monster
        if (transform.position.x > player.position.x)
        {
            if (aggressive)
            {
                // move left in direction of the player
                transform.position += left * speed * Time.deltaTime;
            }
            else if (cowardly)
            {
                // run away from the player
                transform.position += right * speed * Time.deltaTime;
            }
        }
        // monster -- player
        else
        {
            if (aggressive)
            {
                // move right in direction of the player
                transform.position += right * speed * Time.deltaTime;
            }
            else if (cowardly)
            {
                // run away from the player
                transform.position += left * speed * Time.deltaTime;
            }
        }
        
    }

    private void Die(GameObject obj) 
    {
        Destroy(obj);
    }
}
