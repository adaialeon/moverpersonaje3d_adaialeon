using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    //almacenar posición del personaje
    public Transform player;

    void LateUpdate()
    {
        //para que la camara siga al personaje en el minimapa
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);

        //que el mapa rote hacia donde mire el personaje
        transform.rotation = Quaternion.Euler(90, player.eulerAngles.y, 0);
    }
}
