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
	//Audio activado.
	public bool audioSI = true;
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
		//Si hay audio...
		if (audioSI) {
			//...ajusto el volumen del Listener
			AudioListener.volume = 1;		
		} else {
			//...ajusto el volumen del Listener
			AudioListener.volume = 0;		
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
		//Si pulso el boton...
		if (GUI.Button (new Rect (300,200,300,100), "Como jugar?")){
			//...cambio estado.
			this.menuActual = Tutorial;
		}
		//Creo contenedor para el toggle del audio.
		GUI.Box (new Rect (775, 10, 100, 50),"Opcion Audio:");
		//Asigno valor a audioSi dependiendo del toggle.
		audioSI = GUI.Toggle (new Rect (800, 30, 50, 50), audioSI, "Audio SI/NO");

	}
	//MENU DEL TUTORIAL, Un boton para regresar a PRINCIPAL y una explicacion de controles.
	private void Tutorial(){
		//Si pulso el boton...
		if (GUI.Button (new Rect (300,75,300,100), "Atras")){
			//...cambio estado.
			this.menuActual = MenuPrincipal;
		}
		GUI.Box (new Rect (150, 200, 600, 300), "\n\nPara desplazarte usa teclas W-A-S-D o flechas de direccion.\n\nPara disparar usa Boton IZQ de raton o tecla CTRL IZQ");
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
			//Si pulso el boton...
			if (GUI.Button (new Rect (300, 200, 300, 100), "Continuar")) {
				//...cambio estado.
				pausado = false;
			}
			//Creo contenedor para el toggle del audio.
			GUI.Box (new Rect (775, 10, 100, 50),"Opcion Audio:");
			//Asigno valor a audioSi dependiendo del toggle.
			audioSI = GUI.Toggle (new Rect (800, 30, 50, 50), audioSI, "Audio SI/NO");
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
	//MENU JUEGO TERMINADO, reiniciar.
	private void JuegoCompletado(){
		//Si pulso el boton...
		if (GUI.Button (new Rect (300,75,300,100), "Reiniciar")){
			//...cambio estado.
			Application.LoadLevel(0);
		}
		GUI.Box (new Rect (150, 200, 600, 300), "\n\nFELICIDADES\n\nCOMPLETASTE EL JUEGO!");
	}
	//Cambia el estado del menu a Game Over.
	public void CambiaGameOver(){
		//Cambia estado.
		this.menuActual = GameOver;
	}
	//Cambia el estado del menu a Completado.
	public void CambiaCompletado(){
		//Cambia estado.
		this.menuActual = JuegoCompletado;
	}
}
