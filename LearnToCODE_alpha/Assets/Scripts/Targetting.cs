using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour {
	public List<Transform>targets;
	// Use this for initialization
	void Start () {
		targets = new List<Transform>();
	}
	public void AddAllEnemies()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Enemy");
		//foreach(GameObject enemy in go)

	}


	// Update is called once per frame
	void Update () {
	
	}
}
