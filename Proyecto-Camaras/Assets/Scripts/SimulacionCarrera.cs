using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulacionCarrera : MonoBehaviour
{
    float posEnZCoche = 0f, valorLeanTween = 0f, prevPosEnZ;
    public float nuevaPosEnZ, tiempoDeDesplazamiento;
    bool desplazando = false;
    Rigidbody rb;
    
    void Start()
    {
        prevPosEnZ = posEnZCoche; 
    }

    // Update is called once per frame
    void Update()
    {
        if (desplazando == false) {
            desplazando = true;
            nuevaPosEnZ = Random.Range(-5f, 5f);
            tiempoDeDesplazamiento = nuevaPosEnZ * 1.5f;

            LeanTween.value(valorLeanTween, nuevaPosEnZ, tiempoDeDesplazamiento).setEaseInOutCubic().setOnUpdate((x) => {
                posEnZCoche = x;
            }).setOnComplete(()=> {
                valorLeanTween = 0f;
                desplazando = false;
            });
        }

        prevPosEnZ = posEnZCoche;
    }
    private void FixedUpdate () {
        if (LeanTween.isTweening(gameObject) == true) {
            //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, posEnZCoche);
            rb.MovePosition(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, posEnZCoche - prevPosEnZ));
        }
    }

    public void MovimientoCoches (float movimientoEnZDelCoche) {

    }
}
