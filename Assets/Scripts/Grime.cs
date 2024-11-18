using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grime : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D grime;
    [SerializeField]
    private float speed = -3.0f;
    [SerializeField]
    private float spawnHeight = 7f;
    [SerializeField]
    private float spawnRange = 6.5f;

    void Awake()
    {
        Invoke(nameof(SpawnGrime), 2f);
    }

    private void SpawnGrime()
    {
        Rigidbody2D grimeInstance;
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = Random.Range(spawnRange, -spawnRange);
        spawnPosition.y = spawnHeight;
        grimeInstance = Instantiate(grime, spawnPosition, transform.rotation);
        grimeInstance.name = "Grime(Clone)";
        grimeInstance.velocity = Vector2.down * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Spongy"))
        {
            Destroy(gameObject);
        }
    }
}
