using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	GameObject playerGO;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		playerGO = GameObject.FindGameObjectWithTag ("Player");
		var tmp = transform.position;
		tmp.x = playerGO.transform.position.x;
		transform.position = tmp;

	}
}
