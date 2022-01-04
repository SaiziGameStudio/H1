using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    //两个相机
    public  Camera camera_FPS;
    public  Camera camera_GOD;
    // Start is called before the first frame update
    void Start()
    {
        //初始两个相机状态
        camera_FPS.enabled = true;
        camera_GOD.enabled = false;
    }

    // Update is called once per frame
    void Update()//通过点击不同的按键实现相机的切换
    {
        
        if (Input.GetKeyDown(KeyCode.X))
        {

            switch (camera_FPS.enabled)
        {
                case   true:
                    camera_FPS.enabled = false;
                    camera_GOD.enabled = true;
                    break;
                case false:
                    camera_FPS.enabled = true;
                    camera_GOD.enabled = false;
                    break;
        }
            
        }
    }
}
