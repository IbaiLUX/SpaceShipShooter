/// <summary>
/// Arma_ laser.
/// Este script se encarga de mover el laser al ser instanciado, el laser se dirigira al enemigo mas cercano si lo hay, sino saldra recto.
/// Usa Linq para comparar la distancia enemigos y elegir el mas cercano como se indica en http://unitygems.com/linq-1-time-linq/
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Arma_Laser : MonoBehaviour {
	//Velocidad si va recto.
	public float miVelocidad = 5.5f;
	//Mi enemigo.
	private GameObject miEnemigo = null;
	//Para saber si va dirigido al enemigo o no.
	private bool dirigido;

	void Start(){
		//Busco los enemigos y los guardo en "almacen".
		GameObject[] enemigos = GameObject.FindGameObjectsWithTag ("Enemigo");
		//Si hay enemigos en el "almacen"...
		if (enemigos.Length != 0) {
			//...busco el enemigo mas cercano.
			miEnemigo = GameObject.FindGameObjectsWithTag ("Enemigo")
				.Aggregate ((current, next) => Vector3.Distance (current.transform.position, transform.position) < Vector3.Distance (next.transform.position, transform.position) 
				? current : next);
			//Si la distancia al enemigo es menor que 5...
			if (Vector3.Distance (transform.position, miEnemigo.transform.position) < 5) {
				//...el laser ira dirigido al enemigo.
				dirigido = true;
			//...si la distancia es mayor...
			} else {
				//...saldra recto.
				dirigido = false;
			}
		//Si no hay enemigos en escena...
		}else{
			//...saldra recto.
			dirigido = false;
		}
	}

	void Update(){
		//Si es dirigido...
		if (dirigido) {
			//La direccion del movimiento
			Vector3 direccion = transform.position - miEnemigo.transform.position; 
			//Nuevo angulo.
			float angulo = Mathf.Atan2(direccion.x, direccion.y) * Mathf.Rad2Deg;
			//Asigno rotacion.
			transform.rotation = Quaternion.AngleAxis(angulo, -Vector3.forward);
			//Añado velocidad.
			rigidbody2D.velocity = new Vector2 (-direccion.x, -direccion.y)*miVelocidad;
		//...si no es dirigido...
		} else {
			//... saldra hacia la parte superior de la zona de juego.
			transform.Translate(Vector3.up*Time.deltaTime*miVelocidad*3);	
		}
	}
}
