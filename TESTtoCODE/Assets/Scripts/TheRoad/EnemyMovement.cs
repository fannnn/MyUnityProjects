using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public bool inBattle;
	public GameObject PlayerGO;	
	public GameObject EnemyGO;
	public int health;
	
	// Use this for initialization
	void Start () {
		health = 10;
		PlayerGO = GameObject.FindGameObjectWithTag("Player");
		EnemyGO = gameObject;

	}
	
	// Update is called once per frame
	void Update () {
		inBattle = false;
		if (Vector3.Distance(PlayerGO.transform.position,EnemyGO.transform.position) < 5) 
			inBattle = true;
		if(inBattle == false)
			if(health > 0)
			EnemyGO.transform.position += new Vector3 (-0.1f, 0, 0);


		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO.transform.position) < 5) 
			PlayerGO.GetComponent<PlayerMovement> ().healt -= 1;





		if (health <= 0)
			inBattle = false;

	}
}
