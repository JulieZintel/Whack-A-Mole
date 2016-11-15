﻿using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {
	// Mole Prefab
	public GameObject mole;
	public float aliveTime = 1;
	public int scoreValue = 10;

	// Spawn Interval
	public int intervalMin = 4;
	public int intervalMax = 15;

	// Use this for initialization
	void Start () {
		Invoke("Spawn", Random.Range(intervalMin, intervalMax));
	}

	void Spawn() {
		// Spawn the mole
		GameObject g = (GameObject)Instantiate(mole, transform.position, Quaternion.identity);

		// Make sure to destroy it after a few seconds
		Destroy(g, aliveTime);
		ScoreManager.score += scoreValue;


		// Next Spawn
		Invoke("Spawn", Random.Range(intervalMin, intervalMax));
	}
}