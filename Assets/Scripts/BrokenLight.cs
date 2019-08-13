using System.Collections;
using UnityEngine;

public class BrokenLight : MonoBehaviour
{
    private Light m_light;
    public float minVal, maxVal;
    private void Start()
    {
        m_light = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            float delay = Random.Range(minVal, maxVal);
            yield return new WaitForSeconds(delay);
            m_light.enabled = !m_light.enabled;
        }
    }

}
