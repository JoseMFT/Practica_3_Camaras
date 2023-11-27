using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    private CharacterController controlador;
    Vector3 movimiento, movHorizontal, movFrontal;
    Vector2 mouseDelta, smoothCamara, movCamara;
    Animator animador;
    bool quieto;
    float velocidadMov = 3f, sensibilidadCamara = 3f, smoothing = 2f;
    public KeyCode correr;
    // Start is called before the first frame update


    void Awake () {
        controlador = gameObject.GetComponent<CharacterController>();
        animador = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta *= sensibilidadCamara * smoothing;

        movHorizontal = transform.right * Input.GetAxis("Horizontal");
        movFrontal = transform.forward * Input.GetAxis("Vertical");
        movimiento = (movHorizontal + movFrontal).normalized;

        if (Input.GetKey(correr)) {
            controlador.Move(movimiento * Time.deltaTime * velocidadMov * 1.5f);
        } else {
            controlador.Move(movimiento * Time.deltaTime * velocidadMov);
        }

        smoothCamara = Vector2.Lerp(smoothCamara, mouseDelta, 1f / smoothing);
        movCamara += smoothCamara;

        /*if (movCamara.y > -40f && movCamara.y < 60f) {
            transform.localRotation = Quaternion.AngleAxis(-movCamara.y, Vector3.right);
        }*/
        controlador.transform.localRotation = Quaternion.AngleAxis(movCamara.x, gameObject.transform.up);
    }
}
