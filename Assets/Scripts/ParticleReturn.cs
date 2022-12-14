using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleReturn : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        var particle = GetComponent<ParticleSystem>();
        MemoryPool.instance.ReturnEffect(particle);
    }
}
