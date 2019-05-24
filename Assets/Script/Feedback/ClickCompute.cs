using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickCompute : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public InfoPrint text;

    bool CanCompute;
    int T = 0;
    int Speed = 0;
    Vector2 start;
    Vector2 end;

    Vector2[] inter;

    private void Start()
    {
        CanCompute = false;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (CanCompute)
        {
            inter = Compute.Computes(T, Speed, start, end);
            string s = "\t\t采样插补点计算完毕： \n";
            int i = 0;
            int j = 0;
            
            foreach (var item in inter)
            {
                j++;
                if (i < 2)
                {
                    
                    s += "\t\t#"+ string.Format("{0:d3}", j) +": "+ item.ToString() + ",";
                }
                else if (i == 2)
                {
                    s += "\n";
                    s += "\t\t#" + string.Format("{0:d3}", j) + ": " + item.ToString() + ",";
                    i = 0;
                    continue;
                }
               
                i++;
            }
            text.AddText(s);

            CanCompute = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void CanComput(int circle,int sp,Vector2 s,Vector2 e)
    {
        T = circle;
        Speed = sp;
        start = s;
        end = e;
        CanCompute = true;
    }

   
}
