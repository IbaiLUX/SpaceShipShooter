/// <summary>
/// I a_ jefe_ zona disparo.
/// Este script maneja los impactos en el escudo y muestra un efecto al ser destruido.
/// </summary>
using UnityEngine;
using System.Collections;

public class IA_Jefe_ZonaDisparo : MonoBehaviour {
	//Catidad de impactos necesarios para destruirlo.
	public int vidaEscudo = 5;
	//Estoy destruido.
	public bool destruido = false;
	//Efecto al ser destruido.
	public GameObject efectoEscudoDestruido;

	void Start(){
		//Desactivo el efecto.
		efectoEscudoDestruido.SetActive (false);
	}

	void Update () {
		//Si la vida del escudo es igual o menor que cero...
		if (vidaEscudo <= 0) {
			//... esta destruido.
			destruido = true;		
		}
		//Si el escudo esta destruido...
		if (destruido) {
			//...muestro el efecto.
			efectoEscudoDestruido.SetActive(true);		
		}
	}
	
	void OnTriggerEnter2D(Collider2D c){
		//Si el collider que dispara el trigger es la bala del jugador...
		if (c.tag == "BalaJugador") {
			//...resto 1 punto de vida al escudo.
			vidaEscudo = vidaEscudo -1;		
		}
	}
}
