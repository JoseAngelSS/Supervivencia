using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ControlInventario;

public class ElementoEstanteriaUI : MonoBehaviour
{
    public Button boton;
    public Image icono;
    public TextMeshProUGUI textoCantidad;
    private ElementoEstanteria elementoActual;

    public int indice;

    public void Establecer(ElementoEstanteria elementoEstanteria)
    {

        elementoActual = elementoEstanteria;
        icono.gameObject.SetActive(true);
        icono.sprite = elementoEstanteria.elemento.icono;
        textoCantidad.text = elementoEstanteria.cantidad > 1 ? elementoEstanteria.cantidad.ToString() : string.Empty;

    }

    public void Limpiar()
    {
        elementoActual = null;
        icono.gameObject.SetActive(false);
        textoCantidad.text = string.Empty;
    }

    public void OnButtonClick()
    {
        ControlInventario.instancia.ElementoSeleccionado(indice);
    }
}
