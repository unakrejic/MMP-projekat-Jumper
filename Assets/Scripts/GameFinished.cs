using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinished : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FinishGame();
        }

 
    }

    void FinishGame()
    {
        Debug.Log("Zavr�ili ste igricu!"); // Prikaz poruke u konzoli
                                           // Mo�ete dodati dodatne akcije ovde, kao �to je prikazivanje UI poruke ili prelazak na drugu scenu
    }
}
