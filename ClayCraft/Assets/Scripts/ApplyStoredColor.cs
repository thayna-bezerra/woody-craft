using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ApplyStoredColor : MonoBehaviour
{
    public ParticleSystem particle;
    public Material material;

    private void Start()
    {
        float r = PlayerPrefs.GetFloat("SelectedColorR", 1f);
        float g = PlayerPrefs.GetFloat("SelectedColorG", 1f);
        float b = PlayerPrefs.GetFloat("SelectedColorB", 1f);
        float a = PlayerPrefs.GetFloat("SelectedColorA", 1f);

        Color selectedColor = new Color(r, g, b, a);
        material.color = selectedColor;

        Color colorMax = selectedColor;
        Color colorMin = new Color(colorMax.r, colorMax.g, colorMax.b, 0f);

        ParticleSystem.MinMaxGradient gradient = new ParticleSystem.MinMaxGradient(colorMin, colorMax);

        var mainModule = particle.main;
        mainModule.startColor = gradient;
    }
}
