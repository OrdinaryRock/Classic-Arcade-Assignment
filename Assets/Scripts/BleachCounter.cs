using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleachCounter : MonoBehaviour
{
    [SerializeField] private GameObject spriteTemplate;
    [SerializeField] private Sprite silhouetteSprite;
    [SerializeField] private Sprite displaySprite;
    [SerializeField] private int spriteCount;
    [SerializeField] private float horizontalSpacing;

    private int bleachCollected = 0;

    private List<GameObject> spriteArray = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        spriteCount = Controller.maxBleachCollected;
        for(int i = 0; i < spriteCount; i++)
        {
            Vector3 spawnPosition = transform.position + Vector3.left * i * horizontalSpacing;
            GameObject spriteInstance = Instantiate(spriteTemplate, spawnPosition, spriteTemplate.transform.rotation);
            spriteInstance.transform.SetParent(transform);
            spriteArray.Add(spriteInstance);
        }
        spriteTemplate.SetActive(false);
    }

    public void AddBleach()
    {
        if (bleachCollected < spriteCount) bleachCollected++;
        spriteArray[bleachCollected - 1].GetComponent<SpriteRenderer>().sprite = displaySprite;
    }

    public void UseBleach()
    {
        if (bleachCollected > 0)
        { 
            bleachCollected--;
            spriteArray[bleachCollected].GetComponent<SpriteRenderer>().sprite = silhouetteSprite;
            RemoveAcid();
        }
    }

    private void RemoveAcid()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Acid");
        foreach (GameObject acidObject in gameObjects) Destroy(acidObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
