using UnityEngine;
using System.Collections;

public class Escenario_Limites : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}
