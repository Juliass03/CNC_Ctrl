using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPrint : MonoBehaviour {

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = "<color=#00FF00> ## </color><color=red>"+ System.DateTime.Now.ToString()+"</color>";
        text.text += "\n\t\t请在上方点击两次！";
    }
	
	public void AddText(string msg)
    {
        text.text += "\n<color=#00FF00> ## </color><color=red>" + System.DateTime.Now.ToString() + "</color>";
        text.text += "\n\t\t" + msg;
    }
    
    public void ClearText()
    {
        text.text = "<color=#00FF00> ## </color><color=red>" + System.DateTime.Now.ToString() + "</color>";
        text.text += "\n\t\t请在上方点击两次！";
    }
}
