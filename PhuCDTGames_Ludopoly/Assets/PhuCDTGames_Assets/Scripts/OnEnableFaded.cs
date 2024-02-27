using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnEnableFaded : MonoBehaviour
{
    private void OnEnable()
    {
        StopAllCoroutines();
        IEnumerator start()
        {
            for (float f = 0; f <= .2f; f += Time.deltaTime)
            {
                GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Lerp(0f, 0.3529412f, f / .15f));
                //standOnInformationCasvasGroup.alpha = Mathf.Lerp(0f, 1f, f / .15f);
                yield return null;
            }
        }
        StartCoroutine(start());
    }
}
