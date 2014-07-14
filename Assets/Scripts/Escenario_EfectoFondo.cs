/// <summary>
/// Escenario_EfectoFondo.
/// Este escript se encarga de crear el efecto fondo incrementando el offset del material.
/// El material estara inportado en "Wrap Mode = Repeat". 
/// </summary>
using UnityEngine;
using System.Collections;

public class Escenario_EfectoFondo : MonoBehaviour {

	//la velocidad del efecto
	public float velocidad = 1.5f;

	void Update () {
		//creo una variable que incrementa en funcion de la velocidad...
		float incremento = Time.time * velocidad;
		//el offset del material va incrementando.
		renderer.material.mainTextureOffset = new Vector2 (0,-incremento);
	}
}
