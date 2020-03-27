using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowScript : MonoBehaviour
{
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ennemy")
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            EnnemySpawner.score += 100;
        }
    }
}
