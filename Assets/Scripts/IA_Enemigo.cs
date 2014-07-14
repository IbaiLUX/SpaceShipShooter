/// <summary>
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
	//La velocidad del enemigo.
	public float velocidad;
	//Prefab del disparo.
	public GameObject disparo;
	//Transform de donde sale el disparo.
	public Transform posDisparo;
	//Ratio de disparo.
	public float ratioDisparo = .5f;
	//Almacen de tiempo para el siguiente disparo.
	private float proximoDisparo = 0.1f;
	//Vector 2 de direccion del enemigo, por defecto negativo en eje Y.
	public Vector2 direccion = new Vector2(0,-1);
	
	void Update () {
		//Si puedo disparar...
		if (Time.time > proximoDisparo) {
			//...añado tiempo para proximoDisparo.
			proximoDisparo = Time.time + ratioDisparo;
			//...instancio el prefab del disparo.
			GameObject disparoEnemigo = (GameObject)Instantiate(disparo, posDisparo.position, Quaternion.identity);
			//...renombro.
			disparoEnemigo.name = "DisparoEnemigo";
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
				//...para moverse en forma de ola direccion en X varia de -1.5 a 1.5.
				direccion = new Vector2((Mathf.PingPong(Time.time*velocidad, 3) - 1.5f),-1);
				//...añado velocidad.
				rigidbody2D.velocity = direccion * velocidad;
			return;
		}
	}
}
