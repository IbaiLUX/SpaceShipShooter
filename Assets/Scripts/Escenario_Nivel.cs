/// <summary>
/// Nivel.
/// Este script se encarga de manejar el estado del juego dependiendo de como se encuentre el nivel actual.
/// Contiene una clase plantilla de nivel.
/// </summary>
using UnityEngine;
using System.Collections;

//Clase "plantilla para nivel"
[System.Serializable]
public class Nivel{
	//Identificador.
	public string nombre;
	//Posibles estados del nivel.
	public enum EstadoNivel{Inactivo,Inicio,Enemigos,Jefe,Final};
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
	//Los nivels.
	public Nivel[] Niveles = new Nivel[2];
	//El nivel actual.
	public Nivel nivelActual;
	//Los spawnpoint.
	public Transform[] spawnPoint;
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
				ComienzaNivel();
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
				Debug.Log("Spawn Jefe");
			return;
			case Nivel.EstadoNivel.Final:
				Debug.Log("Final de Nivel");
			return;
		}
	}

	//Empieza el nivel.
	private void ComienzaNivel(){
		//Cambio el estado del nivel.
		nivelActual.miEstado = Nivel.EstadoNivel.Inicio;
		//Muestro el fondo del nivel.
		fondoNivel.renderer.material.mainTexture = nivelActual.mifondo;
		//Asigno tiempo.
		tiempo = Time.time;
	}
}
