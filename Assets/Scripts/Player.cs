using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private float moveSpeed = 5f;
    private Vector2 movePos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        movePos.x = Input.GetAxisRaw("Horizontal");
        movePos.y = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(movePos.x * moveSpeed, movePos.y * moveSpeed);

        AstarPath.active.Scan();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (GameManager.lives > 0)
            {
                GameManager.lives--;
                GameManager.isBuffed = false;
                SceneManager.LoadScene("Main");
            }
            else
                SceneManager.LoadScene("Highscore");
        }

        if (collision.gameObject.tag == "Food")
        {
            StartCoroutine(AteFood());

            Destroy(collision.gameObject);
            GameManager.SetScore(10);

            StopCoroutine(AteFood());
        }
    }

    private IEnumerator AteFood()
    {
        GameManager.isBuffed = true;

        yield return new WaitForSeconds(10f);

        GameManager.isBuffed = false;
    }
}
