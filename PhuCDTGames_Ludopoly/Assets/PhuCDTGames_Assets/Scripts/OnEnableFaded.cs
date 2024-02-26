using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnEnableFaded : MonoBehaviour
{
    Vector4 oldColor = new Vector4(0, 0, 0, 0);
    Vector4 newColor = new Vector4(0, 0, 0, 0.3529412f);

    private void OnEnable()
    {
        StopAllCoroutines();
        IEnumerator start()
        {
            for (float f = 0; f <= .2f; f += Time.deltaTime)
            {
                //GetComponent<Image>().color.a = Mathf.Lerp(0f, 1f, f / .15f);
                //standOnInformationCasvasGroup.alpha = Mathf.Lerp(0f, 1f, f / .15f);
                yield return null;
            }
        }
        StartCoroutine(start());
    }
}
