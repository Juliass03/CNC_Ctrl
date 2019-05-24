using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartMore : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_InputField Width;
    public TMP_InputField Angle;
    public TMP_InputField Speed;
    public TMP_Dropdown Direction;

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

        if (click)
        {
            tx.fontSize = nativeSIze / 1.5f;

            _timer += 1;
            if (_timer > 5)
            {
                
                
                tx.fontSize = nativeSIze;
                _timer = 0;
                click = false;


                if (isEnd)
                {
                    tx.text = "Clear!";
                    isEnd = false;
                    MoreGenerate();
                }
                else
                {
                    if (MoreCtrl.GetComponent<BackGroundSetting>().isMove)
                    {
                        MoreCtrl.GetComponent<BackGroundSetting>().StopMoire();
                    }
                    MoireDissolve();
                    tx.text = "Generate!";
                    isEnd = true;
                }

                
            }
        }

    }

    private void MoireDissolve()
    {
        MoreCtrl.GetComponent<BackGroundSetting>().MoireDissolve();
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

    void MoreGenerate()
    {
        MoreCtrl.GetComponent<BackGroundSetting>().StartInit(int.Parse(Width.text), int.Parse(Angle.text), int.Parse(Speed.text), Direction.value);
        
    }
}
