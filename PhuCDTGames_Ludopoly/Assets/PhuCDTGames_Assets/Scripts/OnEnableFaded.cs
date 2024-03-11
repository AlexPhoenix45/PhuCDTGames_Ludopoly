using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameAdd_Ludopoly
{
    public class OnEnableFaded : MonoBehaviour
{
    public float fadedValue = 0.3529412f;
    private void OnEnable()
    {
        StopAllCoroutines();
        IEnumerator start()
        {
            for (float f = 0; f <= .2f; f += Time.deltaTime)
            {
                GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Lerp(0f, fadedValue, f / .15f));
                //standOnInformationCasvasGroup.alpha = Mathf.Lerp(0f, 1f, f / .15f);
                yield return null;
            }
        }
        StartCoroutine(start());
    }
}
}
