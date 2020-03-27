using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject Player;

    public static float ennemySpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        ennemySpeed = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 center = new Vector2(Mathf.MoveTowards(transform.position.x, Player.transform.position.x, ennemySpeed * Time.deltaTime), Mathf.MoveTowards(transform.position.y, Player.transform.position.y, ennemySpeed* Time.deltaTime));
        rb.MovePosition(center);
    }
}
