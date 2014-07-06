/// <summary>
/// Bala_ movimiento.
/// Se encarga de mover la bala al ser instanciada.
/// </summary>
using UnityEngine;
using System.Collections;

public class Bala_Movimiento : MonoBehaviour {
	//La velocidad de la bala.
	public float miVelocidad;
	//Al instanciarse.
	void Start () {
		//Añado velocidad 
		rigidbody2D.velocity = new Vector2(0,1)*miVelocidad;
	}
}
