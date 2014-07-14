/// <summary>
/// PJ_Disparo.
/// Este script se encarga de la accion de disparar y controla el tipo de disparo.
/// TIPOS DE DISPARO:
/// -Simple: una sola bala.
/// -Dos: dos balas paralelas.
/// -Tres: tres balas, una central y dos laterales. TEMPORAL
/// -Cuatro: cuatro balas,delante, detras, izquierda y derecha. TEMPORAL
/// -Laser: un disparo que cruza todo el escenario. TEMPORAL
/// </summary>
using UnityEngine;
using System.Collections;

public class PJ_Disparo : MonoBehaviour {
	//Posicion desde la que se disparan las balas.
	public Transform posDisparo;
	//Prefab de municion.
	public GameObject bala;
	//Prefab del laser.
	public GameObject laser;
	//Enumeracion de disparos posibles.
	public enum TiposDisparo {simple, dos, tres, cuatro, laser};
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
					GameObject simple = (GameObject)Instantiate(bala, posDisparo.position, Quaternion.identity);
					simple.name = "Bala";
				return;
				case TiposDisparo.dos:
					//Instancio el prefab del disparo.
					GameObject dos1 = (GameObject)Instantiate(bala, posDisparo.position-new Vector3(-0.2f,0,0), Quaternion.identity);
					//Renombro.
					dos1.name = "BalaDER";
					//Instancio el prefab del disparo.
					GameObject dos2 = (GameObject)Instantiate(bala, posDisparo.position+new Vector3(-0.2f,0,0), Quaternion.identity);
					//Renombro.
					dos2.name = "BalaIZQ";
				return;
				case TiposDisparo.tres:
					//Instancio el prefab del disparo.
					GameObject tres1 = (GameObject)Instantiate(bala, posDisparo.position-new Vector3(-0.2f,0,0), Quaternion.Euler(0,0,45));
					//Renombro.	
					tres1.name = "BalaDER";
					//Nueva direccion de esta bala.
					tres1.GetComponent<Arma_Bala>().direccion = new Vector2(-.5f,1);
					
					//Instancio el prefab del disparo.
					GameObject tres2 = (GameObject)Instantiate(bala, posDisparo.position, Quaternion.identity);
					//Renombro.	
					tres2.name = "BalaCEN";
					
					//Instancio el prefab del disparo.
					GameObject tres3 = (GameObject)Instantiate(bala, posDisparo.position+new Vector3(-0.2f,0,0), Quaternion.Euler(0,0,-45));
					//Renombro.	
					tres3.name = "BalaIZQ";
					//Nueva direccion de esta bala.
					tres3.GetComponent<Arma_Bala>().direccion = new Vector2(.5f,1);
				return;
				case TiposDisparo.cuatro:
					//Instancio el prefab del disparo.
					GameObject cuatro1 = (GameObject)Instantiate(bala, posDisparo.position, Quaternion.identity);
					//Renombro.
					cuatro1.name = "BalaN";

					//Instancio el prefab del disparo.
					GameObject cuatro2 = (GameObject)Instantiate(bala, posDisparo.position, Quaternion.Euler(0,0,180));
					//Renombro.
					cuatro2.name = "BalaS";
					//Nueva direccion de esta bala.
					cuatro2.GetComponent<Arma_Bala>().direccion = new Vector2(0,-1);
					
					//Instancio el prefab del disparo.
					GameObject cuatro3 = (GameObject)Instantiate(bala, posDisparo.position, Quaternion.Euler(0,0,90));
					//Renombro.
					cuatro3.name = "BalaE";
					//Nueva direccion de esta bala.
					cuatro3.GetComponent<Arma_Bala>().direccion = new Vector2(1,0);
					
					//Instancio el prefab del disparo.
					GameObject cuatro4 = (GameObject)Instantiate(bala, posDisparo.position,  Quaternion.Euler(0,0,-90));
					//Renombro.
					cuatro4.name = "BalaO";
					//Nueva direccion de esta bala.
					cuatro4.GetComponent<Arma_Bala>().direccion = new Vector2(-1,0);
				return;
				case TiposDisparo.laser:
					//Instancio el prefab del disparo.
					GameObject go = (GameObject)Instantiate(laser, posDisparo.position,  Quaternion.identity);
					//Renombro.
					go.name = "Laser";
				return;
			}
		}
	}
}
