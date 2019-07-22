using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomLoadBar : MonoBehaviour
{
    public float LoadPercentage
    {
        set
        {
            delta = Mathf.Clamp01(value);
        }
    }
    private float delta;

    public RectTransform progressBar;
    private float barWidth;

    // Start is called before the first frame update
    void Start()
    {
        barWidth = GetComponent<RectTransform>().rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.sizeDelta = new Vector2((delta - 1) * barWidth, 0f);
    }
}
