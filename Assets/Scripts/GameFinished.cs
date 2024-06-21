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
        Debug.Log("Završili ste igricu!"); // Prikaz poruke u konzoli
                                           // Možete dodati dodatne akcije ovde, kao što je prikazivanje UI poruke ili prelazak na drugu scenu
    }
}
