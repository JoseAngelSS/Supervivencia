using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaVenenosa : MonoBehaviour
{
    public int cantidadVeneno;
    public float indiceDeterioro;
    private List<IDeterioro> listaParaDeteriorar = new List<IDeterioro>();


    private void Start()
    {
        StartCoroutine(ManejarDeterioro());
    }

    IEnumerator ManejarDeterioro()
    {
        while (true)
        {
            for (int i = 0; i < listaParaDeteriorar.Count; i++)
            {
                listaParaDeteriorar[i].ProducirDeterioro(cantidadVeneno);
            }

            yield return new WaitForSeconds(indiceDeterioro);
        }
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IDeterioro>() != null)
        {
            listaParaDeteriorar.Add(collision.gameObject.GetComponent<IDeterioro>());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<IDeterioro>() != null)
        {
            listaParaDeteriorar.Remove(collision.gameObject.GetComponent<IDeterioro>());
        }
    }
}
