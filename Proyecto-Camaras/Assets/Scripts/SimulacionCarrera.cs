using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulacionCarrera : MonoBehaviour
{
    float valorLeanTween = 0f, posDespuesDesplazamiento = 0f;
    public float nuevaPos, tiempoDeDesplazamiento, desplazamientoCoche;
    bool desplazando = false;
    
    void Start()
    {
       LeanTween.value (valorLeanTween, desplazamientoCoche, desplazamientoCoche * 1.5f).setEaseInOutCubic().setLoopPingPong().setOnUpdate((x)=> {
           gameObject.transform.position = new Vector3(0f + x, gameObject.transform.position.y, gameObject.transform.position.z);
       }).setOnComplete(()=> {
           valorLeanTween = 0f;
       });
    }

    // Update is called once per frame
    void Update()
    {
        /*if (desplazando == false) {
            desplazando = true;
            nuevaPos = Random.Range(-5f, 5f);
            tiempoDeDesplazamiento = nuevaPos * 1.5f;

            LeanTween.value(valorLeanTween, nuevaPos, tiempoDeDesplazamiento).setEaseInOutCubic().setOnUpdate((x) => {
                gameObject.transform.position = new Vector3(posDespuesDesplazamiento + x, gameObject.transform.position.y, gameObject.transform.position.z);
            }).setOnComplete(()=> {
                posDespuesDesplazamiento = gameObject.transform.position.x;
                valorLeanTween = 0f;
                desplazando = false;
            });
        }*/
    }

}
