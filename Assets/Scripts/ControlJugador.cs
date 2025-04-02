using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlJugador : MonoBehaviour
{
    private Vector2 ratonDelta;
    private float rotacionActualCamara;
    private Rigidbody fisica;
    [Header("Vista Cámara")]
    public Transform camara;
    public float maxXVista;
    public float minXVista;
    public float sensibilidadRaton;
    [Header("Movimientos")]
    public float velocidadMovimiento;
    private Vector2 movimientoActualEntrada;


    public float fuerzaSalto;
    public LayerMask capaSuelo;

    private bool puedeMirar = true;

    private void Awake()
    {
        fisica = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OnVistaInput(InputAction.CallbackContext context)
    {

        ratonDelta = context.ReadValue<Vector2>();

    }
    public void OnSaltoInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {

            if (EstaEnSuelo())
            {
                fisica.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);

            }
        }
    }
    public void OnMovimientoInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            movimientoActualEntrada = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            movimientoActualEntrada = Vector2.zero;
        }
    }
    private void LateUpdate()
    {
        // Es el que hay que usar cuando manipulamos la cámara
        if (puedeMirar == true)
            VistaCamara();
    }
    private void FixedUpdate()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        Vector3 direccion = transform.forward * movimientoActualEntrada.y + transform.right * movimientoActualEntrada.x;
        direccion *= velocidadMovimiento;
        direccion.y = fisica.velocity.y;
        fisica.velocity = direccion;

    }
    private void VistaCamara()
    {
        rotacionActualCamara += ratonDelta.y * sensibilidadRaton;
        rotacionActualCamara = Mathf.Clamp(rotacionActualCamara, minXVista, maxXVista);
        camara.localEulerAngles = new Vector3(-rotacionActualCamara, 0, 0);
        transform.eulerAngles += new Vector3(0, ratonDelta.x * sensibilidadRaton, 0);

    }
    bool EstaEnSuelo()
    {
        Ray[] rayos = new Ray[4]
        {
            new Ray(transform.position+ (transform.forward*0.5f)+(Vector3.up*0.01f),Vector3.down),
            new Ray(transform.position+ (-transform.forward*0.5f)+(Vector3.up*0.01f),Vector3.down),
            new Ray(transform.position+ (transform.right*0.5f)+(Vector3.up*0.01f),Vector3.down),
            new Ray(transform.position+ (-transform.right*0.5f)+(Vector3.up*0.01f),Vector3.down),
        };

        for (int i = 0; i < rayos.Length; i++)
        {
            
            if (Physics.Raycast(rayos[i], 1.05f, capaSuelo))
            {
                
                return true;
            }
        }

        return false;

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + (transform.forward * 0.5f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.forward * 0.5f), Vector3.down);
        Gizmos.DrawRay(transform.position + (transform.right * 0.5f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.right * 0.5f), Vector3.down);
    }

    public void PonerQuitarPunteroRaton(bool valor)
    {
        Cursor.lockState = valor ? CursorLockMode.None : CursorLockMode.Locked;
        puedeMirar = !valor;
    }
}
