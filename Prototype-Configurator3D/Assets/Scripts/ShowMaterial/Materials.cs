using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{
    private void OnEnable()
    {
        // Suscribe la función al evento "OnCamisetaCambiada".
        ChangeShirt changeShirt = FindObjectOfType<ChangeShirt>();
        if (changeShirt != null)
        {
            changeShirt.OnCamisetaCambiada += MostrarCantidadDeMateriales;
        }
    }

    private void OnDisable()
    {
        // Desuscribe la función del evento al desactivar el script o el objeto.
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
            // Verifica si la camiseta está activa antes de mostrar los materiales.
            if (nuevaCamiseta.activeSelf)
            {
                // Obtén todos los Renderer en el objeto actual y sus hijos.
                Renderer[] renderers = GetComponentsInChildren<Renderer>();

                foreach (Renderer renderer in renderers)
                {
                    // Obtén la cantidad de materiales en el Renderer y muestra la información en la consola.
                    int cantidadDeMateriales = renderer.materials.Length;
                    Debug.Log("Cantidad de materiales en " + renderer.gameObject.name + ": " + cantidadDeMateriales);
                }
            }
        }
    }
}
