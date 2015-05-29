using UnityEngine;
using System.Collections;

public class PlayerAttacker : MonoBehaviour {

	public GameObject EnemyCol;
	public GameObject PlayerGO;

	void OnTriggerEnter(Collider col)
	{	
		if (col.gameObject.tag == ("Enemy")) 
			EnemyCol = col.gameObject;

		if (EnemyCol != null) {
			if (EnemyCol.GetComponent<EnemyMovement> ().defense == false)if (EnemyCol.GetComponent<EnemyMovement> ().hurt == false){
				EnemyCol.GetComponent<EnemyMovement> ().health -= 70;
				StartCoroutine (EnemyCol.GetComponent<EnemyMovement> ().Hurt ());
				}
			//失敗
			if (EnemyCol.GetComponent<EnemyMovement> ().defense == true) {
				StartCoroutine (PlayerGO.GetComponent<PlayerMovement> ().Stun ());
				}
			}

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
