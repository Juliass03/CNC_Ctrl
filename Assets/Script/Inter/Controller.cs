using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public GameObject BaseLine;
    public GameObject AngleLine;
    public Slider Radius;
    public Slider Angle;
    public Slider Speed;
    public Image OutCircle;
    public Image innerCircle;
    public Button startBtn;
    public Text CirclePos;

    public RectTransform[] SueLines;
    public Image insertLine;
    float radius;
    float deltX;

    float Movespeed = 100f;

    bool isMove;
    int status = 0;
    int InnerStatus = 0;

    float[] lineLenght;
    Vector2[] Originposition;
	// Use this for initialization
	void Start () {
        Originposition = new Vector2[2];
        isMove = false;
        //OutCircle.rectTransform.SetParent(SueLines[0], false);
        insertLine.gameObject.SetActive(false);
        lineLenght = new float[3];
    }
	
	// Update is called once per frame
	void Update () {
        Movespeed = Speed.value * 50f;
        if (!isMove)
        {
            radius = Radius.value * 50;
            deltX = radius / Mathf.Tan(Angle.value * 50 * Mathf.Deg2Rad);
            OutCircle.rectTransform.sizeDelta = new Vector2(radius * 2, radius * 2);
            innerCircle.rectTransform.sizeDelta = new Vector2(radius * 2, radius * 2);
            SueLines[0].localPosition = new Vector3(-deltX, -radius, 0);
            SueLines[0].sizeDelta = new Vector2(500f + deltX, 2f);
            SueLines[1].localPosition = new Vector3(deltX, radius, 0);
            SueLines[1].sizeDelta = new Vector2(500f - deltX, 2f);
            SueLines[2].localPosition = new Vector3(-deltX, radius, 0);
            SueLines[2].sizeDelta = new Vector2(300f + deltX, 2f);
            SueLines[3].localPosition = new Vector3(deltX, -radius, 0);
            SueLines[3].sizeDelta = new Vector2(300f - deltX, 2f);

            #region Vect points
            lineLenght[0] = 500f + deltX;
            lineLenght[1] = 300f + deltX;
            //尖顶

            #endregion


            if (deltX > 1.2 * radius)
            {
                insertLine.gameObject.SetActive(true);
                insertLine.rectTransform.localPosition = new Vector3(-1.2f * radius, SueLines[0].localPosition.y, 0);
                insertLine.rectTransform.sizeDelta = new Vector2(2f, (deltX - 1.2f * radius) * Mathf.Tan(Angle.value * 100f * Mathf.Deg2Rad));
                lineLenght[2] = (deltX - 1.2f * radius) * Mathf.Tan(Angle.value * 100f * Mathf.Deg2Rad);

            }
            else if (insertLine.gameObject.activeInHierarchy)
            {
                insertLine.gameObject.SetActive(false);
            }
        }
        

        if (isMove)
        {
            

            //3线情况
            if (insertLine.gameObject.activeInHierarchy)
            {
                if (status == 1)
                {
                    OutCircle.rectTransform.anchoredPosition += new Vector2(-1 * Time.deltaTime * Movespeed, 0);
                    if (OutCircle.rectTransform.anchoredPosition.x <= (-lineLenght[0]/2f + deltX -1.2F*radius))
                    {
                        status = 3;
                        OutCircle.rectTransform.SetParent(insertLine.rectTransform, false);
                        OutCircle.rectTransform.anchoredPosition = new Vector2(0,-lineLenght[2] / 2f);
                    }
                    
                }
                else if (status == 2)
                {
                    OutCircle.rectTransform.anchoredPosition += new Vector2(Time.deltaTime * Movespeed, 0);
                    if (OutCircle.rectTransform.anchoredPosition.x >= lineLenght[1] / 2f)
                    {
                        OutCircle.rectTransform.anchoredPosition = new Vector2(lineLenght[1] / 2f, 0);
                        status = 0;
                    }
                }
                else if (status == 3)
                {
                    OutCircle.rectTransform.anchoredPosition += new Vector2(0,Time.deltaTime * Movespeed);
                    if (OutCircle.rectTransform.anchoredPosition.y >= lineLenght[2] / 2f)
                    {
                        OutCircle.rectTransform.SetParent(SueLines[2], true);
                        
                        status = 2;
                    }
                }
            }
            else//2线情况
            {
                if(status == 1)
                {
                    OutCircle.rectTransform.anchoredPosition += new Vector2( -Time.deltaTime * Movespeed, 0);
                    if (OutCircle.rectTransform.anchoredPosition.x <= (-lineLenght[0] / 2f))
                    {
                        status = 2;
                        OutCircle.rectTransform.SetParent(SueLines[2], false);
                        //innerCircle.rectTransform.SetParent(SueLines[3], false);
                        OutCircle.rectTransform.anchoredPosition = new Vector2(-lineLenght[1] / 2f, 0);
                    }
                }
                else if(status ==2)
                {
                    OutCircle.rectTransform.anchoredPosition += new Vector2(Movespeed * Time.deltaTime, 0);
                    if (OutCircle.rectTransform.anchoredPosition.x >= lineLenght[1] / 2f)
                    {
                        OutCircle.rectTransform.anchoredPosition = new Vector2(lineLenght[1] / 2f, 0);
                        status = 0;
                    }
                }
            }


            if (InnerStatus == 1)
            {
                innerCircle.rectTransform.anchoredPosition -= new Vector2(Time.deltaTime * Movespeed, 0);
                if (innerCircle.rectTransform.anchoredPosition.x <= (-(lineLenght[0] - deltX * 2) / 2f))
                {
                    InnerStatus = 2;
                    innerCircle.rectTransform.SetParent(SueLines[3], true);
                    //innerCircle.rectTransform.SetParent(SueLines[3], false);
                    //OutCircle.rectTransform.anchoredPosition = new Vector2(-lineLenght[1] / 2f, 0);
                }
            }
            else if (InnerStatus == 2)
            {
                innerCircle.rectTransform.anchoredPosition += new Vector2(Time.deltaTime * Movespeed, 0);
                if (innerCircle.rectTransform.anchoredPosition.x >= (lineLenght[1] - 2 * deltX) / 2f)
                {
                    innerCircle.rectTransform.anchoredPosition = new Vector2((lineLenght[1] - 2 * deltX) / 2f, 0);
                    InnerStatus = 0;
                }
            }

            CirclePos.text = "左刀补坐标： " + OutCircle.rectTransform.position+ "\n又刀补坐标： " + innerCircle.rectTransform.position;
        }

        
    }


    public void StartMove()
    {
        Angle.gameObject.SetActive(false);
        Radius.gameObject.SetActive(false);
        startBtn.gameObject.SetActive(false);
        Speed.gameObject.SetActive(false);
        isMove = true;

        OutCircle.rectTransform.SetParent(SueLines[0]);
        innerCircle.rectTransform.SetParent(SueLines[1]);

        OutCircle.rectTransform.anchoredPosition = new Vector2(lineLenght[0] / 2f, 0);

        innerCircle.rectTransform.anchoredPosition = new Vector3((lineLenght[0] - 2f*deltX)/2f , 0, 0);

        status = 1;
        InnerStatus = 1;
        Originposition[0] = OutCircle.rectTransform.position;
        Originposition[1] = innerCircle.rectTransform.position;
    }

    public void seReset()
    {
        Angle.gameObject.SetActive(true);
        Radius.gameObject.SetActive(true);
        startBtn.gameObject.SetActive(true);
        Speed.gameObject.SetActive(true);
        isMove = false;
        status = 0;
        InnerStatus = 0;
    }

}
