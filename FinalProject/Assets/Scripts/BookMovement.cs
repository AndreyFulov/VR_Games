using UnityEngine;

public class BookMovement : MonoBehaviour
{
    public Transform targetPoint;
    public float moveSpeed = 3f;
    public float hoverAmplitude = 0.2f;
    public float hoverFrequency = 2f;
    public float angleY = 0.1f;
    
    private Vector3 startPosition;
    private Vector3 virtualTargetPoint;
    private float randomHoverOffset;
    private bool isStopped = false;

    private void Start()
    {
        if (targetPoint == null)
        {
            Debug.LogError("BookMovement: не назначена целевая точка!");
        }

        startPosition = transform.position;
        randomHoverOffset = Random.Range(0f, 2f * Mathf.PI);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        virtualTargetPoint = new Vector3(
        targetPoint.position.x - 200f ,
        targetPoint.position.y,
        targetPoint.position.z// На 5 единиц дальше
    );
    }

    private void Update()
    {
        // Проверка стены
        if (isStopped)
        {
            Collider[] walls = Physics.OverlapSphere(transform.position, 0.5f);
            bool wallFound = false;
            foreach (Collider col in walls)
            {
                if (col.CompareTag("Wall"))
                {
                    wallFound = true;
                    break;
                }
            }
            if (!wallFound) isStopped = false;
        }

        // Парение
        float hoverY = Mathf.Sin((Time.time + randomHoverOffset) * hoverFrequency) * hoverAmplitude;
        transform.position = new Vector3(transform.position.x, startPosition.y + hoverY, transform.position.z);

        if (targetPoint == null || isStopped) return;

        // Движение к цели
        Vector3 direction = (virtualTargetPoint - transform.position).normalized;
        // Vector3 direction = (targetPoint.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        
        // Поворот
        Vector3 flatDirection = new Vector3(direction.z, angleY, direction.x);
        Quaternion targetRotation = Quaternion.LookRotation(flatDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            isStopped = true;
        }
    }
}