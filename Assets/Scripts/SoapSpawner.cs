using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody2D soapPrefab;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float spawnHeight = 7f;
    [SerializeField] private float spawnRange = 6.5f;
    [SerializeField] private float spawnInterval = 10f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnSoap), spawnInterval, spawnInterval);
    }

    private void SpawnSoap()
    {
        Rigidbody2D soapInstance;
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = Random.Range(spawnRange, -spawnRange);
        spawnPosition.y = spawnHeight;
        soapInstance = Instantiate(soapPrefab, spawnPosition, transform.rotation);
        soapInstance.name = "Soap";
        soapInstance.velocity = Vector2.down * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Spongy"))
        {
            Destroy(gameObject);
        }
    }
}
