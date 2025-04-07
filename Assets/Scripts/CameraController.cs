using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform target;

    public Transform farBackground, middleBackground; //我们希望让背景随着角色移动而移动

    public float minHeight, maxHeight; //我们希望相机可拍摄有限高度，而不希望其跌入谷底或升至天边

    public bool stopFollow;

    //private float lastXPos;
    private Vector2 lastPos;

    public void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //lastXPos = transform.position.x;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update() //移动相机的位置，以便链接相机到角色
    {
        /* transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); //实际上用不到z,我们也不希望摄像机随着小狐狸跳跃而跳跃。


        float clampedYPos = Mathf.Clamp(transform.position.y, minHeight, maxHeight); //限制相机的高度,Clamp是一个函数，用于限制数值的范围 */
        if (!stopFollow)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

            //float amountToMoveX = transform.position.x - lastXPos; //在x轴上移动的距离
            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y); //在x轴和y轴上移动的距离
            farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f); //记住不可以直接使用camera的position，因为如果z轴相同，camera将没有能力拍到他们
            middleBackground.position = middleBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f) * 0.5f; //海与灌木不同的速度，让世界更有深度

            //lastXPos = transform.position.x; //每次移动都更新lastPos
            lastPos = transform.position;
        }
    }
}
