using UnityEngine;

public class Shooting_Zone : MonoBehaviour
{
    public GameObject objectToSpawn; // Ссылка на объект, который будет спавниться
    public Vector3 spawnPosition; // Позиция спавна
    public Vector3 direction; // Направление движения спавненного объекта
    public float speed = 10f; // Скорость движения спавненного объекта
    public float spawnInterval = 1f; // Интервал спавна в секундах

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * speed;
        }
    }
}

