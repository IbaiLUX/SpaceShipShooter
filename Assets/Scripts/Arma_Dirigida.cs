/// <summary>
/// Arma_ dirigida.
/// Este script se encarga de rotar y mover el "disparo dirigido".
/// Este tipo de disparo cuando se crea apunta al jugador pero no se actualiza la rotacion hacia el jugador.
/// </summary>
using UnityEngine;
using System.Collections;

public class Arma_Dirigida : MonoBehaviour {
	//Velocidad del disparo
	public float miVelocidad;
	//Referencia al transform del jugador
	private Transform jugador;
	//Direccion del movimiento
	private Vector3 direccion;
	
	void Start () {
		//Recojo jugador.
		jugador = GameObject.FindGameObjectWithTag ("Player").transform;
		//La direccion del movimiento
		direccion = transform.position - jugador.position; 
		//Nuevo angulo.
		float angulo = Mathf.Atan2(direccion.x, direccion.y) * Mathf.Rad2Deg;
		//Asigno rotacion.
		transform.rotation = Quaternion.AngleAxis(angulo, -Vector3.forward);
	}

	void Update(){
		//Añado velocidad.
		rigidbody2D.velocity = new Vector2 (-direccion.x, -direccion.y) * miVelocidad;
	}
}
