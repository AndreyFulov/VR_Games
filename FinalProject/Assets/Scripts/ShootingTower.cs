using UnityEngine;

public class ShootingTower : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public Transform firePoint;
    public AudioClip shootSound;
    
    private float nextFireTime = 0f;
    
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
    
    void Shoot()
    {
        GameObject target = FindNearestBook();
        if (target != null && bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            
            // Просто направляем пулю к цели
            Vector3 direction = (target.transform.position - firePoint.position).normalized;
            bullet.GetComponent<Bullet>()?.SetDirection(direction);

            if (shootSound != null)
            {
                PlaySoundAtPoint(shootSound, firePoint.position);
            }
        }
    }
    
    GameObject FindNearestBook()
    {
        GameObject[] books = GameObject.FindGameObjectsWithTag("Book");
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;
        
        foreach (GameObject book in books)
        {
            float distance = Vector3.Distance(transform.position, book.transform.position);
            if (distance < minDistance)
            {
                nearest = book;
                minDistance = distance;
            }
        }
        return nearest;
    }

    void PlaySoundAtPoint(AudioClip clip, Vector3 position, float volume = 0.5f)
    {
        // Создаем временный GameObject для звука
        GameObject soundObject = new GameObject("TempAudio");
        soundObject.transform.position = position;
        
        // Добавляем AudioSource и настраиваем как 3D-звук
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.spatialBlend = 1f; // Полностью 3D звук
        audioSource.minDistance = 2f;
        audioSource.maxDistance = 20f;
        audioSource.playOnAwake = false;
        
        // Воспроизводим звук
        audioSource.Play();
        
        // Уничтожаем объект после проигрывания звука
        Destroy(soundObject, clip.length + 0.1f);
    }
}