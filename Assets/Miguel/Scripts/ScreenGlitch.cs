using UnityEngine;
using UnityEngine.UI;

public class ScreenGlitch : MonoBehaviour
{
    public Image glitchImage;
    public float interval = 3f;

    void Start()
    {
        InvokeRepeating("Glitch", interval, interval);
    }

    void Glitch()
    {
        StartCoroutine(GlitchFX());
    }

    System.Collections.IEnumerator GlitchFX()
    {
        glitchImage.color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.05f);
        glitchImage.color = new Color(1, 1, 1, 0);
    }
}