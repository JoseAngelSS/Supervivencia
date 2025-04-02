using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlador : MonoBehaviour
{
    public void EscenaTutorial()
    {
        SceneManager.LoadScene("MapaTutorial");
    }

   public void EscenaJuego()
   {
       SceneManager.LoadScene("MapaPueblo");
   }

    public void botonSalir()
    { 
        Application.Quit();
    }
}
