using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Enter : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler {

    TextMeshProUGUI tx;
    float nativeSIze;
    bool click = false;
    public TMP_Dropdown DropDown;
  
    

    private void Start()
    {
        tx = GetComponent<TextMeshProUGUI>();
        nativeSIze = tx.fontSize;
      
    }

    float _timer = 0;
    private void Update()
    {
      
        if (click)
        {
            tx.fontSize = nativeSIze / 1.5f;

            _timer += 1;
            if(_timer > 10)
            {
                tx.fontSize = nativeSIze;
                _timer = 0;
                click = false;
                LoadtheScene(DropDown.value);
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

    private void LoadtheScene(int index)
    {
        SceneLoadManager.LoadScene(index.ToString(), delegate (float progress)
        {
            //Debug.LogFormat("进度：{0}", progress);
        }, delegate ()
        {
            //Debug.Log("jiesu");
        });
        
    }
}
