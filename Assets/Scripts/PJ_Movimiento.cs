/// <summary>
/// P j_ movimiento.
/// Se encarga de mover al jugador mediante teclado.
/// Se usa un sprite que hace de sombra de la nave para dar la impresion de "paneo" y "tileo" de la nave.
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
	//Transform que simula la sombra de la nave.
	public Transform sombra;

	void Update(){
		//Si la nave va hacia la derecha...
		if (rigidbody2D.velocity.x > 0) {
			//...la sombra se desplaza a la izq.
			sombra.localPosition = new Vector3(-.1f,-.1f,0);		
		}
		//Si la nave va hacia la izquierda...
		if (rigidbody2D.velocity.x < 0) {
			//...la sombra se desplaza a la der.
			sombra.localPosition = new Vector3(.1f,-.1f,0);
		}
		//Si la nave va hacia arriba...
		if (rigidbody2D.velocity.y > 0) {
			//...la sombra se desplaza abajo.
			sombra.localPosition = new Vector3(0,-.2f,0);
		}
		//Si la nave va hacia abajo...
		if (rigidbody2D.velocity.y < 0) {
			//...la sombra se desplaza arriba.
			sombra.localPosition = new Vector3(0,.2f,0);	
		}
		//Si no se mueve...
		if (rigidbody2D.velocity == Vector2.zero) {
			//...la sombra se mantiene un poco atras.
			sombra.localPosition = new Vector3(0,-.1f,0);	
		}

	}
	
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
