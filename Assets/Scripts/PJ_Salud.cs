/// <summary>
/// P j_ salud.
/// Este script se encarga de manejar la vida e invulnerabilidad del jugador.
/// </summary>
using UnityEngine;
using System.Collections;

public class PJ_Salud : MonoBehaviour {
	//Vidas del jugador.
	public int vidasJugador = 3;
	//Efecto al ser destruido.
	public GameObject efectoDestruccion;
	//Soy invulnerable.
	public bool invulnerable = false;
	//Tiempo de invulnerabilidad.
	public float tInvulnerable = 0.9f;
	//Almacen tiempo
	private float tProxInvulnerable;
	//Referencia al animator
	private Animator anim;

	// Use this for initialization
	void Start () {
		//Asigno tiempo.
		tProxInvulnerable = Time.time + tInvulnerable;
		//Asigno animator.
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Si soy invulnerable y a pasado el tiempo...
		if (invulnerable && Time.time >= tProxInvulnerable) {
			//...ya no soy invulnerable.
			invulnerable = false;		
		}
		//Paso invulnerable al animator
		anim.SetBool ("Invulnerable", invulnerable);
		//Si la vida cae por debajo de cero...
		if (vidasJugador <= 0) {
			//...creo efecto.
			GameObject go = (GameObject)Instantiate(efectoDestruccion, transform.position,Quaternion.identity);
			//...destruyo efecto.
			Destroy(go,1);
			//...destruyo jugador.
			Destroy(gameObject);
			//...estado GameOver.
			Debug.Log("GAME OVER");
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		//Si lo que dispara el trigger es la bala enemiga y no soy invulnerable...
		if (c.tag == "BalaEnemiga" && !invulnerable) {
			//...resto una vida.
			vidasJugador = vidasJugador - 1;
			//...me hago invulnerable.
			invulnerable = true;
			//...actualizo tiempo.
			tProxInvulnerable = Time.time + tInvulnerable;
			//...cambio el disparo.
			gameObject.GetComponent<PJ_Disparo>().disparoActual = PJ_Disparo.TiposDisparo.simple;
			//...creo efecto.
			GameObject go = (GameObject)Instantiate(efectoDestruccion, transform.position,Quaternion.identity);
			//...destruyo.
			Destroy(go,1);
		}
	}
}
