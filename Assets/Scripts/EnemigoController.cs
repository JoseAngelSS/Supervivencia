using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    public float speed = 3f; // Velocidad de movimiento del enemigo
    public float attackRange = 2f; // Rango de ataque del enemigo
    public int damage = 10; // Daño infligido por el enemigo

    private Transform player; // Referencia al transform del jugador

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontrar el transform del jugador
    }

    void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de ataque, mueve al enemigo hacia él
        if (distanceToPlayer <= attackRange)
        {
            // Mueve al enemigo hacia el jugador
            transform.LookAt(player);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        transform.Rotate(0f, 180f, 0f); // Rotar 180 grados alrededor del eje Y
    }
}
