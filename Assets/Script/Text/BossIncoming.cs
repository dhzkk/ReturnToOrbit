using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossIncoming : MonoBehaviour
{

    public TMP_Text textUI;
    public float delay = 0.3f;

    void Start()
    {
        StartCoroutine(ShowText("M1CH43L57"));
    }

    private IEnumerator ShowText(string message)
    {
        textUI.text = "";

        foreach (char c in message)
        {
            textUI.text += c;
            yield return new WaitForSeconds(delay);
        }

        yield return StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 2; i++) 
        {
            textUI.enabled = false;
            yield return new WaitForSeconds(0.5f);

            textUI.enabled = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
