using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teletransporte : MonoBehaviour
{
    public string sceneToLoad; // Nombre de la escena a la que quieres teletransportarte

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que colisiona es el jugador
        {
            SceneManager.LoadScene("MapaPueblo"); // Carga la escena especificada
        }
    }
}
