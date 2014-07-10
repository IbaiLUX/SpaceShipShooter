/// <summary>
/// P j_ disparo.
/// Este script se encarga de la accion de disparar y controla el tipo de disparo.
/// </summary>
using UnityEngine;
using System.Collections;

public class PJ_Disparo : MonoBehaviour {
	//Posicion desde la que se disparan las balas.
	public Transform posDisparo;
	//Prefab de municion.
	public GameObject bala;
	//Enumeracion de disparos posibles.
	public enum TiposDisparo {simple, bala1, bala2, bala3, laser};
	//Tipo de disparo actual.
	public TiposDisparo disparoActual = TiposDisparo.simple;
	//Ratio de disparo.
	public float ratioDisparo = .5f;
	//Almacen de tiempo para el siguiente disparo.
	private float proximoDisparo;
	
	void Update () {
		//Si el jugador pulsa disparo y ha pasado el tiempo suficiente para poder disparar...
		if (Input.GetButton("Fire1") && Time.time > proximoDisparo) {
			//...añado tiempo para proximoDisparo.
			proximoDisparo = Time.time + ratioDisparo;
			//...creo bala en funcion del tipo de disparo.
			switch (disparoActual){
			case TiposDisparo.simple:
				//Instancio el prefab del disparo.
				GameObject go = (GameObject)Instantiate(bala, posDisparo.position, Quaternion.identity);
				go.name = "Bala";
				return;
			case TiposDisparo.bala1:
				GameObject go1 = (GameObject)Instantiate(bala, posDisparo.position-new Vector3(-0.2f,0,0), Quaternion.identity);
				go1.name = "BalaDER";
				GameObject go2 = (GameObject)Instantiate(bala, posDisparo.position+new Vector3(-0.2f,0,0), Quaternion.identity);
				go2.name = "BalaIZQ";
				return;
			}
		}
	}
}
