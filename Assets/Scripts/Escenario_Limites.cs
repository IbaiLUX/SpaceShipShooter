/// <summary>
/// Escenario_ limites.
/// Este script se encarga de eliminar los objetos que salen del escenario de juego.
/// </summary> 
using UnityEngine;
using System.Collections;

public class Escenario_Limites : MonoBehaviour {

	//Cuando algun collider salga de este trigger...
	void OnTriggerExit2D(Collider2D other){
		//...lo destruyo.
		Destroy(other.gameObject);
	}
}
