using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanningCamara : MonoBehaviour
{
    float rotacionCamara = 0f, diferencia;
    public KeyCode rotarDerecha, rotarIzquierda;
    public GameObject cocheAmarillo;
    public Slider sliderPaneo;
    public float velocidadPaneo;

    private void Awake () {
        velocidadPaneo = sliderPaneo.value;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rotarDerecha) && rotacionCamara < 75f) {
            diferencia = Mathf.DeltaAngle(rotacionCamara, 75f);
            rotacionCamara += Time.deltaTime * diferencia * velocidadPaneo;

        } else if (Input.GetKey(rotarIzquierda) && rotacionCamara > -75f) {
            diferencia = Mathf.DeltaAngle(rotacionCamara, -75f);
            rotacionCamara += Time.deltaTime * diferencia * velocidadPaneo;

        } else if (!Input.GetKey(rotarDerecha) && !Input.GetKey(rotarIzquierda)) {
            diferencia = Mathf.DeltaAngle(rotacionCamara, 0f);
            rotacionCamara += Time.deltaTime * 5f * diferencia;
        }

        gameObject.transform.rotation = Quaternion.Euler(15f, rotacionCamara + 90f, gameObject.transform.rotation.z);
        gameObject.transform.position = new Vector3(cocheAmarillo.transform.position.x - .45f, cocheAmarillo.transform.position.y + 1.95f, cocheAmarillo.transform.position.z);
    }

    public void CambioVelocidadPaneo () {
        velocidadPaneo = sliderPaneo.value;
    }

    /*public float LerpDePosiciones (float posicionDelObjeto) {
        float x;
        x = Mathf.Lerp(posicionDelObjeto, Mathf.Round(posicionDelObjeto), Time.deltaTime);
        return x;
    }*/
}
