using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ApplyColor : MonoBehaviour
{
    public FlexibleColorPicker fcp;
    public ParticleSystem particle;
    public Material material;


    private void Update()
    {
        material.color = fcp.color;
                                   
        Color colorMax = fcp.color;

        Color colorMin = new Color(colorMax.r, colorMax.g, colorMax.b, 0f);

        ParticleSystem.MinMaxGradient gradient = new ParticleSystem.MinMaxGradient(colorMin, colorMax);

        var mainModule = particle.main;
        mainModule.startColor = gradient;
    }
}
  