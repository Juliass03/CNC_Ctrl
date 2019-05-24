using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackToMenu : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    TextMeshProUGUI tx;
   



    private void Start()
    {
        tx = GetComponent<TextMeshProUGUI>();
        

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        tx.fontSize /= 1.5f;
        SceneLoadManager.LoadScene("Main", delegate (float progress)
        {
            //Debug.LogFormat("进度：{0}", progress);
        }, delegate ()
        {
            //Debug.Log("jiesu");
        });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tx.color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tx.color = Color.white;
    }

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
