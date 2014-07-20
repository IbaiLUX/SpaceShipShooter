﻿/// <summary>
/// IA_ enemigo1.
/// Este script se encarga de mover el enimgo y del ataque.
/// Tiene diferentes tipos de movimiento y ataques.
/// **NOTA**
/// Si velocidad es 0 no se movera en ola.
/// </summary>
using UnityEngine;
using System.Collections;

public class IA_Enemigo : MonoBehaviour {
	//Posibles movimientos enemigos.
	public enum TiposMovimiento {Simple,Ola};
	//Movimiento de esta unidad.
	public TiposMovimiento miMovimiento = TiposMovimiento.Simple;
	//Amplitud del movimiento en ola en X
	public float amplitud = 4.0f;
	//Tipos de disparos.
	public enum TiposDisparo{Simple, Dirigido};
	//Disparo de esta unidad.
	public TiposDisparo miDisparo = TiposDisparo.Simple;
	//La velocidad del enemigo.
	public float velocidad = 0.5f;
	//Prefab del disparo simple.
	public GameObject disparoSimple;
	//Prefab del disparo dirigido.
	public GameObject disparoDirigido;
	//Transform de donde sale el disparo.
	public Transform posDisparo;
	//Ratio de disparo.
	public float ratioDisparo = .5f;
	//Almacen de tiempo para el siguiente disparo.
	private float proximoDisparo = 0.1f;
	//Vector 2 de direccion del enemigo, por defecto negativo en eje Y.
	public Vector2 direccion;
	//Efecto al ser destruido.
	public GameObject explosion;
	//Posibles premios al matarlo.
	public GameObject premio;

	void Update () {
		//Si puedo disparar...
		if (Time.time > proximoDisparo) {
			//...añado tiempo para proximoDisparo.
			proximoDisparo = Time.time + ratioDisparo;
			//Dependiendo del tipo de disparo...
			switch(miDisparo){
				//...si es simple...
				case TiposDisparo.Simple:
					//...instancio el prefab del disparo.
					GameObject disparoS = (GameObject)Instantiate(disparoSimple, posDisparo.position, Quaternion.identity);
					//...renombro.
					disparoS.name = "DisparoEnemigo";
				return;
				//...si es dirigido...
				case TiposDisparo.Dirigido:
					//...instancio el prefab del disparo.
					GameObject disparoD = (GameObject)Instantiate(disparoDirigido, posDisparo.position, Quaternion.identity);
					//...renombro.
					disparoD.name = "DisparoEnemigo";
				return;
			}
		}
		//Dependiendo del tipo de movimiento...
		switch(miMovimiento){
			//...si es simple...
			case TiposMovimiento.Simple:
				//...la direccion del enemigo es la de defecto.
				direccion = new Vector2(0,-1);
				//...añado velocidad.
				rigidbody2D.velocity = direccion * velocidad;
			return;
			//...si es en forma de ola...
			case TiposMovimiento.Ola:
				//...para moverse en forma de ola direccion en X varia de amplitud a -amplitud
				direccion = new Vector2((Mathf.PingPong(Time.time*velocidad, amplitud) - (amplitud/2)),-velocidad);
				//...añado velocidad.
				rigidbody2D.velocity = direccion * velocidad;
			return;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		//Si el objeto que dispara el trigger es la bala...
		if (other.tag == "BalaJugador") {
			//...destruyo la bala.
			Destroy(other.gameObject);
			//...creo el efecto de explosion.
			GameObject go = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
			//...el efecto de explosion se autodestruye en 1s(duracion de la animacion).
			Destroy(go,1);
			//...creo posible premio.
			GameObject pr = (GameObject)Instantiate(premio,transform.position,Quaternion.identity);
			//...renombro.
			pr.name = "Premio";
			//...destruyo enemigo.
			Destroy(gameObject);
		}
		//Si el objeto que dispara el trigger es el escudo y su render esta activo...
		if (other.tag == "Escudo" && other.gameObject.GetComponent<SpriteRenderer>().enabled == true) {
			//...creo el efecto de explosion.
			GameObject go = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
			//...el efecto de explosion se autodestruye en 1s(duracion de la animacion).
			Destroy(go,1);
			//...destruyo enemigo.
			Destroy(gameObject);
		}
	}
}
