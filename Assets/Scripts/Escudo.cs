/// <summary>
/// Escudo.
/// Este script desactiva el escudo al recibir una bala enemiga.
/// </summary>
using UnityEngine;
using System.Collections;

public class Escudo : MonoBehaviour {
	//Esta activo.
	public bool activo = false;
	//Referencia al Sprite.
	private SpriteRenderer miSprite;

	void Start(){
		//Recojo render.
		miSprite = gameObject.GetComponent<SpriteRenderer> ();
	}

	void Update(){
		//Asigno valur dependiendo de si esta activo.
		miSprite.enabled = activo;
	}

	void OnTriggerEnter2D(Collider2D c){
		//...si es la bala enemiga...
		if (c.tag == "BalaEnemiga") {
			//...desactivo.
			activo = false;
		}
	}
}
