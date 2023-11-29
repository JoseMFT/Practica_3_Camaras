using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertigo : MonoBehaviour
{
    float distFocalOg;
    Vector3 posicionOg;
    Camera myCamera;
    // Start is called before the first frame update
    private void Awake () {
        myCamera = gameObject.GetComponent<Camera>();
        posicionOg = gameObject.transform.position;
        distFocalOg = myCamera.fieldOfView;
    }

    void Start()
    {
        float distanciaFocal = distFocalOg;
        Vector3 posicion = posicionOg;
        LeanTween.value(distanciaFocal, 90f, 1f).setEaseInOutCubic().setLoopPingPong().setOnUpdate((x) => {
            myCamera.fieldOfView = x;
            gameObject.transform.position = new Vector3(-100f + x, posicion.y, posicion.z);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }


}
