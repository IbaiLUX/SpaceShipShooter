/// <summary>
/// Escenario_ menu.
/// Este script se encarga del menu y de activar/desactivar elementos para iniciar partida.
/// *****NOTA*****
/// Esta diseñado para Web 900x600
/// </summary>
using UnityEngine;
using System.Collections;

public class Escenario_Menu : MonoBehaviour {
	//Estoy pausado.
	public bool pausado = false;
	//Referencia al Nivel.
	private Escenario_Nivel en;
	//Referencia a la salud del jugador.
	private PJ_Salud pjS;
	//Definiedo y creando Delegate para GUI.
	private delegate void Menus();
	private Menus menuActual;

	// Use this for initialization
	void Start () {
		//Recojo Escenario Nivel.
		en = GetComponent<Escenario_Nivel> ();
		//El 1º menu que se muestra es el principal
		this.menuActual = MenuPrincipal;
	}
	
	// Update is called once per frame
	void Update () {
		//Si pulso ESCAPE...
		if (Input.GetKeyUp (KeyCode.Escape)) {
			//...invierto el estado.
			pausado = !pausado;
		}
		//Si estoy pausado...
		if (pausado) {
			//...paro el tiempo.
			Time.timeScale = 0;
		//Si no estoy pausado...
		} else {
			//...reestablezco el tiempo.
			Time.timeScale = 1;
		}

	}

	public void OnGUI () {
		//Usando Delegate para UI.
		this.menuActual(); 
	}

	//MENU PRINCIPAL, Un boton para comenzar.
	private void MenuPrincipal() {
		//Si pulso el boton...
		if (GUI.Button (new Rect (300,75,300,100), "Comenzar")){
			//...cambio estado.
			this.menuActual = MenuJuego;
			//...inicio el Nivel.
			en.ComienzaNivel();
		}
		if (GUI.Button (new Rect (300,200,300,100), "Como jugar?")){
			this.menuActual = Tutorial;
		}
	}
	//MENU DEL TUTORIAL, Un boton para regresar a PRINCIPAL y una explicacion de controles.
	private void Tutorial(){
		//Si pulso el boton...
		if (GUI.Button (new Rect (300,75,300,100), "Atras")){
			//...cambio estado.
			this.menuActual = MenuPrincipal;
		}
		//Texto indicativo.
		string miTexto = "\n\nPara desplazarte usa teclas W-A-S-D o flechas de direccion.\n\nPara disparar usa Boton IZQ de raton o tecla CTRL IZQ";
		//Caja para el texto.
		GUI.Box (new Rect (150, 200, 600, 300), miTexto);
	}
	//MENU EN JUEGO, reinicio si se pausa, UI de juego.
	private void MenuJuego() { 
		//Si estoy en pausa.
		if (pausado) {
			//Si pulso el boton...
			if (GUI.Button (new Rect (300, 75, 300, 100), "Reiniciar")) {
				//...cambio estado.
				Application.LoadLevel (0);
			}
			if (GUI.Button (new Rect (300, 200, 300, 100), "Continuar")) {
				//...cambio estado.
				pausado = false;
			} 
		}
		//Si no estoy pausado...
		else {
			//Recojo PJ_Salud.
			pjS = GameObject.FindGameObjectWithTag("Player").GetComponent<PJ_Salud>();
			//Creo texto indicativo.
			GUI.Box(new Rect(25,10,200,25), "Vidas:"+pjS.vidasJugador.ToString());	
		}
	}
	//MENU FINAL PARTIDA, opcion de reinicio.
	private void GameOver(){
		//Si pulso el boton...
		if (GUI.Button (new Rect (300,75,300,100), "Reiniciar")){
			//...cambio estado.
			Application.LoadLevel(0);
		} 
	}

	public void CambiaGameOver(){
		this.menuActual = GameOver;
	}
}
