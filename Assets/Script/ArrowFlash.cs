using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArrowFlash : MonoBehaviour
{

    private float alpha = 0.2f;
    public float speed = 8f;
    private bool isShow = true;
    private TextMeshProUGUI tx;
    public bool isFlash = true;



    // Use this for initialization
    void Start()
    {
        tx = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
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
                            isShow = true;
                        }
                    }
                }
            }


        
    }
}
