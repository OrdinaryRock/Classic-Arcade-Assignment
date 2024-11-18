using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Acid : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D acid;
    [SerializeField]
    private float speed = -3.0f;
    [SerializeField]
    private float spawnHeight = 7f;
    [SerializeField]
    private float spawnRange = 6.5f;

    void Awake()
    {
        Invoke(nameof(SpawnAcid), 0.5f);
    }

    private void SpawnAcid()
    {
        Rigidbody2D acidInstance;
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = Random.Range(spawnRange, -spawnRange);
        spawnPosition.y = spawnHeight;
        acidInstance = Instantiate(acid, spawnPosition, transform.rotation);
        acidInstance.name = "Acid(Clone)";
        acidInstance.velocity = Vector2.down * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Spongy"))
        {
            Destroy(gameObject);
        }
    }
}
