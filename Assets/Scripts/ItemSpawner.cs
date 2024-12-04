using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody2D itemPrefab;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float spawnHeight = 7f;
    [SerializeField] private float spawnRange = 6.5f;
    [SerializeField] private float initialSpawnInterval = 0.5f;
    [SerializeField] private float spawnIntervalAcceleration = 0f;


    void Awake()
    {
        Invoke(nameof(SpawnItem), initialSpawnInterval);
        if(spawnIntervalAcceleration != 0)
        {
            InvokeRepeating(nameof(UpdateSpawnInterval), 1f, 1f);
        }
    }

    private void SpawnItem()
    {
        Rigidbody2D itemInstance;
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = Random.Range(spawnRange, -spawnRange);
        spawnPosition.y = spawnHeight;
        itemInstance = Instantiate(itemPrefab, spawnPosition, transform.rotation);
        itemInstance.name = itemPrefab.gameObject.name;
        itemInstance.velocity = Vector2.down * speed;
        Invoke(nameof(SpawnItem), initialSpawnInterval);
    }

    private void UpdateSpawnInterval()
    {
        initialSpawnInterval = Mathf.Lerp(initialSpawnInterval, 0.1f, spawnIntervalAcceleration);
    }
}
