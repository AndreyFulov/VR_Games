using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TowerBuilder : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor[] sockets;
    public MonoBehaviour towerScript;
    private int currentIndex = 0;

    void Start()
    {
        for (int i = 0; i < sockets.Length; i++)
        {
            sockets[i].enabled = (i == 0);
        }
        
        if (towerScript != null)
        {
            towerScript.enabled = false;
        }
    }

    public void OnPartAttached(SelectEnterEventArgs args)
    {
        StartCoroutine(ProcessNextSocket(args.interactableObject));
    }

    private System.Collections.IEnumerator ProcessNextSocket(UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable attachedObject)
    {
        yield return new WaitForSeconds(0.05f);
        
        if (attachedObject is MonoBehaviour behaviour)
        {
            behaviour.transform.SetParent(transform);
        }
        if (attachedObject is UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable)
        {
            grabInteractable.enabled = false;
        }
        
        sockets[currentIndex].enabled = false;
        currentIndex++;
        
        if (currentIndex < sockets.Length)
        {
            sockets[currentIndex].enabled = true;
        }
        else if (towerScript != null)
        {
            towerScript.enabled = true;
        }
    }
}