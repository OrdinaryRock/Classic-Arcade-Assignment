using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Acid"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("Soap"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("Grime"))
        {
            Controller.score -= 20;
            Destroy(collision.gameObject);
        }
    }
}
