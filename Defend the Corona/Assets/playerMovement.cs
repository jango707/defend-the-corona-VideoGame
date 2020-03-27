using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 5f;

    private Animator animator;
    public GameObject cross;
    public GameObject arrowPrefab;

    private Vector2 movement;

    private bool endOfAiming;
    private float rate;
    private float firerate;

    public Canvas Death;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rate = 0.4f;
    }

    void Update()
    {
        if (firerate > -1) firerate -= Time.deltaTime;
        else firerate = -1;
       
        endOfAiming = Input.GetKeyDown("space");
        

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        Aim();
        if (firerate < 0)
        {
            Shoot();
            
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed *Time.fixedDeltaTime);
    }

    void Aim()
    {
        if(movement != Vector2.zero)
        {
            cross.transform.localPosition = movement * 3 ;
        }
        
    }
    void Shoot()
    {

        if (Input.GetKeyDown("space"))
        {
            if (animator.GetFloat("Vertical") > 0)
            {
                animator.SetBool("Shoot_up", true);
            }
            if (animator.GetFloat("Vertical") < 0)
            {
                animator.SetBool("Shoot_down", true);
            }
            if (animator.GetFloat("Horizontal") > 0)
            {
                animator.SetBool("Shoot_right", true);
            }
            if (animator.GetFloat("Horizontal") < 0)
            {
                animator.SetBool("Shoot_left", true);
            }

        }

        Vector2 shootingDir = cross.transform.localPosition;
        shootingDir.Normalize();

        if (endOfAiming)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = shootingDir * 10;
            arrow.transform.Rotate(0, 0, -90 + Mathf.Atan2(shootingDir.y, shootingDir.x) * Mathf.Rad2Deg);
            Destroy(arrow, 2.0f);

            firerate = rate;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ennemy")
        {
            //Time.timeScale = 0;
            gameObject.SetActive(false);
            Death.gameObject.SetActive(true);
           
        }
    }
}
