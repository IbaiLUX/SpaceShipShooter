/// <summary>
/// P j_ escudos.
/// Este script se encarga de activar los escudos y de dispararlos, tambien rota el gameObject que contiene los escudos.
/// </summary>
using UnityEngine;
using System.Collections;

public class PJ_Escudos : MonoBehaviour {
	//Contenedor de los escudos.
	public Transform cEscudos;
	//Velocidad a la que rotan los escudos
	public int vRotacion = 200;
	//
	public Escudo[] misEscudos = new Escudo[3];
	public enum EscudosActivos {Ninguno,Primero,Segundo,Tercero,Primero_Segundo, Primero_Tercero, Segundo_Tercero,Todos};
	public EscudosActivos escudoActual = EscudosActivos.Todos;


	// Update is called once per frame
	void Update () {
		//Roto el contenedor de escudos.
		cEscudos.rotation = Quaternion.Euler(0,0,Time.time*vRotacion);

		if (misEscudos [0].activo == false && misEscudos [1].activo == false && misEscudos [2].activo == false) {
			escudoActual = EscudosActivos.Ninguno;		
		}
		if (misEscudos [0].activo == true && misEscudos [1].activo == false && misEscudos [2].activo == false) {
			escudoActual = EscudosActivos.Primero;		
		}
		if (misEscudos [0].activo == false && misEscudos [1].activo == true && misEscudos [2].activo == false) {
			escudoActual = EscudosActivos.Segundo;		
		}
		if (misEscudos [0].activo == false && misEscudos [1].activo == false && misEscudos [2].activo == true) {
			escudoActual = EscudosActivos.Tercero;		
		}
		if (misEscudos [0].activo == true && misEscudos [1].activo == true && misEscudos [2].activo == false) {
			escudoActual = EscudosActivos.Primero_Segundo;		
		}
		if (misEscudos [0].activo == true && misEscudos [1].activo == false && misEscudos [2].activo == true) {
			escudoActual = EscudosActivos.Primero_Tercero;		
		}
		if (misEscudos [0].activo == false && misEscudos [1].activo == true && misEscudos [2].activo == true) {
			escudoActual = EscudosActivos.Segundo_Tercero;		
		}
	}

	public void ActivarEscudo(){
		switch (escudoActual) {
			case EscudosActivos.Ninguno:
				misEscudos[0].activo = true;
				return;
			case EscudosActivos.Primero:
				misEscudos[1].activo = true;
				return;
			case EscudosActivos.Segundo:
				misEscudos[0].activo = true;
				return;
			case EscudosActivos.Tercero:
				misEscudos[0].activo = true;
				return;
			case EscudosActivos.Primero_Segundo:
				misEscudos[2].activo = true;
				return;
			case EscudosActivos.Primero_Tercero:
				misEscudos[1].activo = true;
				return;
			case EscudosActivos.Segundo_Tercero:
				misEscudos[0].activo = true;
				return;
		}
	}
	public void DesActivarEscudo(){
		switch (escudoActual) {
		case EscudosActivos.Ninguno:
			//misEscudos[0].activo = true;
			return;
		case EscudosActivos.Primero:
			misEscudos[0].activo = false;
			return;
		case EscudosActivos.Segundo:
			misEscudos[1].activo = false;
			return;
		case EscudosActivos.Tercero:
			misEscudos[2].activo = false;
			return;
		case EscudosActivos.Primero_Segundo:
			misEscudos[1].activo = false;
			return;
		case EscudosActivos.Primero_Tercero:
			misEscudos[2].activo = false;
			return;
		case EscudosActivos.Segundo_Tercero:
			misEscudos[2].activo = false;
			return;
		}
	}
}
