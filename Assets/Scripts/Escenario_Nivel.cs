/// <summary>
/// Nivel.
/// Este script se encarga de manejar el estado del juego dependiendo de como se encuentre el nivel actual.
/// Contiene una clase plantilla de nivel.
/// ***** NOTA *****
/// Las ID seran seguidas 1,2,3,4...
/// </summary>
using UnityEngine;
using System.Collections;

//Clase "plantilla para nivel"
[System.Serializable]
public class Nivel{
	//Identificador.
	public int ID;
	//Posibles estados del nivel.
	public enum EstadoNivel{Inactivo,Inicio,Enemigos,Jefe,Final,Terminado};
	//Estado de este nivel.
	public EstadoNivel miEstado = EstadoNivel.Inactivo;
	//Tiempos
	public float tInicio = 5.5f;//Para que empiezen a salir enemigos.
	public float tEnemigos = 30.3f;//Tiempo durante el que saldran enemigos.
	public float tIntervalo = 2.5f;//Tiempo de intervalo entre enemigos.
	//Esta completo el nivel.
	public bool completado = false;
	//Enemigos en el nivel.
	public GameObject[] enemigos;
	//Jefe en el nivel.
	public GameObject jefe;
	//Textura de fondo de este nivel.
	public Texture mifondo;
}

public class Escenario_Nivel : MonoBehaviour {
	//El jugador.
	public GameObject jugador;
	//Posicion de inicio del jugador.
	public Transform inicioPos;
	//Los nivels.
	public Nivel[] Niveles = new Nivel[2];
	//El nivel actual.
	public Nivel nivelActual;
	//Los spawnpoint.
	public Transform[] spawnPoint;
	//Donde aparece el Jefe.
	public Transform spawnPoinJefe;
	//Referencia al fondo del nivel.
	public GameObject fondoNivel;
	//Tiempo.
	private float tiempo;
	//Tiempo para proximo enemigo.
	private float tProxEnemigo;

	// Use this for initialization
	void Start () {
		//Ajusto nivel actual.
		nivelActual = Niveles [0];
		//Ajusto tiempo para el primer enemigo.
		tProxEnemigo = Time.time + nivelActual.tInicio;
	}
	
	// Update is called once per frame
	void Update () {
		switch (nivelActual.miEstado) {
			case Nivel.EstadoNivel.Inactivo:
				//ComienzaNivel();
			return;
			case Nivel.EstadoNivel.Inicio:
				//Si ha pasado el tiempo suficiente...
				if(Time.time  > nivelActual.tInicio + tiempo){
					//...cambio el estado.
					nivelActual.miEstado = Nivel.EstadoNivel.Enemigos;
					//...asigno tiempo.
					tiempo = Time.time + nivelActual.tEnemigos;
				}
			return;
			case Nivel.EstadoNivel.Enemigos:
				//Si ha pasado el tiempo suficiente...
				if(Time.time  > tiempo){
					//...cambio el estado.
					nivelActual.miEstado = Nivel.EstadoNivel.Jefe;
				}
				//...si no...
				else{
					//Si ha pasado tiempo suficiente...
					if(Time.time >= tProxEnemigo){
						//...guardo la posicion donde creo enemigo.
						Vector3 pos = spawnPoint[Random.Range(0,spawnPoint.Length)].position;
						//...creo enemigo.
						GameObject go = (GameObject)Instantiate(nivelActual.enemigos[Random.Range(0,nivelActual.enemigos.Length)], pos, Quaternion.identity);
						//...si fue creado en IZQ.
						if(pos == spawnPoint[0].position||pos == spawnPoint[3].position){
							//...cambio su rotacion.
							go.transform.Rotate(0,0,-90);
						}
						//...si fue creado en DER.
						if(pos == spawnPoint[1].position||pos == spawnPoint[4].position){
							//...cambio su rotacion.
							go.transform.Rotate(0,0,90);	
						}
						//...si fue creado en CEN.
						if(pos == spawnPoint[2].position||pos == spawnPoint[5].position){
							//...cambio su rotacion.
							go.transform.Rotate(0,0,180);
						}
						//...actualizo tiempo para proximo enemigo.
						tProxEnemigo = Time.time + nivelActual.tIntervalo;
					}
				}
			return;
			case Nivel.EstadoNivel.Jefe:
				//Creo jefe.
				GameObject jefe = (GameObject)Instantiate(nivelActual.jefe, spawnPoinJefe.position, Quaternion.Euler(0,0,180));
				//Renombro.
				jefe.name = "Jefe de Nivel";
				//Cambio estado.
				nivelActual.miEstado = Nivel.EstadoNivel.Final;
			return;
			case Nivel.EstadoNivel.Final:
				//Batalla Jefe.
			return;
			case Nivel.EstadoNivel.Terminado:
				//Si hay mas niveles...
				if(Niveles[nivelActual.ID] != null){
					//...carga el siguiente.
					nivelActual = Niveles[nivelActual.ID];
					//Muestro el fondo del nivel.
					fondoNivel.renderer.material.mainTexture = nivelActual.mifondo;
					//Asigno tiempo.
					tiempo = Time.time;
					//Cambio el estado del nivel.
					nivelActual.miEstado = Nivel.EstadoNivel.Inicio;
				}else{
					Debug.Log("No mas niveles");
				}
			return;
		}
	}

	//Empieza el nivel.
	public void ComienzaNivel(){
		//Cambio el estado del nivel.
		nivelActual.miEstado = Nivel.EstadoNivel.Inicio;
		//Muestro el fondo del nivel.
		fondoNivel.renderer.material.mainTexture = nivelActual.mifondo;
		//Asigno tiempo.
		tiempo = Time.time;
		//Creo jugador.
		GameObject go = (GameObject)Instantiate (jugador, inicioPos.position, Quaternion.identity);
		//Renombro.
		go.name = "Jugador";
	}

	public void JefeDerrotado(){
		nivelActual.miEstado = Nivel.EstadoNivel.Terminado;
	}

	public void ReiniciaNivel(){
		nivelActual.miEstado = Nivel.EstadoNivel.Inactivo;
		fondoNivel.renderer.material.mainTexture = null;
		gameObject.GetComponent<Escenario_Menu> ().CambiaGameOver ();
	}
}
