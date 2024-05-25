using UnityEngine;

public class Shooting_Zone : MonoBehaviour
{
    public GameObject objectToSpawn; // ������ �� ������, ������� ����� ����������
    public Vector3 spawnPosition; // ������� ������
    public Vector3 direction; // ����������� �������� ����������� �������
    public float speed = 10f; // �������� �������� ����������� �������
    public float spawnInterval = 1f; // �������� ������ � ��������

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

