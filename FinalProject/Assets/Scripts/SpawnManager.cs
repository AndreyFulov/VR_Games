using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnZone;
    public GameObject enemyPrefab;

    public void SpawnEnemy(Color bookColor, int health, float speedMultiplier = 1f)
    {
        if (enemyPrefab == null || spawnZone == null)
        {
            Debug.LogError("SpawnManager: не назначены префаб или зона спавна!");
            return;
        }

        Vector3 spawnPoint = spawnZone.position + new Vector3(
            Random.Range(-spawnZone.localScale.x / 2f, spawnZone.localScale.x / 2f),
            0,
            Random.Range(-spawnZone.localScale.z / 2f, spawnZone.localScale.z / 2f)
        );

        GameObject newBook = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        SetupBook(newBook, bookColor, health, speedMultiplier);
    }

    private void SetupBook(GameObject book, Color color, int health, float speedMultiplier)
    {
        // Цвет
        MeshRenderer renderer = book.GetComponentInChildren<MeshRenderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }

        // Здоровье
        BookHealth healthComponent = book.GetComponent<BookHealth>();
        if (healthComponent == null) healthComponent = book.AddComponent<BookHealth>();
        healthComponent.SetHealthAndScore(health, health * speedMultiplier);

        // Скорость
        BookMovement movement = book.GetComponent<BookMovement>();
        if (movement != null && speedMultiplier != 1f)
        {
            movement.moveSpeed *= speedMultiplier;
        }
    }
}