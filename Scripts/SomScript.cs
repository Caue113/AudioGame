using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomScript : MonoBehaviour
{
    public Transform BoundBlock;
    public Transform Som;
    public Transform PlayerPos;

    public float[] XLim;
    public float[] YLim;

    public float CurrentPosX;
    public float CurrentPosY;

    void Start()
    {
        XLim = new float[2];
        YLim = new float[2];
        Som = GetComponent<Transform>();
        BoundBlock = Som.transform.parent;

        XLim[0] = BoundBlock.transform.position.x - BoundBlock.transform.localScale.x / 2;
        XLim[1] = BoundBlock.transform.position.x + BoundBlock.transform.localScale.x / 2;
        YLim[0] = BoundBlock.transform.position.y - BoundBlock.transform.localScale.y / 2;
        YLim[1] = BoundBlock.transform.position.y + BoundBlock.transform.localScale.y / 2;


    }

    void Update()
    {

        PlayerPos = GameObject.Find("Player").transform;

        if (PlayerPos.transform.position.x > XLim[1])
        {
            CurrentPosX = XLim[1];
        }
        else if (PlayerPos.transform.position.x < XLim[0])
        {
            CurrentPosX = XLim[0];
        }
        else
        {
            CurrentPosX = PlayerPos.transform.position.x;
        }

        if (PlayerPos.transform.position.y > YLim[1])
        {
            CurrentPosY = YLim[1];
        }
        else if (PlayerPos.transform.position.y < YLim[0])
        {
            CurrentPosY = YLim[0];
        }
        else
        {
            CurrentPosY = PlayerPos.transform.position.y;
        }
        Som.transform.position = new Vector2(CurrentPosX, CurrentPosY);
    }
}