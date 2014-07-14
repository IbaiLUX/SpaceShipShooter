/// <summary>
/// Arma_Bala.
/// Este script se encarga de mover la bala al ser instanciada, la bala se destrulle al salir del Trigger de "zona de juego".
/// </summary>
using UnityEngine;
using System.Collections;

public class Arma_Bala : MonoBehaviour {
	//La velocidad de la bala.
	public float miVelocidad;
	//Vector 2 de direccion de la bala, por defecto positivo en eje Y.
	public Vector2 direccion = new Vector2(0,1);

	void Update () {
		//Añado velocidad.
		rigidbody2D.velocity = direccion * miVelocidad;
	}
}
