using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineParticleMeneger : MonoBehaviour
{
   public void PlayParticle (ParticleSystem Particle)
    {
        Particle.Play();
    }
    public void Stop(ParticleSystem Particle)
    {
        Particle.Stop();
    }
}
