using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    //controlar el personaje
    CharacterController controller;

    //controlar la camara primera persona
    public Transform fpsCamera;

    //controlar la sensibilidad y la velocidad del personaje
    public float sensitivity = 200f;
    public float speed = 15f;

    //almacenar el float xrotation
    public float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //cuando hacemos click se bloquea 
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //movimiento de la camara con el ratón
        float mouseX = Input.GetAxis ("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis ("Mouse Y") * sensitivity * Time.deltaTime;

        //que el personaje rote sobre si mismo
        transform.Rotate(Vector3.up * mouseX);

        //modifica la posición del ratón (ej. del 0 al -140)
        xRotation -= mouseY;

        //limites para la rotacion camara (arriba y abajo)
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //este no funciona porque no mueve la posaicion de la camara de 0
        //fpsCamera.rotation = Quaternion(Euler.mouseY, 0, 0);
        //transform.Rotate(Vector3.up * mouseX);

        fpsCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}
