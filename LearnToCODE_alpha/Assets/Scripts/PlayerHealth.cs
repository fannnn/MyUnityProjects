using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 100;
	public int curHealth = 100;
	public float healthBarLength ;

	// Use this for initialization
	void Start () {
	//代入變數=healthBarLength = 螢幕寬度的一半
		healthBarLength = Screen.width / 2;
					}
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth (0);
			}
	void OnGUI(){
		GUI.Box (new Rect (10,10,healthBarLength,20), curHealth + "/" + maxHealth);
							}
		public void AddjustCurrentHealth(int adj){
		//curHealth代入curHealth加上adj
		curHealth += adj;

		if (curHealth < 0)
			curHealth = 0;
		if (curHealth > maxHealth)
			curHealth = maxHealth;
		if (maxHealth < 1)
			maxHealth = 1;

		//healthBarLenght = 螢幕的一半 * curHealth / (float???)maxHealth 
		healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);

	}
}
