using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody2D itemPrefab;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float spawnHeight = 7f;
    [SerializeField] private float spawnRange = 6.5f;
    [SerializeField] private float spawnInterval = 0.5f;


    void Awake()
    {
        InvokeRepeating(nameof(SpawnAcid), spawnInterval, spawnInterval);
    }

    private void SpawnAcid()
    {
        Rigidbody2D itemInstance;
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = Random.Range(spawnRange, -spawnRange);
        spawnPosition.y = spawnHeight;
        itemInstance = Instantiate(itemPrefab, spawnPosition, transform.rotation);
        itemInstance.name = itemPrefab.gameObject.name;
        itemInstance.velocity = Vector2.down * speed;
    }
}
