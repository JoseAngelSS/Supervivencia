using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoElemento : MonoBehaviour, IInteractuable
{
    public DatoElemento elemento;
    ControlInventario controlInventario;

    private void Start()
    {
        controlInventario = GetComponent<ControlInventario>();
    }

    public string obtenerMensajeInteractuable()
    {

        return string.Format(format: "Obtener{0}", elemento.nombre);
    }
    public void OnInteracturar()
    {
        ControlInventario.instancia.AnadirElemento(elemento);
        Destroy(gameObject);
    }
}
 