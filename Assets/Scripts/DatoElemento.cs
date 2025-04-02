using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TipoUsoElemento
{
    Hambre, Sed, Salud, Descanso
}
[CreateAssetMenu(fileName ="Elementos",menuName ="NuevoElemento")]
public class DatoElemento : ScriptableObject
{
    [Header("Info")]
    public string nombre;
    public string descripcion;
    public Sprite icono;
    public GameObject PrefabSoltar;

    public TipoUsoElemento tipo;
}
