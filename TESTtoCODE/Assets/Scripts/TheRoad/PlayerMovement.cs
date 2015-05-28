using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	//玩家基本資料
	public int health;

	//戰鬥相關
	public GameObject PlayerGO;
	public GameObject[] EnemyGO;
	public GameObject Model;
	public float attackCD;
	public float defenseCD;
	public bool inBattle;
	public bool attack;
	public bool hurt;
	public bool defense;
	public bool dead;
	public bool stun;
	public bool stopMoving;


	private float timer;


	//初始化設置
	void Start () {
		PlayerGO = GameObject.FindGameObjectWithTag("Player");
		EnemyGO = GameObject.FindGameObjectsWithTag("Enemy");
		health = 100;
	}
	
	//執行
	void Update () {
		//基本資料狀態
		if (health <= 0) {
			health = 0;
			if (dead == false)
				Dead ();
		}

		//判定是否進入戰鬥狀態
		inBattle = false;
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [0].transform.position) < 4)
			if(EnemyGO[0].GetComponent<EnemyMovement>().dead == false)
			inBattle = true;
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [1].transform.position) < 4)
			if(EnemyGO[1].GetComponent<EnemyMovement>().dead == false)
				inBattle = true;
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [2].transform.position) < 4)
			if(EnemyGO[2].GetComponent<EnemyMovement>().dead == false)
				inBattle = true;
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [3].transform.position) < 4)
			if(EnemyGO[3].GetComponent<EnemyMovement>().dead == false)
				inBattle = true;
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [4].transform.position) < 4)
			if(EnemyGO[4].GetComponent<EnemyMovement>().dead == false)
				inBattle = true;
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [5].transform.position) < 4)
			if(EnemyGO[5].GetComponent<EnemyMovement>().dead == false)
				inBattle = true;
		//判定無戰鬥狀態 繼續往前移動
		if (inBattle == false) 
			if(stopMoving == false)
			if(dead == false){
			transform.position += new Vector3 (0.1f, 0, 0);
		}

		//攻擊防禦CD設置
		attackCD -= Time.deltaTime;
		defenseCD -= Time.deltaTime;
		//攻擊判定
		if (Input.GetKeyDown(KeyCode.F)) 
			if(defense == false)
			if(stun == false)
			if(dead == false)
			if(hurt == false)
				if(attackCD < 0){
					StartCoroutine(Attack());
					
			


				attackCD = 0.5f;
			}



		//防禦判定
		if (Input.GetKey (KeyCode.J)) 
			if (dead == false)
			if(stun == false)
			if (defenseCD < 0) {
				StartCoroutine(Defense());
					defenseCD = 1;
			}


	}

	//暫時用血量ＵＩ
	void OnGUI(){
		GUI.Box (new Rect (10, 10, 200, 20),"HP:"+health);
	}



	public IEnumerator Attack (){
		if (dead == false) {
			attack = true;
			Model.GetComponent<Animator> ().Play ("attack");
			yield return new WaitForSeconds (0.3f);
			if(defense == false)if(stun == false)if(hurt == false)if(dead == false)
				AttackEnemy();
			attack = false;
		}
	}
	public IEnumerator Hurt(){
		if (dead == false) {
			hurt = true;
			if (attack == false)
				Model.GetComponent<Animator> ().Play ("hurt");
			yield return new WaitForSeconds (0.5f);
			hurt = false;
		}
	}
	public IEnumerator Defense(){
		if (dead == false) {
			defense = true;
			Model.GetComponent<Animator> ().Play ("defense");
			yield return new WaitForSeconds (0.5f);
			defense = false;
		}
	}
	public void Dead(){
		dead = true;
		Model.GetComponent<Animator> ().Play ("dead");
	}//處理死亡
	public IEnumerator Stun(){
		if (dead == false) {
			stun = true;
			Model.GetComponent<Animator> ().Play ("hurt");
			yield return new WaitForSeconds (1);
			stun = false;
		}
	}
		



	//攻擊那些王八羔子
	void AttackEnemy(){
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [0].transform.position) < 5) {//擊中，執行傷害與演出
				if (EnemyGO [0].GetComponent<EnemyMovement> ().defense == false) {
					EnemyGO [0].GetComponent<EnemyMovement> ().health -= 10;
					StartCoroutine (EnemyGO [0].GetComponent<EnemyMovement> ().Hurt ());
				}
				//失敗
				if (EnemyGO [0].GetComponent<EnemyMovement> ().defense == true) {
					StartCoroutine (Stun ());
				}
			}
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [1].transform.position) < 5) {//擊中，執行傷害與演出
				if (EnemyGO [1].GetComponent<EnemyMovement> ().defense == false) {
					EnemyGO [1].GetComponent<EnemyMovement> ().health -= 10;
					StartCoroutine (EnemyGO [1].GetComponent<EnemyMovement> ().Hurt ());
				}
				//失敗
				if (EnemyGO [1].GetComponent<EnemyMovement> ().defense == true) {
					StartCoroutine (Stun ());
				}
			}
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [2].transform.position) < 5) {//擊中，執行傷害與演出
				if (EnemyGO [2].GetComponent<EnemyMovement> ().defense == false) {
					EnemyGO [2].GetComponent<EnemyMovement> ().health -= 10;
					StartCoroutine (EnemyGO [2].GetComponent<EnemyMovement> ().Hurt ());
				}
				//失敗
				if (EnemyGO [2].GetComponent<EnemyMovement> ().defense == true) {
					StartCoroutine (Stun ());
				}
			}
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [3].transform.position) < 5) {//擊中，執行傷害與演出
				if (EnemyGO [3].GetComponent<EnemyMovement> ().defense == false) {
					EnemyGO [3].GetComponent<EnemyMovement> ().health -= 10;
					StartCoroutine (EnemyGO [3].GetComponent<EnemyMovement> ().Hurt ());
				}
				//失敗
				if (EnemyGO [0].GetComponent<EnemyMovement> ().defense == true) {
					StartCoroutine (Stun ());
				}
			}
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [4].transform.position) < 5) {//擊中，執行傷害與演出
				if (EnemyGO [4].GetComponent<EnemyMovement> ().defense == false) {
					EnemyGO [4].GetComponent<EnemyMovement> ().health -= 10;
					StartCoroutine (EnemyGO [4].GetComponent<EnemyMovement> ().Hurt ());
				}
				//失敗
				if (EnemyGO [4].GetComponent<EnemyMovement> ().defense == true) {
					StartCoroutine (Stun ());
				}
			}
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO [5].transform.position) < 5) {//擊中，執行傷害與演出
				if (EnemyGO [5].GetComponent<EnemyMovement> ().defense == false) {
					EnemyGO [5].GetComponent<EnemyMovement> ().health -= 10;
					StartCoroutine (EnemyGO [5].GetComponent<EnemyMovement> ().Hurt ());
				}
				//失敗
				if (EnemyGO [5].GetComponent<EnemyMovement> ().defense == true) {
					StartCoroutine (Stun ());
				}
			}





	}



































}
