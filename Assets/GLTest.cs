using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GLTest : MonoBehaviour
{
    public Text text;
    public Material mat;
    // Draws a line from "startVertex" var to the curent mouse position.
    Vector3 startVertex;
    Vector2 startCircle;
    Vector3 mousePos;
    Vector3 endPos;
    string Circlepoint = null;
    bool startD;
    bool endD;

    void Start()
    {
        endPos = Vector3.zero;
        mousePos = Vector3.zero;
        startVertex = Vector3.zero;
        startCircle = Vector2.zero;
        startD = false;
        endD = false;
    }

    void Update()
    {
        mousePos = Input.mousePosition;

    }

    void OnPostRender()
    {
        if (!mat)
        {
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }

        if (!startD)
            return;

        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();

        GL.Begin(GL.LINES);
        GL.Color(Color.red);

        GL.Vertex(startVertex);

        if (endD)
        {
            GL.Vertex(new Vector3(endPos.x / Screen.width, endPos.y / Screen.height, 0));
            DrawCircle(startCircle, endPos, 180);
            //DrawCircle(startCircle, endPos, 30);
        }
        else
        {
            GL.Vertex(new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0));

        }

        GL.End();

        GL.PopMatrix();
    }


    private void DrawCircle(Vector2 start, Vector2 end, float CenterAngle)
    {
        text.text = null;
        Vector2 center = (start + end) / 2;
        float r = Vector2.Distance(start, end) / 2;

        float ori_angle = (Mathf.Atan2(center.y - start.y, center.x - start.x)) / Mathf.Deg2Rad;
        Vector2 nextpoint = Vector2.zero;
        Vector2 lastpoint = start;
        for (float i = 0; i < CenterAngle - 1; i = i + 1)
        {
            float hudu = (ori_angle - i) * Mathf.PI / 180;
            Vector2 nextdir = new Vector2(-Mathf.Cos(hudu), -Mathf.Sin(hudu));
            nextpoint = center + r * nextdir;
            text.text += nextpoint.ToString() + "\n";

            GL.Vertex(new Vector3(lastpoint.x / Screen.width, lastpoint.y / Screen.height, 0));
            GL.Vertex(new Vector3(nextpoint.x / Screen.width, nextpoint.y / Screen.height, 0));


            lastpoint = nextpoint;
        }
        GL.Vertex(new Vector3(lastpoint.x / Screen.width, lastpoint.y / Screen.height, 0));
        GL.Vertex(new Vector3(end.x / Screen.width, end.y / Screen.height, 0));
    }

    public void StartDraw()
    {

        startCircle = mousePos;
        startVertex = new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0);
        startD = true;
        endD = false;
    }

    public void EndDraw()
    {

        endPos = Input.mousePosition;
        endD = true;
        Debug.Log("end click:" + endD.ToString());
    }

    public void ClearLine()
    {
        startD = false;
    }
}
