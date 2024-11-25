using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleachCounter : MonoBehaviour
{
    [SerializeField] private GameObject spriteTemplate;
    [SerializeField] private int spriteCount;
    [SerializeField] private float horizontalSpacing;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
