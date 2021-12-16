using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionCheck : MonoBehaviour
{
    public int headSaves;
    public int groundLayer;
    public Rotate jump;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            if (headSaves <= 0)
            {
                GetComponentInParent<Death>().Die = true;
            }
            else
            {
                jump.JumpLogic(Vector2.up);
                headSaves--;
            }
        }
    }
}
