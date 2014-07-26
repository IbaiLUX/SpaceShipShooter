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

	public bool[] zonasDestruidas;

	//Vida del jefe despues de destruir zonas.
	public int vida = 20;

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
			Debug.Log("ROTOS");
		}
	}
}
