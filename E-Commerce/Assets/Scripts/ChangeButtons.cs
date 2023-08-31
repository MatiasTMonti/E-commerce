using UnityEngine;
using UnityEngine.UI;

public class ChangeButtons : MonoBehaviour
{
    [SerializeField] private ChangeModel changeModelScript; // Referencia al script ChangeModel.

    [SerializeField] private GameObject[] modelosPrefabricados; // Los modelos que deseas cargar.

    private void Start()
    {
        // Configura funciones para cada bot�n.
        for (int i = 0; i < modelosPrefabricados.Length; i++)
        {
            int indice = i; // Captura el �ndice en la variable local para evitar problemas de cierre.
            Button boton = transform.GetChild(i).GetComponent<Button>(); // Suponiendo que los botones est�n organizados como hijos de este objeto.

            boton.onClick.AddListener(() => CambiarModeloPorIndice(indice));
        }
    }

    private void CambiarModeloPorIndice(int indice)
    {
        // Aseg�rate de que el �ndice est� dentro de los l�mites.
        if (indice >= 0 && indice < modelosPrefabricados.Length)
        {
            changeModelScript.CambiarModelo(modelosPrefabricados[indice]);
        }
    }
}
