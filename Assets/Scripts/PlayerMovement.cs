using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 4 privatne varijable
    private float horizontal; // Za horizontlano kretanje
    private float speed = 3f; // Brzina kretanja
    private float jumpingPower = 12f; // Snaga skoka
    private bool isFacingRight = true; // Da li je okrenut udesno
    // referenciranje na komponente
    [SerializeField] private Rigidbody2D rb; // Rigidbody2D komponenta za fiziku
    [SerializeField] private Transform groundCheck; // Transform komponenta za proveru tla
    [SerializeField] private LayerMask groundLayer; // LayerMask za sloj tla

    void Update()
    {
        // Uzimanje horizontalnog inputa (-1, 0, 1)
        // vraca -1 || 0 || 1 u zavisnosti od pravca kretanja, -1 za levo a 1 za desno
        horizontal = Input.GetAxisRaw("Horizontal");
        // Proverava da li je pritisnut taster za skok i da li je igrač na zemlji
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // postavljamo vrednost Ya za Velocity u okviru Rigidbody 2D na vrednost jumpingPower
            // Postavljanje vertikalne brzine za skok
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        // pozivamo nasu kreiranu metodu
        Flip();
    }

    private void FixedUpdate()
    {
        // postavljamo vrednost Xa za Velocity u okviru Rigidbody 2D
          // Postavljanje horizontalne brzine
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    // metoda da proveri da li je player na zemlji
    private bool IsGrounded()
    {
        // vraca true ili false da li moze player skociti, tj vraca true ako je igrac na sloju tla
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    // metoda da nam okrene player-a
    private void Flip()
    {
        // Proverava da li igrač treba da se okrene
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            // postavljamo suprotnu vrednost, menja smer igraca
            isFacingRight = !isFacingRight;
            // uzimamo vrednost za scale of player-a
            Vector3 localScale = transform.localScale;
            // mnozimo X komponentu Scale-a za playera sa -1
            localScale.x *= -1f;
            // Primena nove scale-a
            transform.localScale = localScale;
        }
    }
}
