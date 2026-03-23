using UnityEngine;

public class Target : MonoBehaviour
{
    public Door doorToOpen;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            doorToOpen.OpenDoor();
        }
    }
}