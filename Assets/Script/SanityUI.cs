using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityUI : MonoBehaviour
{
    public RectTransform sanityBar;
    public Image healthBar;
    public float xColor;
    public PlayerSanity playerSanity;
    public Vector2 originalPosition;

    private void Awake()
    {
        originalPosition = sanityBar.sizeDelta;
    }
    private void FixedUpdate() //Please just update using a delegate event, which is cheaper
    {
        sanityBar.anchoredPosition = new Vector2(-(sanityBar.sizeDelta.x) * (1 - (playerSanity.sanityMeter / 100)), sanityBar.anchoredPosition.y); //Terrible, make it more dynamic
        ChangeColor();
    }

    public void ChangeColor() 
    {
        float multiplier = ((playerSanity.sanityMeter - 50) / 50);
        healthBar.color = new Color((1 - xColor) - (1 - 2 * xColor) * Mathf.Max(0.0f, multiplier), (1 - xColor) + (1 - 2 * xColor) * Mathf.Min(0.0f, multiplier), xColor);
    }
}
