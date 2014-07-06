/// <summary>
/// P j_ acelerador.
/// Este script se encarga de mostrar y ocultar el efecto de llama al acelerar.
/// </summary>
using UnityEngine;
using System.Collections;

public class PJ_EfectoAcelerador : MonoBehaviour {
	//Spite del efecto.
	public SpriteRenderer llama;

	void Update () {
		//Si la velocidad es diferente a cero...
		if (rigidbody2D.velocity != Vector2.zero) {
			//...muestro el efecto en color rojizo.
			llama.color = new Color (1, 0.3f, 0.3f, 1);
		}
		//...si es 0...
		else {
			//...no muestro el efecto.
			llama.color = new Color (1, 1, 1, 0);
		}
	}
}
