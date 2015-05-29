using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	public GameObject EnemyCol;

	public AudioClip[] audioClip;


	//初始化設置
	void Start () {
		PlayerGO = GameObject.FindGameObjectWithTag("Player");
		EnemyGO = GameObject.FindGameObjectsWithTag("Enemy");
		health = 100;
	}
	void OnCollisionStay (Collision col)
	{
		if (col.gameObject.tag == ("Enemy")) {
			EnemyCol = col.gameObject;
			print (EnemyCol);
		}


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
		if (EnemyCol != null) {
			if (Vector3.Distance (PlayerGO.transform.position, EnemyCol.transform.position) < 4)
			if (EnemyCol.GetComponent<EnemyMovement> ().dead == false)
				inBattle = true;
			if (EnemyCol.GetComponent<EnemyMovement> ().dead == true) {
				inBattle = false;
				EnemyCol.GetComponent<BoxCollider>().enabled = !enabled;
			}
		}
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
			{	AttackEnemy();
				GameObject.Find ("attacker").transform.localPosition = new Vector3 (0, 0, 0);

				PlaySound(0);
			}
			yield return new WaitForSeconds (0.1f);
			GameObject.Find ("attacker").transform.localPosition = new Vector3 (-5, 0, 0);
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
			PlaySound(1);
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
		
	void PlaySound(int clip){
		GetComponent<AudioSource> ().clip = audioClip [clip];
		GetComponent<AudioSource>().Play();
	}


	//攻擊那些王八羔子
	void AttackEnemy(){
//		if (Vector3.Distance (PlayerGO.transform.position, EnemyCol.transform.position) < 5) {//擊中，執行傷害與演出
//			if (EnemyCol.GetComponent<EnemyMovement> ().defense == false) {
//				EnemyCol.GetComponent<EnemyMovement> ().health -= 10;
//				StartCoroutine (EnemyCol.GetComponent<EnemyMovement> ().Hurt ());
//			}
//			//失敗
//			if (EnemyCol.GetComponent<EnemyMovement> ().defense == true) {
//				StartCoroutine (Stun ());
//			}
//		}




	}



































}
