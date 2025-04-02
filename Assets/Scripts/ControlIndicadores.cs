 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ControlIndicadores : MonoBehaviour, IDeterioro
{
    public Indicadores salud;
    public Indicadores hambre;
    public Indicadores sed;
    public Indicadores descanso;

    public float reduccionSaludConHambre;
    public float reduccionSaludConSed;

    public UnityEvent onSufrirDeterioro;

    private void Start()
    {
        salud.valorActual = salud.valorInicial;
        hambre.valorActual = hambre.valorInicial;
        sed.valorActual = sed.valorInicial;
        descanso.valorActual = descanso.valorInicial;
    }

    private void Update()
    {
        hambre.Restar(hambre.indiceDeterioro * Time.deltaTime);
        sed.Restar(sed.indiceDeterioro * Time.deltaTime);
        descanso.Sumar(descanso.indiceRecuperacion * Time.deltaTime);

        if (hambre.valorActual == 0.0f)
            salud.Restar(reduccionSaludConHambre * Time.deltaTime);
        if (sed.valorActual == 0.0f)
            salud.Restar(reduccionSaludConSed * Time.deltaTime);

        if (salud.valorActual == 0.0f)
        {
            Morir();
        }

        salud.barraUI.fillAmount = salud.ObtenerPorcentaje();
        hambre.barraUI.fillAmount = hambre.ObtenerPorcentaje();
        sed.barraUI.fillAmount = sed.ObtenerPorcentaje();
        descanso.barraUI.fillAmount = descanso.ObtenerPorcentaje();
    }

    public void Recuperar(float cantidad)
    {
        salud.Sumar(cantidad);
    }

    public void Comer(float cantidad)
    {
        hambre.Sumar(cantidad);
    }
    public void Beber(float cantidad)
    {
        sed.Sumar(cantidad);
    }
    public void Descansar(float cantidad)
    {
        descanso.Restar(cantidad);
    }

    public void ProducirDeterioro(int cantidad)
    {
        salud.Restar(cantidad);
        onSufrirDeterioro?.Invoke();
    }


    public void Morir()
    {
        Debug.Log("Jugador ha muerto");
        SceneManager.LoadScene("MenuPrincipal");
    }
}

public interface IDeterioro
{
    void ProducirDeterioro(int cantidadDeterioro);
}



[System.Serializable]
public class Indicadores
{
    [HideInInspector]
    public float valorActual;
    public float valorMax;
    public float valorInicial;
    public float indiceRecuperacion;
    public float indiceDeterioro;
    public Image barraUI;

    public void Sumar(float cantidad)
    {
        valorActual = Mathf.Min(valorActual + cantidad, valorMax);
    }
    public void Restar(float cantidad)
    {
        valorActual = Mathf.Max(valorActual - cantidad, 0.0f);
    }
    public float ObtenerPorcentaje()
    {
        return valorActual / valorMax;
    }
}