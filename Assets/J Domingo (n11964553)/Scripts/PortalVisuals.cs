using NUnit.Framework.Internal;
using UnityEngine;

public class PortalVisuals : MonoBehaviour
{    
    private Material portalMaterial;

    [HeaderAttribute("Material Properties")]
    public string[] propertyNames;
    public float[] propertyValues;

    [HeaderAttribute("Particle Effects")]
    public ParticleSystem particles;
    public bool particleEndState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        portalMaterial = GetComponent<Renderer>().material;
        particles.gameObject.SetActive(!particleEndState);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.levelComplete)
        {
            //Debug.Log(portalMaterial.ToString());
            if (propertyNames.Length != propertyValues.Length) return;
            for (int i = 0; i < propertyNames.Length; i++)
            {
                portalMaterial.SetFloat(propertyNames[i], propertyValues[i]);
            }

            particles.gameObject.SetActive(particleEndState);
        }
    }
}
