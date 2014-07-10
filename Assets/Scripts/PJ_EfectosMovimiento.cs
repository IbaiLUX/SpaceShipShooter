/// <summary>
/// P j_ acelerador.
/// Este script se encarga de mostrar y ocultar el efecto de llama al acelerar.
/// Este script se encarga de mover la sombra para dar efecto "paneo" y "tileo".
/// </summary>
using UnityEngine;
using System.Collections;

public class PJ_EfectosMovimiento : MonoBehaviour {
	//Spite del efecto.
	public SpriteRenderer llama;
	//Transform que simula la sombra de la nave.
	public Transform sombra;

	void Update () {
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
			sombra.localPosition = new Vector3(0,.1f,0);	
		}
		//Si la velocidad es diferente a cero...
		if (rigidbody2D.velocity != Vector2.zero) {
			//...muestro el efecto.
			llama.renderer.enabled = true;

		}
		//...si es 0...
		else {
			//...no muestro el efecto.
			llama.renderer.enabled = false;
			//...la sombra se queda ligeramente atras.
			sombra.localPosition = new Vector3(0,-.1f,0);		
		}
	}
}
