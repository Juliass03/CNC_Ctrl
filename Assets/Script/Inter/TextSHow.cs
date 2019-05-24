using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSHow : MonoBehaviour {

    public Slider Angle;
    public Slider Radius;
    public Slider Speed;

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "<color=green>参数：</color>\n\t\t\t路径夹角： " + Angle.value * 100 + " 度\n\t\t\t刀具半径： " + Radius.value * 50 + "\n\t\t\t速度： "+ Speed.value;

    }
}
