using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{
    private void OnEnable()
    {
        // Suscribe la funci�n al evento "OnCamisetaCambiada".
        ChangeShirt changeShirt = FindObjectOfType<ChangeShirt>();
        if (changeShirt != null)
        {
            changeShirt.OnCamisetaCambiada += MostrarCantidadDeMateriales;
        }
    }

    private void OnDisable()
    {
        // Desuscribe la funci�n del evento al desactivar el script o el objeto.
        ChangeShirt changeShirt = FindObjectOfType<ChangeShirt>();
        if (changeShirt != null)
        {
            changeShirt.OnCamisetaCambiada -= MostrarCantidadDeMateriales;
        }
    }

    private void MostrarCantidadDeMateriales(GameObject nuevaCamiseta)
    {
        if (nuevaCamiseta == gameObject)
        {
            // Verifica si la camiseta est� activa antes de mostrar los materiales.
            if (nuevaCamiseta.activeSelf)
            {
                // Obt�n todos los Renderer en el objeto actual y sus hijos.
                Renderer[] renderers = GetComponentsInChildren<Renderer>();

                foreach (Renderer renderer in renderers)
                {
                    // Obt�n la cantidad de materiales en el Renderer y muestra la informaci�n en la consola.
                    int cantidadDeMateriales = renderer.materials.Length;
                    Debug.Log("Cantidad de materiales en " + renderer.gameObject.name + ": " + cantidadDeMateriales);
                }
            }
        }
    }
}
