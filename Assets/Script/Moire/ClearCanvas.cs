using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClearCanvas : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    TextMeshProUGUI tx;
    bool click = false;
    float _timer = 0;
    private float nativeSIze;


    private void Start()
    {
        tx = GetComponent<TextMeshProUGUI>();
        nativeSIze = tx.fontSize;

    }



    private void Update()
    {

        if (click)
        {
            tx.fontSize = nativeSIze / 1.5f;

            _timer += 1;
            if (_timer > 10)
            {
                tx.fontSize = nativeSIze;
                _timer = 0;
                click = false;
                
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
