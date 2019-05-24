using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundSetting : MonoBehaviour {

    //光栅宽度
    [HideInInspector]
    public float LineWidth;

    public Text text;
    //光栅间隔
    float SpaceWidth;

    float Angle;
    float Speed;

    //固定光栅
    [HideInInspector]
    public Image[] FixedLines = null;
    public Image[] MoveLines;
    //固定光栅数
    int fixedLineNum;

    int Movedirection;

    //固定光栅起始位置
    Vector2 fixedstartPos;
    public bool isStart;
    public bool isMove;
    double MoveLenght = 0;

    public Text MoveLentg;
    private void Start()
    {
        isStart = true;
        isMove = false;
    }

    private void FixedUpdate()
    {
        if (!isStart)
        {
            if (isMove)
            {
                if(Movedirection == 1)
                {

                    for (int i = 0; i < fixedLineNum; i++)
                    {
                        if (MoveLines[i].rectTransform.localPosition.x < (fixedstartPos.x + SpaceWidth+LineWidth))
                        {

                            MoveLines[i].rectTransform.Translate(new Vector3(Time.deltaTime * Speed, 0, 0), Space.World);
                        }

                        if(MoveLines[i].rectTransform.localPosition.x >= fixedstartPos.x + SpaceWidth + LineWidth)
                        {
                            //MoveLines[i].rectTransform.localPosition.x - fixedstartPos.x;

                            MoveLines[i].rectTransform.localPosition = new Vector3(-fixedstartPos.x, 0, 0);
                        }




                    }
                    MoveLenght += Time.deltaTime * Speed;
                }

                if(Movedirection == 0)
                {
                    for (int i = fixedLineNum-1; i >= 0; i--)
                    {
                        if (MoveLines[i].rectTransform.localPosition.x >= (-fixedstartPos.x - SpaceWidth - LineWidth))
                        {

                            MoveLines[i].rectTransform.Translate(new Vector3(-Time.deltaTime * Speed, 0, 0), Space.World);
                        }
                        else
                        {
                            MoveLines[i].rectTransform.localPosition = new Vector3(fixedstartPos.x, 0, 0);
                        }




                    }
                    MoveLenght -= Time.deltaTime * Speed;
                }

                MoveLentg.text = "<color=red>光栅位移： </color>" + MoveLenght.ToString();
            }
        }
    }


    public void StartInit(float width,float angle,float speed,int direction)
    {
        if(isStart)
        {
            LineWidth = width;
            SpaceWidth = LineWidth * Mathf.Sin(Mathf.Deg2Rad * angle);
            Movedirection = direction;
            Angle = angle;
            Speed = speed;

            InitFixedMoire();
            InitMoveMoire();
            isStart = false;
           
            text.text += "\n\t\t摩尔纹宽度：<color=red>" + width + "</color> um, 移动速度： <color=red>" + speed + "</color> mm/s, " + "倾斜角：<color=red>" + angle + "</color> °" + "\n\t\t移动方向: <color=red>" + direction + "</color> (0表示左，1表示右)！";
        }
        
    }

    public void MoireDissolve()
    {
        if(!isStart)
        {
            foreach (var item in FixedLines)
            {
                Destroy(item.gameObject);
            }

            foreach (var item in MoveLines)
            {
                Destroy(item.gameObject);
            }

            FixedLines = null;
            MoveLines = null;
            isStart = true;
            isMove = false;
            text.text = "<color=green>计算参数：</color>";
            MoveLenght = 0;
            MoveLentg.text = "<color=red>光栅位移： </color>" + MoveLenght.ToString();
        }
        
    }

     void InitFixedMoire () {
        fixedLineNum = (int)(Screen.width/(LineWidth+SpaceWidth))+ 1;
        fixedstartPos = new Vector2((fixedLineNum-1) * (LineWidth + SpaceWidth) / 2, 0);

        //初始化固定光栅
        FixedLines = new Image[fixedLineNum];
        for (int i = 0; i < fixedLineNum; i++)
        {
            FixedLines[i] = new GameObject("fixed line" + i.ToString()).AddComponent<Image>();
            FixedLines[i].transform.parent = transform;
            FixedLines[i].rectTransform.localPosition = new Vector3(-fixedstartPos.x + i * (LineWidth + SpaceWidth), 0, 0);



            FixedLines[i].rectTransform.pivot = new Vector2(0.5f, 0.5f);
            FixedLines[i].rectTransform.anchorMin = new Vector2(0.5f, 0);
            FixedLines[i].rectTransform.anchorMax = new Vector2(0.5f, 1f);
            FixedLines[i].rectTransform.sizeDelta = new Vector2(LineWidth, 0);

            FixedLines[i].color = new Color(58f / 255f, 58f / 255f, 58f / 255f);

        }
	}

     void InitMoveMoire()
    {
        

        //初始化固定光栅
        MoveLines = new Image[fixedLineNum];
        for (int i = 0; i < fixedLineNum; i++)
        {
            MoveLines[i] = new GameObject("moved line" + i.ToString()).AddComponent<Image>();
            MoveLines[i].transform.parent = transform;
            MoveLines[i].rectTransform.localPosition = new Vector3(-fixedstartPos.x + i * (LineWidth + SpaceWidth), 0, 0);
            MoveLines[i].rectTransform.rotation = Quaternion.Euler(0, 0, Angle);



            MoveLines[i].rectTransform.pivot = new Vector2(0.5f, 0.5f);
            MoveLines[i].rectTransform.anchorMin = new Vector2(0.5f, 0);
            MoveLines[i].rectTransform.anchorMax = new Vector2(0.5f, 1f);
            MoveLines[i].rectTransform.sizeDelta = new Vector2(LineWidth, 0);

            MoveLines[i].color = new Color(58f / 255f, 58f / 255f, 58f / 255f);

        }
    }
	
	void ChangeWidth(float width)
    {
        for (int i = 0; i < fixedLineNum; i++)
        {
           FixedLines[i].rectTransform.sizeDelta = new Vector2(width, 0);
        }
    }

    public void MoveMoire()
    {
        isMove = true;
    }
    public void StopMoire()
    {
        isMove = false;
    }
}
