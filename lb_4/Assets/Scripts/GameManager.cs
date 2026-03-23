using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverUI;
    
    void Awake() => Instance = this;
    
    public void ShowGameOver()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var locomotion = player.GetComponent<LocomotionSystem>();
            if (locomotion != null) locomotion.enabled = false;
        }

        RectTransform ui = gameOverUI.GetComponent<RectTransform>();
        Transform cam = Camera.main.transform;
        ui.position = cam.position + cam.forward * 0.3f;
        ui.rotation = cam.rotation;
        gameOverUI.SetActive(true);

        GameObject floor = new GameObject("Floor");
        floor.transform.position = player.transform.position;
        
        BoxCollider collider = floor.AddComponent<BoxCollider>();
        collider.size = new Vector3(10, 0.2f, 10);
        collider.center = new Vector3(0, -0.1f, 0);
        
        Rigidbody rb = floor.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        floor.transform.SetParent(player.transform);
    }
}