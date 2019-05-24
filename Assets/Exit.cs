using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Exit : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    TextMeshProUGUI tx;
    private void Start()
    {
        tx = GetComponent<TextMeshProUGUI>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();

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
