using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {


    public GameObject Mergemachines;
    public GameObject btns;

    [Header("X Scroll")]
    public Transform XScrool;
    public Transform[] XMoveObj;
    public Transform Xlimit;


    [Header("Y Scroll")]
    public Transform YScrool;
    public Transform[] YMoveObj;
    public Transform Ylimit;

    [Header("Z Scroll")]
    public Transform ZScrool;
    public Transform[] ZMoveObj;
    public Transform Zlimit;

    Button[] clickBtn;
    Transform[] machines;

    public Button backtoM;
    ColorBlock origin;


    // Use this for initialization
    void Start () {
        backtoM.onClick.AddListener(delegate ()
        {
            SceneLoadManager.LoadScene("Main", delegate (float progress)
            {
                //Debug.LogFormat("进度：{0}", progress);
            }, delegate ()
            {
                //Debug.Log("jiesu");
            });
        });

        clickBtn = btns.GetComponentsInChildren<Button>();
        machines = Mergemachines.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < machines.Length-1; i++)
        {
            int j = i+1;
            clickBtn[i].GetComponentInChildren<Text>().text =  machines[i+1].name;

            clickBtn[i].onClick.AddListener(delegate ()
            {
                BtnClickHideOrShow(j);
            });
        }

        origin = clickBtn[0].colors;
    
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
                YScrool.transform.rotation = Quaternion.identity;
                XDirMotion(-1f);
            
           
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            
                YScrool.transform.rotation = Quaternion.identity;
                XDirMotion(1f);
            
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
                YDirMotion(1f);
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            
                YDirMotion(-1f);
            
        }
        if (Input.GetKey(KeyCode.W))
        {
            
                ZDirMotion(1f);

            
        }
        if (Input.GetKey(KeyCode.S))
        {
            
                ZDirMotion(-1f);

            
        }
    }
    

    void BtnClickHideOrShow(int index)
    {
        if (machines[index].gameObject.activeInHierarchy)
        {
            machines[index].gameObject.SetActive(false);
            clickBtn[index - 1].colors =  new ColorBlock() {normalColor = Color.gray };
        }
        else
        {
            machines[index].gameObject.SetActive(true);
            clickBtn[index - 1].colors = origin;
        }
    }

    void XDirMotion(float i)
    {
        
            XScrool.Rotate(new Vector3(0, 0, i), Time.deltaTime * 25f * 36f);
            foreach (Transform item in XMoveObj)
            {
                item.Translate(new Vector3(0, 0, i * Time.deltaTime * 0.5f));
            }
       

        
    }

    void YDirMotion(float i)
    {
       
        
            YScrool.Rotate(new Vector3(i, 0, 0), Time.deltaTime * 25f * 36f);
            foreach (Transform item in YMoveObj)
            {
                item.Translate(new Vector3(i * Time.deltaTime * 0.5f, 0, 0));
            }
        
        
    }

    void ZDirMotion(float i)
    {
        
            ZScrool.Rotate(new Vector3(0, i, 0), Time.deltaTime * 20f * 36f);
            foreach (Transform item in ZMoveObj)
            {
                item.Translate(new Vector3(0, i * Time.deltaTime / 3f, 0));
            }
        
           
    }
}
