using UnityEngine;
using System.Collections.Generic;
using System;

public class ChangeShirt : MonoBehaviour
{
    private List<GameObject> camisetas = new List<GameObject>();
    public event Action<GameObject> OnCamisetaCambiada;

    private void Start()
    {
        FindCamisetas();

        // Desactiva todas las camisetas al inicio.
        foreach (var camiseta in camisetas)
        {
            camiseta.SetActive(false);
        }
    }

    public void CambiarCamiseta(int indiceCamiseta)
    {
        if (indiceCamiseta >= 0 && indiceCamiseta < camisetas.Count)
        {
            foreach (var camiseta in camisetas)
            {
                camiseta.SetActive(false);
            }

            GameObject nuevaCamiseta = camisetas[indiceCamiseta];
            nuevaCamiseta.SetActive(true);

            // Dispara el evento y notifica que se ha cambiado la camiseta.
            if (OnCamisetaCambiada != null)
            {
                OnCamisetaCambiada.Invoke(nuevaCamiseta);
            }
        }
    }

    private void FindCamisetas()
    {
        // Busca automáticamente todos los objetos con la etiqueta "Camiseta" en la escena.
        GameObject[] camisetaObjects = GameObject.FindGameObjectsWithTag("Camiseta");

        // Agrega los objetos encontrados a la lista de camisetas.
        foreach (var camisetaObject in camisetaObjects)
        {
            camisetas.Add(camisetaObject);
        }
    }
}
