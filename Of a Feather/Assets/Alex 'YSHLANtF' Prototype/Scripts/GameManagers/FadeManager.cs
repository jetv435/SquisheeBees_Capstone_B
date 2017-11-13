using UnityEngine;
using System.Collections;

public class FadeManager : MonoBehaviour
{

    public void FadeIn(CanvasGroup c, float _time, float _alpha = 1f)
    {
        StartCoroutine(iFadeIn(c, _time, _alpha));
    }

    IEnumerator iFadeIn(CanvasGroup objToFade, float _time, float _alpha = 1f)
    {
        while (objToFade.alpha < _alpha)
        {
            objToFade.alpha += Time.deltaTime / _time;
            yield return null;
        }

        objToFade.alpha = _alpha;
    }

    public void FadeOut(CanvasGroup c, float _time, float _alpha = 0f)
    {
        StartCoroutine(iFadeOut(c, _time, _alpha));
    }

	IEnumerator iFadeOut(CanvasGroup objToFade, float _time, float _alpha = 0f)
    {
        while (objToFade.alpha > _alpha)
        {
            objToFade.alpha -= Time.deltaTime / _time;
            yield return null;
        }

        objToFade.alpha = _alpha;
    }

    public void CanvasGroupOFF(CanvasGroup c, bool a)
    {
        c.interactable = false;
        c.blocksRaycasts = false;
        if (a) c.alpha = 0;
    }

    public void CanvasGroupON(CanvasGroup c, bool a)
    {
        c.interactable = true;
        c.blocksRaycasts = true;
        if (a) c.alpha = 1;
    }
}
