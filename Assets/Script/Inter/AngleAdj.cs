using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngleAdj : MonoBehaviour {

    public Image AnleLine;

    Slider slider;
	// Use this for initialization
	void Start () {

        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        
            // MoveLines[i].rectTransform.rotation = Quaternion.Euler(0, 0, Angle);
            AnleLine.rectTransform.rotation = Quaternion.Euler(0, 0, 100f * slider.value);
        
	}

   
}
