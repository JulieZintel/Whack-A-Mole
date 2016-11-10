using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour {

	public GameObject onHit;

	void OnMouseDown() {
		// Load On-Hit effect
		GameObject g = (GameObject)Instantiate(onHit, transform.position, Quaternion.identity);

		// Destroy it after a while
		Destroy(g, 0.2f);
	}
}
