using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 4 privatne varijable
    private float horizontal;
    private float speed = 3f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;
    // referenciranje na komponente
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        // vraca -1 || 0 || 1 u zavisnosti od pravca kretanja
        horizontal = Input.GetAxisRaw("Horizontal");
        // ako pritisnemo space i player je na zemlji
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // postavljamo vrednost Ya za Velocity u okviru Rigidbody 2D na vrednost jumpingPower
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        // pozivamo nasu kreiranu metodu
        Flip();
    }

    private void FixedUpdate()
    {
        // postavljamo vrednost Xa za Velocity u okviru Rigidbody 2D
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    // metoda da proveri da li je player na zemlji
    private bool IsGrounded()
    {
        // vraca true ili false da li moze player skociti
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    // metoda da nam okrene player-a
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            // postavljamo suprotnu vrednost
            isFacingRight = !isFacingRight;
            // uzimamo vrednost za scale of player-a
            Vector3 localScale = transform.localScale;
            // mnozimo X komponentu Scale-a za playera sa -1
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
