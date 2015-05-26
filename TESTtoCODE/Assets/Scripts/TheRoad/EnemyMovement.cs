using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	//玩家基本資料
	public int health;
	
	//戰鬥相關
	public GameObject PlayerGO;
	public GameObject EnemyGO;
	public GameObject Model;
	public float attackCD;
	public float defenseCD;
	public bool inBattle;
	public bool attack;
	public bool hurt;
	public bool defense;
	public bool dead;
	
	
	private float timer;
	
	
	//初始化設置
	void Start () {
		PlayerGO = GameObject.FindGameObjectWithTag("Player");
		EnemyGO = gameObject;
		health = 100;
	}
	
	//執行
	void Update () {
		//基本資料狀態
		if(health <= 0){
			health = 0;
			Dead();}
		
		
		//判定是否進入戰鬥狀態
		inBattle = false;
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO.transform.position) < 5)
			if(PlayerGO.GetComponent<PlayerMovement>().dead == false)
				inBattle = true;
		
		
		//判定無戰鬥狀態 繼續往前移動
		if (inBattle == false) 
		if(dead == false){
			transform.position += new Vector3 (-0.1f, 0, 0);
		}
		
		//攻擊防禦CD設置
		attackCD -= Time.deltaTime;
		defenseCD -= Time.deltaTime;
		//攻擊判定
		if(inBattle ==true)
			if(dead == false)
				if(attackCD < 0){
					Attack();
					Invoke("Attack0",0.3f);
				
				
				
				attackCD = 1;
			}
		
		
		
		//防禦判定
//		if (Input.GetKey (KeyCode.J)) 
//			if (dead == false)
//			if (defenseCD < 0) {
//				StartCoroutine(Defense());
//				defenseCD = 1;
//			}
		
		
	}
	
	//暫時用血量ＵＩ
//	void OnGUI(){
//		GUI.Box (new Rect (10, 10, 200, 20),"HP:"+health);
//	}
	
	
	
	public void Attack (){
		attack = true;
		Model.GetComponent<Animator> ().Play ("attack");
		attack = false;
	}
	public void Hurt(){
		hurt = true;
		Model.GetComponent<Animator> ().Play ("hurt");
		hurt = false;
	}
	public IEnumerator Defense(){
		defense = true;
		Model.GetComponent<Animator> ().Play ("defense");
		yield return new WaitForSeconds(0.5f);
		defense = false;
	}
	public void Dead(){
		dead = true;
		Model.GetComponent<Animator> ().Play ("dead");
	}//處理死亡

	
	
	
	
	//攻擊那些王八羔子(0)
	void Attack0(){
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO.transform.position) < 5)
		{
			//擊中，執行傷害與演出
			if(PlayerGO.GetComponent<PlayerMovement>().defense == false)
			{PlayerGO.GetComponent<PlayerMovement> ().health -= 10;
				PlayerGO.GetComponent<PlayerMovement> ().Hurt();}
			//失敗
			if(PlayerGO.GetComponent<PlayerMovement>().defense == true)
			{Model.GetComponent<Animator> ().Play ("hurt");
				print ("defend success");
			}
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
