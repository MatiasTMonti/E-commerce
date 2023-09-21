using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float velocidadRotacion = 2.0f; // Velocidad de rotación ajustable.
    public float limiteVerticalSuperior = 80.0f; // Límite de rotación vertical superior.
    public float limiteVerticalInferior = -80.0f; // Límite de rotación vertical inferior.

    private Vector3 inicioArrastre;
    private Vector3 inicioRotacion;
    private bool arrastrando = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inicioArrastre = Input.mousePosition;
            inicioRotacion = transform.eulerAngles;
            arrastrando = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            arrastrando = false;
        }

        if (arrastrando)
        {
            Vector3 diferenciaArrastre = Input.mousePosition - inicioArrastre;

            // Aplica restricciones a la rotación vertical.
            float rotacionVertical = inicioRotacion.x - diferenciaArrastre.y * velocidadRotacion;
            rotacionVertical = Mathf.Clamp(rotacionVertical, limiteVerticalInferior, limiteVerticalSuperior);

            Vector3 nuevaRotacion = new Vector3(rotacionVertical, inicioRotacion.y + diferenciaArrastre.x * velocidadRotacion, 0);
            transform.eulerAngles = nuevaRotacion;
        }
    }
}
