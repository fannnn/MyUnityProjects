using UnityEngine;
using System.Collections;

public class eatWhat : MonoBehaviour {

	public int r1;
	public string d1,d2,d3,d4,d5;
	public string f1,f2,f3,f4,f5,f6,f7,f8;

	// Use this for initialization
	void Start () {
		f1 = "四海游龍";
		f2 = "摩斯漢堡";
		f3 = "麥當勞";
		f4 = "義大利麵1";
		f5 = "義大利麵2";
		f6 = "克拉克自助餐";
		f7 = "小放牛牛肉麵";
		f8 = "八方雲集";
		}
	void OnGUI(){
		GUI.Box (new Rect (10, 10, 300, 30), "Monday" + " : " + d1);
		GUI.Box (new Rect (10, 50, 300, 30), "Tuesday" + " : " + d2);
		GUI.Box (new Rect (10, 100, 300, 30), "Wensday" + " : " + d3);
		GUI.Box (new Rect (10, 150, 300, 30), "Thursday" + " : " + d4);
		GUI.Box (new Rect (10, 200, 300, 30), "Friday" + " : " + d5);
		if (GUI.Button (new Rect (500, 50, 50, 50), "fuck"))
		{
		print ("fukcyou!!");
		print ("justkidding!");
		}
	}
	// Update is called once per frame
	void Update () {
		r1 = Random.Range (1, 9);

		if (Input.GetKeyDown (KeyCode.Space)) {
			d1 = "";d2 = "";d3 = "";d4 = "";d5 = "";
		}
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			if(r1==1)d1 = f1;if(r1==2)d1 = f2;
			if(r1==3)d1 = f3;if(r1==4)d1 = f4;
			if(r1==5)d1 = f5;if(r1==6)d1 = f6;
			if(r1==7)d1 = f7;if(r1==8)d1 = f8;
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			if(r1==1)d2 = f1;if(r1==2)d2 = f2;
			if(r1==3)d2 = f3;if(r1==4)d2 = f4;
			if(r1==5)d2 = f5;if(r1==6)d2 = f6;
			if(r1==7)d2 = f7;if(r1==8)d2 = f8;
		}
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			if(r1==1)d3 = f1;if(r1==2)d3 = f2;
			if(r1==3)d3 = f3;if(r1==4)d3 = f4;
			if(r1==5)d3 = f5;if(r1==6)d3 = f6;
			if(r1==7)d3 = f7;if(r1==8)d3 = f8;
		}
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			if(r1==1)d4 = f1;if(r1==2)d4 = f2;
			if(r1==3)d4 = f3;if(r1==4)d4 = f4;
			if(r1==5)d4 = f5;if(r1==6)d4 = f6;
			if(r1==7)d4 = f7;if(r1==8)d4 = f8;
		}
		if(Input.GetKeyDown(KeyCode.Alpha5))
		{
			if(r1==1)d5 = f1;if(r1==2)d5 = f2;
			if(r1==3)d5 = f3;if(r1==4)d5 = f4;
			if(r1==5)d5 = f5;if(r1==6)d5 = f6;
			if(r1==7)d5 = f7;if(r1==8)d5 = f8;
		}

	}
}
