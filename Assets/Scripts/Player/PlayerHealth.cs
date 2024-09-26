using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;

    [Header("Health Bar")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;

    [Header("Damage Overlay")]
    public Image overlay;
    public Image overlay2;
    public float duration;
    public float fadeSpeed;

    private float durationTimer;
    void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        overlay2.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }


    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if (overlay.color.a > 0)
        {
            if (health < 30)
            {
                return;
            }

            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }

        }

        if (overlay2.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay2.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay2.color = new Color(overlay2.color.r, overlay2.color.g, overlay2.color.b, tempAlpha);
            }
        }


        //TEST
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            TakeDamage(Random.Range(5, 10));
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            RestoreHealth(Random.Range(5, 10));
        }*/

    }

    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }


    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        durationTimer= 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.5f);
    }
    public void RestoreHealth(float healthAmount)
    {
        health += healthAmount;
        lerpTimer = 0f;
        durationTimer = 0;
        overlay2.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.5f);
    }
}
