using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigbridController : MonoBehaviour
{
    public float flapForce = 4f;
    public Rigidbody2D rb;
    private GameManager gameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        
        if (gameManager == null)
        {
            Debug.LogError("Không tìm thấy GameManager trong scene!");
        }
    }

    private void Update()
    {
        //bàn phím (Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }

        // chuột (click trái)
        if (Input.GetMouseButtonDown(0))
        {
            Flap();
        }

        //(mobile)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Flap();
        }
    }

    private void Flap()
    {
        if (Time.timeScale > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, flapForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }
}