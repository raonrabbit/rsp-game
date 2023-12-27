using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowFunction : MonoBehaviour
{
    public float animationTime = 0.2f;
    private bool isActive = false;
    public void onClick(){
        if(gameObject.activeSelf){
            Hide(); 
            return;
        }
        Show();
    }

    public void Show()
    {
        if(isActive) return;
        isActive = true;
        gameObject.SetActive(true);
        StartCoroutine(scaleChangeAnimation(Vector2.zero, Vector2.one));
    }

    public void Hide()
    {
        if(!isActive) return;
        isActive = false;
        StartCoroutine(scaleChangeAnimation(Vector2.one, Vector2.zero));
        //gameObject.SetActive(false);
        StartCoroutine(DeactivateAfterDelay(animationTime));
    }

    IEnumerator scaleChangeAnimation(Vector2 originalScale, Vector2 targetScale)
    {
        float time = 0f;

        while(time < animationTime)
        {
            time += Time.unscaledDeltaTime;
            float t = time / animationTime;

            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);

            yield return null;
        }

        transform.localScale = targetScale;
    }

    IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        gameObject.SetActive(false);
    }
}
