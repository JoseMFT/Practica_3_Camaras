using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningCamara : MonoBehaviour
{
    float rotacionCamara = 0f;
    public KeyCode rotarDerecha, rotarIzquierda;
    public GameObject cocheAmarillo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotacionCamara > -50f && rotacionCamara < 50f) {
            if (Input.GetKey(rotarDerecha)) {
                rotacionCamara += Time.deltaTime * 45f;
            } else if (Input.GetKey(rotarIzquierda)) {
                rotacionCamara -= Time.deltaTime * 45f;
            }
        }

        if (!Input.GetKey(rotarDerecha) && !Input.GetKey(rotarIzquierda)) {
            if (rotacionCamara > 0) {
                rotacionCamara -= Time.deltaTime * 80f;
            } else if (rotacionCamara < 0) {
                rotacionCamara += Time.deltaTime * 80f;
            }
        }

        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, rotacionCamara, gameObject.transform.rotation.z);
        gameObject.transform.position = new Vector3(cocheAmarillo.transform.position.x, cocheAmarillo.transform.position.y + 1.95f, cocheAmarillo.transform.position.z);
    }
}
