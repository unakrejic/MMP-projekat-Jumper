using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinished : MonoBehaviour
{
    // Ova metoda se poziva kada neki objekat uđe u 2D Collider koji je postavljen kao IsTrigger
     private void OnTriggerEnter2D(Collider2D collision)
    {
        // Proverava da li objekat koji je ušao u koliziju ima tag "Player"
        if (collision.CompareTag("Player"))
        {
            // Ako objekat ima tag "Player", poziva se metoda FinishGame
            FinishGame();
        }

 
    }

    void FinishGame()
    {
        Debug.Log("Zavr�ili ste igricu!"); // Prikaz poruke u konzoli u Unity programu
    }
}
