using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
   

    public GameObject MoreCtrl;

    TextMeshProUGUI tx;
    bool click = false;
    float _timer = 0;
    private float nativeSIze;
    bool isEnd;


    private void Start()
    {
        tx = GetComponent<TextMeshProUGUI>();
        nativeSIze = tx.fontSize;
        isEnd = true;

    }



    private void Update()
    {
        if (MoreCtrl.GetComponent<BackGroundSetting>().isStart)
        {
            tx.text = "Start!";
            MoreCtrl.GetComponent<BackGroundSetting>().StopMoire();
        }

        if (click)
        {
            tx.fontSize = nativeSIze / 1.5f;

            _timer += 1;
            if (_timer > 5)
            {


                tx.fontSize = nativeSIze;
                _timer = 0;
                click = false;


                if (isEnd && !MoreCtrl.GetComponent<BackGroundSetting>().isStart)
                {
                    tx.text = "Stop!";
                    isEnd = false;
                    MoreCtrl.GetComponent<BackGroundSetting>().MoveMoire();
                }
                else
                {
                    MoreCtrl.GetComponent<BackGroundSetting>().StopMoire();
                    tx.text = "Start!";
                    isEnd = true;
                }


            }
        }

    }

   

    public void OnPointerClick(PointerEventData eventData)
    {
        click = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tx.color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tx.color = Color.white;
    }

    
}
