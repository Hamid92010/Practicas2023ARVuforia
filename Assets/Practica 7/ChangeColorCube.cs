using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCube : MonoBehaviour
{

    // Referencia al componente MeshRenderer del cubo
    private MeshRenderer meshRenderer;

    // Referencia al componente boxCollider del cubo
    private BoxCollider boxCollider;

    // Array de colores a usar
    public Color[] colors;

    // Variables de control de cambio de color
    private bool isColliderActive = true;
    public int ent = 0;

    //Variable de control de rotación
    private bool isRotating = false;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }


    // Update is called once per frame
    void Update()
    {

        // Verificar si el box collider está activo o no
        if (GetComponent<BoxCollider>().enabled != isColliderActive)
        {
            isColliderActive = !isColliderActive;
            ent = ent + 1;

            if (ent > 2)
            {
                ent = 0;
            }

            // Cambiar el color del cubo
            if (!isColliderActive && ent <= 2)
            {
                // Seleccionar un color aleatorio del array de colores
                Color newColor = colors[ent];
                meshRenderer.material.color = newColor;
            }
        }
        
        //Rotación de cubo
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = !isRotating;
        }
        if (isRotating)
        {
            transform.Rotate(0, Time.deltaTime * 100, 0);
        }
    }

    public void OnPointerClick()
    {
        isRotating = !isRotating;
    }
}
