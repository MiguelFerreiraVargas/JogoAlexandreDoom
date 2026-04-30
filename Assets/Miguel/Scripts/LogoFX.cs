using UnityEngine;
using TMPro;

public class LogoFX : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float pulseAmount = 0.05f;

    public float glitchInterval = 2f;
    public float glitchDuration = 0.1f;

    private Vector3 originalScale;
    private TextMeshProUGUI text;
    private float glitchTimer;

    void Start()
    {
        originalScale = transform.localScale;
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Pulse
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = originalScale * scale;

        // Glitch timer
        glitchTimer += Time.deltaTime;
        if (glitchTimer >= glitchInterval)
        {
            StartCoroutine(Glitch());
            glitchTimer = 0;
        }
    }

    System.Collections.IEnumerator Glitch()
    {
        Vector3 originalPos = transform.localPosition;

        for (float t = 0; t < glitchDuration; t += Time.deltaTime)
        {
            transform.localPosition = originalPos + new Vector3(
                Random.Range(-5f, 5f),
                Random.Range(-2f, 2f),
                0
            );

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}