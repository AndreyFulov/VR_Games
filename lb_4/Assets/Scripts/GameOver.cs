using UnityEngine;

public class GameOver : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.ShowGameOver();
        }
    }
}
