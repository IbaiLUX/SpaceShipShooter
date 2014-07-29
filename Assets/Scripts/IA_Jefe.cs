/// <summary>
/// I a_ jefe.
/// Este script se encarga de manejar el jefe de cada Nivel.
/// Tiene diferentes puntos de dipsaro y varias zonas a las que habra que disparar para derrotarlo.
/// </summary>
using UnityEngine;
using System.Collections;
using System.Linq;

public class IA_Jefe : MonoBehaviour {
	//Referencia a las zonas
	public IA_Jefe_ZonaDisparo[] misZonas;
	//Estan las zonas destruidas.
	public bool[] zonasDestruidas;
	//Fase final
	public bool fFinal = false;
	//Vida del jefe despues de destruir zonas.
	public int vida = 20;
	//Ataque del Jefe.
	public GameObject magiaJefe;
	//Posicion para magia.
	public Transform posMagia;
	//Ratio de disparo.
	public float ratioDisparo = .5f;
	//Almacen de tiempo para el siguiente disparo.
	private float proximoDisparo = 0.1f;
	//Efecto al ser destruido.
	public GameObject efectoFinal;

	// Use this for initialization
	void Start () {
		//Recojo las zonas.
		misZonas = GetComponentsInChildren<IA_Jefe_ZonaDisparo> ();
		//Creo el array.
		zonasDestruidas = new bool[misZonas.Length];
		//Le doy valor.
		for (int x=0; x<misZonas.Length; x++) {
			zonasDestruidas[x] = misZonas[x].destruido;		
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Actualizo el array.
		for (int x=0; x<misZonas.Length; x++) {
			zonasDestruidas[x] = misZonas[x].destruido;		
		}
		//Si todos son verdad...
		if (zonasDestruidas.All (b => b)) {
			//Es fase final de boss.
			fFinal = true;
		}
		//Durante la fase final...
		if (fFinal) {
			//...si esta en tiempo...
			if (Time.time >= proximoDisparo) {
				//...creo magia...
				GameObject go = (GameObject)Instantiate (magiaJefe, posMagia.position, Quaternion.identity);
				//...renombro.
				go.name = "Magia Jefe";
				//...actualizo tiempo.
				proximoDisparo = Time.time + ratioDisparo;
			}
			//...si la vida cae por debajo de 0...
			if(vida <= 0){
				//...creo el efecto de destruccion del enemigo.
				GameObject go = (GameObject)Instantiate (efectoFinal, transform.position, Quaternion.identity);
				//...renombro.
				go.name = "Efecto Final";
				//...lo destruto cuando termina la animacion.
				Destroy(go, 1);
				//...mando mensage a Escenario_Nivel
				gameObject.SendMessage("JefeDerrotado", SendMessageOptions.DontRequireReceiver);
				//...destruyo el jefe.
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		//Si es fase final y lo que dispara el trigger es la bala del jugador...
		if (fFinal && c.tag == "BalaJugador") {
			//...resto un punto de vida.
			vida = vida -1;
		}
	}
}
