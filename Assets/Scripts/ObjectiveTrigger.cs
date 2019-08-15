using UnityEngine;
using TMPro;
using System.Collections;

public class ObjectiveTrigger : MonoBehaviour
{
    public string objective;
    public TextMeshProUGUI sideText;
    public TextMeshProUGUI midText;
    public float fadeTime;
    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        if (sideText)
        {
            sideText.text = "เป้าหมาย: " + objective;
            midText.text = "เป้าหมาย\n" + objective;
        }
        else
        {
            midText.text = objective;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            if (sideText)
                sideText.gameObject.SetActive(true);
            StopAllCoroutines();
            midText.color = new Color(1, 1, 1, 0);
            StartCoroutine(FadeInOut());
            triggered = true;
        }
    }

    IEnumerator FadeInOut()
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime / fadeTime;
            alpha = Mathf.Clamp01(alpha);
            midText.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
        yield return new WaitForSeconds(fadeTime);
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / fadeTime;
            alpha = Mathf.Clamp01(alpha);
            midText.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
        midText.color = new Color(1, 1, 1, 0);
		
	}
}
