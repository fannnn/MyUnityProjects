using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public bool FIRE;
	public Transform Motherfucker;
	public Transform MyShit;
	public int score;
	public float time = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (FIRE == true) 
		{
			transform.position += new Vector3(0,0,10);
		}
		if (transform.position.z > new Vector3 (0, 0, 200).z) 
		{
			FIRE = false;
			transform.position = new Vector3 (0, 0, -100);
		}


		//if(Motherfucker.position == MyShit.position)
		if (time > 0)
			time -= Time.deltaTime;
		else
		if ((Motherfucker.position.x - MyShit.position.x) <= new Vector3 (10, 0, 0).x)
		if ((Motherfucker.position.x - MyShit.position.x) >= new Vector3 (-10, 0, 0).x)
		if (Motherfucker.position.z - MyShit.position.z <= new Vector3 (0, 0, 10).z)
		if (Motherfucker.position.z - MyShit.position.z >= new Vector3 (0, 0, -10).z) 
			{
					score += 1;
					print ("BOOOOMMM!!!!");
					time=1;
			}		


	}
	void OnGUI(){
		if (GUI.Button (new Rect (10, 10, 100, 100), "SHOOT!"))
			FIRE = true;
		GUI.Box (new Rect (380, 10, 200, 30), "你成功了射中 :" + score + "次");
	}
}
