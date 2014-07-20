/// <summary>
/// Escudo.
/// Este script desactiva el escudo al recibir una bala enemiga.
/// </summary>
using UnityEngine;
using System.Collections;

public class Escudo : MonoBehaviour {

	public bool activo = false;

	private SpriteRenderer miSprite;

	void Start(){
		miSprite = gameObject.GetComponent<SpriteRenderer> ();
	}

	void Update(){
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
