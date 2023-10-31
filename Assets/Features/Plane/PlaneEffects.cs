using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEffects : MonoBehaviour
{
    [SerializeField]
    private PlaneController plane;

    [SerializeField]
    private Renderer fuselageRenderer;

    [SerializeField]
    private Renderer[] engineRenderers;

    [SerializeField]
    private ParticleSystem[] engineParticles;

    [SerializeField]
    private AudioSource engineAudio;

    private float maxParticlesRateOverTime;

    private void Awake()
    {
        maxParticlesRateOverTime = engineParticles[0].emission.rateOverTime.constantMax;

        // color the AI differently
        // TODO: Make this more scalable
        if (!plane.IsMain)
        {
            Material hullMaterial = fuselageRenderer.material;
            hullMaterial.SetColor("_Color", Color.red);
        }
    }

    private void Update()
    {
        UpdateAudio();
        UpdateVisuals();
    }

    private void UpdateAudio()
    {
        float throttle = plane.Throttle;

        if (throttle > 0 && !engineAudio.isPlaying)
        {
            engineAudio.Play();
        }
        else if (throttle <= 0 && engineAudio.isPlaying)
        {
            engineAudio.Stop();
        }

        engineAudio.volume = throttle;
    }

    private void UpdateVisuals()
    {
        float throttle = plane.Throttle;

        foreach (Renderer renderer in engineRenderers)
        {
            Material material = renderer.material;
            material.SetColor("_EmissionColor", Color.white * throttle);
        }

        foreach (ParticleSystem particles in engineParticles)
        {
            var particlesEmission = particles.emission;
            particlesEmission.rateOverTime = throttle * maxParticlesRateOverTime;
        }

    }
}
