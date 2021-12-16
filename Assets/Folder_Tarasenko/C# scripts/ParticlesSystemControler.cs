using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSystemControler : MonoBehaviour
{
    public Down a;
    public Move b;
    public ParticleSystem ParticlesSystem;
    public ParticleSystem ParticlesSystem2;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        ParticlesSystem.Play();
        ParticlesSystem2.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //для спусковых частичек
        if(a.grounded==true&&ParticlesSystem.isStopped&&rb.velocity.y<0)
        {
            ParticlesSystem.Play();
        }
        if (a.grounded == false && ParticlesSystem.isPlaying && rb.velocity.y < 0)
        {
            ParticlesSystem.Stop();
        }
        if (a.grounded==false&&ParticlesSystem.isPlaying && rb.velocity.y > 0)
        {
            ParticlesSystem.Stop();
        }
        if (a.grounded == true && ParticlesSystem.isPlaying && rb.velocity.y > 0)
        {
            ParticlesSystem.Stop();
        }
        //для подьёмных частичек
        if (a.grounded == true && ParticlesSystem2.isPlaying && rb.velocity.y < 0)
        {
            ParticlesSystem2.Stop();
        }
        if (a.grounded == false && ParticlesSystem2.isPlaying && rb.velocity.y < 0)
        {
            ParticlesSystem2.Stop();
        }
        if (a.grounded == false && ParticlesSystem2.isPlaying && rb.velocity.y > 0)
        {
            ParticlesSystem2.Stop();
        }
        if (a.grounded == true && ParticlesSystem2.isStopped && rb.velocity.y > 0)
        {
            ParticlesSystem2.Play();
        }
        ParticlesSystem.startSpeed = 5 + (int)Mathf.Sqrt(Mathf.Pow(b.SpeedX,2)+Mathf.Pow(b.SpeedY,2))/8;
        ParticlesSystem.maxParticles = 20+ (int)Mathf.Sqrt(Mathf.Pow(b.SpeedX, 2) + Mathf.Pow(b.SpeedY, 2));
    }
}
