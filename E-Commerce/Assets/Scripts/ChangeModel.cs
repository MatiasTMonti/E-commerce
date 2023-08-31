using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{
    private GameObject modeloActual; // El modelo que está actualmente en la escena.

    public void CambiarModelo(GameObject nuevoModelo)
    {
        // Desactiva el modelo actual si existe.
        OcultarModelo();

        // Muestra el nuevo modelo.
        MostrarModelo(nuevoModelo);
    }

    private void MostrarModelo(GameObject nuevoModelo)
    {
        modeloActual = Instantiate(nuevoModelo, transform.position, transform.rotation);
    }

    private void OcultarModelo()
    {
        // Destruye el modelo actual si existe.
        if (modeloActual != null)
        {
            Destroy(modeloActual);
        }
    }
}