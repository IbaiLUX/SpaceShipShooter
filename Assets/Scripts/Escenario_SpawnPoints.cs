using UnityEngine;
using System.Collections;

public class Escenario_SpawnPoints : MonoBehaviour {

	public GameObject[] enemigos;

	public int cantidad;

	public float tOleadas;

	public float tEspera;

	void Start(){
		StartCoroutine (CrearOleada ());
	}
	IEnumerator CrearOleada(){;
		while (true){
			for (int x = 0; x < cantidad; x++){
				Instantiate(enemigos[Random.Range(0,enemigos.Length)], transform.position+new Vector3(Random.Range(-6,6),0,0), Quaternion.Euler(0,0,180));
				yield return new WaitForSeconds (tOleadas);
			}
			yield return new WaitForSeconds (tEspera);
		}
	}
}
