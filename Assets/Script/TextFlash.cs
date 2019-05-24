using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFlash : MonoBehaviour {

    private float alpha = 0.2f;
    public float speed = 8f;
    private bool isShow = true;
    int clickNum;
    private TextMeshProUGUI tx;
    public bool isFlash = true;

  

	// Use this for initialization
	void Start () {
        tx = GetComponent<TextMeshProUGUI>();
        clickNum = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if(clickNum > 3)
        {
            isFlash = false;
            tx.alpha = 1;
        }
        else
        {
            if (isFlash)
            {
                if (isShow)
                {
                    if (alpha != tx.alpha)
                    {
                        tx.alpha = Mathf.Lerp(tx.alpha, alpha, speed * Time.deltaTime);
                        if (Mathf.Abs(tx.alpha - alpha) < 0.01)
                        {
                            tx.alpha = alpha;
                            isShow = false;
                        }
                    }
                }
                else
                {
                    if (1 != tx.alpha)
                    {
                        tx.alpha = Mathf.Lerp(tx.alpha, 1, speed * Time.deltaTime);
                        if (Mathf.Abs(tx.alpha - 1) < 0.01)
                        {
                            tx.alpha = 1;
                            clickNum += 1;
                            isShow = true;
                        }
                    }
                }
            }
       
            
        }
	}
}
