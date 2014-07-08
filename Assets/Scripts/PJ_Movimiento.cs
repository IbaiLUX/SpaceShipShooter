/// <summary>
/// P j_ movimiento.
/// Se encarga de mover al jugador mediante teclado.
/// </summary>
using UnityEngine;
using System.Collections;

public class PJ_Movimiento : MonoBehaviour {
	//Velocidad de la nave.
	public float velocidad = .8f;
	//Limites de movimiento del jugador en eje X, X sera minimo, Y sera maximo.
	public Vector2 limitesX = new Vector2 (5, 5);
	//Limites de movimiento del jugador en eje Y, X sera minimo, Y sera maximo.
	public Vector2 limitesY = new Vector2 (5, 5);
		
	void FixedUpdate(){
		//Recojo entrada de jugador en X.
		float movientoX = Input.GetAxis ("Horizontal");
		//Recojo entrada de jugador en Y.
		float movientoY = Input.GetAxis ("Vertical");
		//La direccion del jugador.
		Vector2 direccion = new Vector2 (movientoX, movientoY);
		//Muevo el jugador.
		rigidbody2D.velocity = direccion * velocidad;
		//Limito el movimiento.
		rigidbody2D.position = new Vector2 (Mathf.Clamp(rigidbody2D.position.x,limitesX.x,limitesX.y),Mathf.Clamp(rigidbody2D.position.y,limitesY.x,limitesY.y));

	}
}
