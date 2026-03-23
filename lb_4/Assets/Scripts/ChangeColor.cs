using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material activeMaterial = null;
    private MeshRenderer meshRenderer = null;
    public Material defaultMaterial = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = defaultMaterial;
    }

    // Update is called once per frame
    public void SetActiveMaterial()
    {
        meshRenderer.material = activeMaterial;
    }

    public void SetDefaultMaterial()
    {
        meshRenderer.material = defaultMaterial;
    }
}
