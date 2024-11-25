using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spongy : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

    private GUIStyle guiStyle = new GUIStyle();

    private int lives = 3;

    private int timerMinutes = 0;
    private int timerSeconds = 0;

    private float sideLimit;

    private Renderer spongyRenderer;
    private float spongyHalfWidth;

    private GameObject backgroundObject;
    private Renderer backgroundRenderer;
    private GameObject[] gameObjects;


    // Start is called before the first frame update
    void Start()
    {
        spongyRenderer = GetComponent<Renderer>();
        spongyHalfWidth = spongyRenderer.bounds.size.x / 2;

        backgroundObject = GameObject.Find("Bathroom");
        backgroundRenderer = backgroundObject.GetComponent<Renderer>();

        sideLimit = backgroundRenderer.bounds.size.x / 2;

        guiStyle.normal.textColor = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        // Moving Left
        if(Input.GetKey(KeyCode.A))
        {
            if(transform.position.x > -sideLimit + spongyHalfWidth)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }

        // Moving Right
        if(Input.GetKey(KeyCode.D))
        {
            if(transform.position.x < sideLimit - spongyHalfWidth)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collidingObjectName = collision.gameObject.name;
        string collidingObjectTag = collision.gameObject.tag;
        if(collidingObjectName.Equals("Acid(Clone)"))
        {
            lives--;
            if(lives <= 0)
            {
                RemovalGrime();
                RemovalAcid();
                Time.timeScale = 0;
            }
        }

        if(collidingObjectName.Equals("Grime(Clone)"))
        {
            Controller.score += 50;
        }

        if(collidingObjectTag.Equals("Soap"))
        {
            lives++;
            Destroy(collision.gameObject);
        }
    }

    private void OnGUI()
    {
        timerMinutes = (int) Time.time / 60;
        timerSeconds = (int) Time.time % 60;

        GUI.Box(new Rect(10, 10, 100, 30), "Time: " + timerMinutes + ":" + timerSeconds, guiStyle);
        GUI.Box(new Rect(10, 45, 100, 30), "Score: " + Controller.score, guiStyle);
        GUI.Box(new Rect(10, 80, 100, 30), "Lives: " + lives, guiStyle);
    }

    private void RemovalGrime()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Grime");
        foreach(GameObject grimeObject in gameObjects) Destroy(grimeObject);
    }

    private void RemovalAcid()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Acid");
        foreach(GameObject acidObject in gameObjects) Destroy(acidObject);
    }
}
