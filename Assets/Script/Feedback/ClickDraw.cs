using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickDraw : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Canvas canvas;
    public GLTest gL;
    public InfoPrint InfoPrint;
    public ClickCompute clickCompute;
    public TMP_InputField Cilrle;
    public TMP_InputField Speed;

    Image background;


    bool lineAlive;
    int pointNum;




    private void Start()
    {
        background = GetComponent<Image>();
        lineAlive = false;
        pointNum = 0;
    }




    Vector2[] pos = new Vector2[2];
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!lineAlive)
        {

            if(pointNum == 0)
            {

                Vector2 Mousepos = new Vector2();
                Mousepos = Input.mousePosition;
                pos[0] = Mousepos;
                gL.StartDraw();
                InfoPrint.AddText("选择了一点：" + Mousepos.ToString()+",  请再选择一点！");

            }
            else if (pointNum == 1)
            {
                Vector2 Mousepos = new Vector2();
                Mousepos = Input.mousePosition;
                pos[1] = Mousepos;
                lineAlive = true;
                gL.EndDraw();
                InfoPrint.AddText("第二点：" + Mousepos.ToString() + ",  线绘制完毕！");
                clickCompute.CanComput(int.Parse(Cilrle.text),int.Parse(Speed.text), pos[0], pos[1]);
            }
            pointNum++;
        }
        


    }

  

   

    



    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = Color.grey;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = Color.white;
        if(pointNum == 1)
        {
            ClearLine();
            InfoPrint.ClearText();
        }
        if (lineAlive)
        {
            background.color = Color.grey;
        }

    }

    
    public void ClearLine()
    {
        gL.ClearLine();
        pointNum = 0;
        lineAlive = false;
        background.color = Color.white;
    }
}
