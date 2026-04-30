using UnityEngine;

public class UIAppear : MonoBehaviour
{
    public float delay = 0.5f;
    public float speed = 5f;

    private CanvasGroup cg;

    void Start()
    {
        cg = gameObject.AddComponent<CanvasGroup>();
        cg.alpha = 0;
        Invoke("Show", delay);
    }

    void Show()
    {
        StartCoroutine(FadeIn());
    }

    System.Collections.IEnumerator FadeIn()
    {
        while (cg.alpha < 1)
        {
            cg.alpha += Time.deltaTime * speed;
            yield return null;
        }
    }
}