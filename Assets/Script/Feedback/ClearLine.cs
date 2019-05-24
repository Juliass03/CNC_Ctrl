using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClearLine : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    TextMeshProUGUI tx;
    public ClickDraw cl;
    public InfoPrint InfoPrint;

    private void Start()
    {
        tx = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        cl.ClearLine();
        InfoPrint.ClearText();
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
