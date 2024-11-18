using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Acid(Clone)")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Grime(Clone)")
        {
            Controller.score -= 20;
            Destroy(collision.gameObject);
        }
    }
}
