using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	//玩家基本資料
	public int healt;

	//戰鬥位置相關
	public bool inBattle;
	public GameObject PlayerGO;
	public GameObject[] EnemyGO;
	public float CD;

	// Use this for initialization
	IEnumerator wait()
	{
		yield return new WaitForSeconds (5);
	}
	void Start () {
		PlayerGO = gameObject;
		EnemyGO = GameObject.FindGameObjectsWithTag("Enemy");
		healt = 100;

	}
	
	// Update is called once per frame
	void Update () {
		//判定是否進入戰鬥狀態
		inBattle = false;
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [0].transform.position) < 5)
			if(EnemyGO[0].GetComponent<EnemyMovement>().health > 0)
			inBattle = true;
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [1].transform.position) < 5)
			if(EnemyGO[1].GetComponent<EnemyMovement>().health > 0)
			inBattle = true;
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [2].transform.position) < 5)
			if(EnemyGO[2].GetComponent<EnemyMovement>().health > 0)
			inBattle = true;
		//判定無戰鬥狀態 繼續往前移動
		if(inBattle == false)
		StartCoroutine (wait ());
		print ("fucke");
		transform.position += new Vector3 (0.1f, 0, 0);




		//攻擊判定
		CD -= Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.F))
			if(CD < 0)
			{
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [0].transform.position) < 5) 
			EnemyGO[0].GetComponent<EnemyMovement>().health -= 2;
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [1].transform.position) < 5) 
			EnemyGO[1].GetComponent<EnemyMovement>().health -= 2;
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [2].transform.position) < 5) 
			EnemyGO[2].GetComponent<EnemyMovement>().health -= 2;
			CD = 1;
			}
		}

	
}
