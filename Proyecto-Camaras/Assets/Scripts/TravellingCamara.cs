using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellingCamara : MonoBehaviour
{
    public GameObject posHombro, posPanoramica, pov;
    GameObject objActual;
    public KeyCode botonCamara;
    bool esperar = false; 
    public bool moviendoCamara = false;
    float tiempoDelay = .65f, velocidad = 7.5f;
    const float kTiempoDeEspera = .65f;
    void Awake()
    {
        objActual = posPanoramica;
        gameObject.transform.localPosition = objActual.transform.position;
        gameObject.transform.localEulerAngles = objActual.transform.eulerAngles;
    }

    private void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (esperar == false) {

            if (Input.GetKeyDown(botonCamara)) {
                UnityEngine.Debug.Log("Se ha pulsado la tecla " + botonCamara);

                if (objActual == posHombro) {
                    objActual = posPanoramica;
                    moviendoCamara = true;
                    UnityEngine.Debug.Log("Nuevo destino: " + objActual.name);
                    esperar = true;

                } else if (objActual == posPanoramica) {
                    objActual = posHombro;
                    moviendoCamara = true;
                    UnityEngine.Debug.Log("Nuevo destino: " + objActual.name);
                    esperar = true;
                }
            }

        } else {
            if (tiempoDelay > 0f) {
                tiempoDelay -= Time.deltaTime;
            } else {
                esperar = false;
                tiempoDelay = kTiempoDeEspera;
            }

        }

        if (moviendoCamara == true) {

            if (Vector3.Distance(gameObject.transform.localPosition, objActual.transform.position) < .1f) {
                gameObject.transform.localPosition = objActual.transform.position;
            }

            if (gameObject.transform.localPosition != objActual.transform.position) {
                UnityEngine.Debug.Log(Vector3.Distance(gameObject.transform.localPosition, objActual.transform.position).ToString());
                gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, objActual.transform.position, velocidad * Time.deltaTime);
                Vector3 nuevaDireccion = Vector3.RotateTowards(gameObject.transform.forward, pov.transform.position - gameObject.transform.position, Mathf.PI * 2f, 0f);
                gameObject.transform.rotation = Quaternion.LookRotation(nuevaDireccion);

            } else {
                moviendoCamara = false;
            }

        } else {
            gameObject.transform.localPosition = objActual.transform.position;
            Vector3 nuevaDireccion = Vector3.RotateTowards(gameObject.transform.forward, pov.transform.position - gameObject.transform.position, Mathf.PI * 2f, 0f);
            gameObject.transform.rotation = Quaternion.LookRotation(nuevaDireccion);
        }
    }
}
