using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicadorDeterioro : MonoBehaviour
{
    public Image imagenMarco;
    public float velocidadAparicion;

    private Coroutine desaparecer;
   public void Aparecer()
    {
        if(desaparecer != null)
        {
            StopCoroutine(desaparecer);
        }
        imagenMarco.enabled = true;
        imagenMarco.color = Color.white;
        desaparecer = StartCoroutine(Desaparecer());
    }
    IEnumerator Desaparecer()
    {
        float alpha = 1.0f;
        while (alpha > 0.0f)
        {
            alpha -= (1.0f/velocidadAparicion)*Time.deltaTime;
            imagenMarco.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            yield return null;
        }
        imagenMarco.enabled = false;
    }
}
