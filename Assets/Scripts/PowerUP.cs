/// <summary>
/// Power UP.
/// Este script se encarga de asignar un color dependiendo del tipo de powerUp que sea. El tipo de powerUp sera aleatorio.
/// El item se movera ligeramente.
/// **NOTA**
/// Los sprites deven estar ordenados de la siguiente forma, 0 = disparos, 1 = vida, 2 = escudo, 3 = ratio.
/// </summary>

using UnityEngine;
using System.Collections;

public class PowerUP : MonoBehaviour {
	//Tipos de powerUp
	public enum TiposPowerUP {Nulo,Disparo1,Disparo2,Disparo3,Disparo4,Laser,Vida,Escudo,Ratio};
	//El power up de este item.
	public TiposPowerUP miPowerUP = TiposPowerUP.Nulo;
	//Referencia al script de disparo del jugador.
	private PJ_Disparo pjD;
	//Referencia al script de escudos del jugador.
	private PJ_Escudos pjE;
	//Sprites posibles.
	public Sprite[] sprites;
	
	void Start () {
		//Recojo la referencia al script del disparo del jugador.
		pjD = GameObject.FindGameObjectWithTag ("Player").GetComponent<PJ_Disparo> ();
		//Recojo la referencia al script de escudos del jugador.
		pjE = GameObject.FindGameObjectWithTag ("Player").GetComponent<PJ_Escudos> ();
		//Le doy valor aleatorio al powerUp.
		miPowerUP = GetRandomEnum<TiposPowerUP> ();
		//Dependiendo del tipo de power up...
		switch (miPowerUP) {
			//si es Nulo...
			case TiposPowerUP.Nulo:
				//Lo hago transparante.
				gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
				//Como es nulo lo destruyo.
				Destroy(gameObject);
			return;

			case TiposPowerUP.Disparo1:
				//Coloreo el item.
				gameObject.GetComponent<SpriteRenderer>().color = new Color(1,0,0,1);
				//Le asigno sprite.
				gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
			return;

			case TiposPowerUP.Disparo2:
				//Coloreo el item.
				gameObject.GetComponent<SpriteRenderer>().color = new Color(0,1,0,1);
				//Le asigno sprite.
				gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
			return;

			case TiposPowerUP.Disparo3:
				//Coloreo el item.
				gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,1,1);
				//Le asigno sprite.
				gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
			return;

			case TiposPowerUP.Disparo4:
				//Coloreo el item.
				gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,0,1);
				//Le asigno sprite.
				gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
			return;

			case TiposPowerUP.Laser:
				//Coloreo el item.
				gameObject.GetComponent<SpriteRenderer>().color = new Color(1,0,1,1);
				//Le asigno sprite.
				gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
			return;

			case TiposPowerUP.Vida:
				//Coloreo el item.
				gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
				//Le asigno sprite.
				gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
			return;

			case TiposPowerUP.Escudo:
				//Coloreo el item.
				gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
				//Le asigno sprite.
				gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
			return;

			case TiposPowerUP.Ratio:
				//Coloreo el item.
				gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
				//Le asigno sprite.
				gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
			return;
		}
	}

	void Update(){
		//Muevo el item.
		rigidbody2D.velocity = new Vector2 (Random.Range (-1,1), Random.Range (-1,1));
	}

	void OnTriggerEnter2D(Collider2D other){
		//Si el objeto que dispara el trigger es el jugador...
		if (other.tag == "Player") {
			//Dependiendo del powerUp...
			switch(miPowerUP){
				//Si es disparo 1...
				case TiposPowerUP.Disparo1:
					//...cambio el disparo.
					pjD.disparoActual = PJ_Disparo.TiposDisparo.simple;
					//...destruyo item.
					Destroy(gameObject);
				return;

				//Si es disparo 2...
				case TiposPowerUP.Disparo2:
					//...cambio el disparo.
					pjD.disparoActual = PJ_Disparo.TiposDisparo.dos;
					//...destruyo item.
					Destroy(gameObject);
				return;

				//Si es disparo 3...
				case TiposPowerUP.Disparo3:
					//...cambio el disparo.
					pjD.disparoActual = PJ_Disparo.TiposDisparo.tres;
					//...destruyo item.
					Destroy(gameObject);
				return;

				//Si es disparo 4...
				case TiposPowerUP.Disparo4:
					//...cambio el disparo.
					pjD.disparoActual = PJ_Disparo.TiposDisparo.cuatro;
					//...destruyo item.
					Destroy(gameObject);
				return;

				//Si es laser...
				case TiposPowerUP.Laser:
					//...cambio el disparo.
					pjD.disparoActual = PJ_Disparo.TiposDisparo.laser;
					//...destruyo item.
					Destroy(gameObject);
				return;
				//Si es escudo...
				case TiposPowerUP.Escudo:
					//...activo escudo.
					pjE.ActivarEscudo();
					//...destruyo item.
					Destroy(gameObject);
				return;
			}
		}
	}

	//Funcion que devuelve un elemento aleatorio de una enumeracion.
	static T GetRandomEnum<T>(){
		System.Array A = System.Enum.GetValues(typeof(T));
		T V = (T)A.GetValue(UnityEngine.Random.Range(0,A.Length));
		return V;
	}
}
