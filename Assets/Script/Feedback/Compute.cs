using UnityEngine;


public static class Compute
{

    public static Vector2[] Computes(int T,int Speed,Vector2 startPos,Vector2 EndPos)
    {
        Vector2[] InterPos;

        Vector2 innerVec = EndPos - startPos ;
       
        int arrayNum;
        //步长
        float pace = T* Speed / 10;
        Vector2 dirVec = pace * innerVec.normalized;

        if (pace >= innerVec.magnitude)
        {
            InterPos = new Vector2[2];
            InterPos[0] = startPos;
            InterPos[1] = EndPos;
        }
        else
        {
            arrayNum =(int)(innerVec.magnitude / pace);
            InterPos = new Vector2[arrayNum+2];

            InterPos[0] = startPos;
            for (int i = 1; i < arrayNum+1; i++)
            {
                InterPos[i] = InterPos[i - 1] + dirVec;
            }
            InterPos[arrayNum+1] = EndPos;
        }




        return InterPos;
    }

}
