using System.Collections;
using UnityEngine;

public class BrokenLight : MonoBehaviour
{
    private Light m_light;
    private MeshRenderer mesh;
    public float minVal, maxVal;

    private void Start()
    {
        m_light = GetComponent<Light>();
        mesh = GetComponentInParent<MeshRenderer>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            float delay = Random.Range(minVal, maxVal);
            yield return new WaitForSeconds(delay);
            m_light.enabled = !m_light.enabled;
            if (!m_light.enabled)
            {
				if(mesh != null)
					mesh.material.SetColor("_EmissionColor", new Color(0, 0, 0));
            }
            else
            {
				if (mesh != null)
					mesh.material.SetColor("_EmissionColor", new Color(1, 1, 1));
            }
        }
    }

}
