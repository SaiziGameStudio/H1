using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    private CharacterController controller;
    public float Speed = 10f;
    public float RotateSpeed = 10f;
    //两个相机
    //public Camera camera_was;
    //public Camera camera_mou;
    //public bool cam_status = false;
    //重力
    public float Gravity = -9.8f;
    private Vector3 Velocity = Vector3.zero;
    public Transform GroundCheck;
    public float CheckRadius = 0.2f;
    private bool IsGround;
    public LayerMask layerMask;
    //跳跃
    public float JumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {
        controller = transform.GetComponent<CharacterController>();//自动获取目标
    }
    // Update is called once per frame
    void Update()
    {
        MoveLikeTopDown();
        /*if (Input.GetKeyDown(KeyCode.X))
        {
            switch (camera_was.enabled)
            {
                case true:
                    camera_was.enabled = false;
                    camera_mou.enabled = true;
                    cam_status = false;
                    break;
                case false:
                    camera_was.enabled = true;
                    camera_mou.enabled = false;
                    cam_status = true;
                    break;
            }
        }
        if (cam_status == true)
        {
            MoveLikeWow();
        }
        if (cam_status == false)
        {
            MoveLikeTopDown();
        }
        */
    }
    
    private void MoveLikeWow()
    {
        IsGround = Physics.CheckSphere(GroundCheck.position, CheckRadius, layerMask);
        if (IsGround && Velocity.y<0)
        {
            Velocity.y = 0;
        }
        //只有在地板上才能跳跃
        if (IsGround && Input.GetButton("Jump"))
        {
            Velocity.y += Mathf.Sqrt(JumpHeight * -2 - Gravity);//跳跃公式，两倍高度*-2*重力开根号
        }

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var move = transform.forward * Speed * vertical * Time.deltaTime;
        controller.Move(move);

        Velocity.y += Gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);

        transform.Rotate(Vector3.up, horizontal * RotateSpeed);
    }
    private void MoveLikeTopDown()
    {
        //重力
        IsGround = Physics.CheckSphere(GroundCheck.position, CheckRadius, layerMask);//检测layer mask取消重力加速度
        if (IsGround && Velocity.y < 0)
        {
            Velocity.y = 0;
        }
        //只有在地板上才能跳跃
        if (IsGround && Input.GetButton("Jump"))
        {
            Velocity.y += Mathf.Sqrt(JumpHeight * -2 - Gravity);//跳跃公式，两倍高度*-2*重力开根号
        }
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontal, 0, vertical).normalized;
        var move = direction * Speed * Time.deltaTime;

        controller.Move(move);
        Velocity.y += Gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);//速度*运动时间

        var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);//鼠标坐标是屏幕空间坐标，将角色坐标从世界空间转到屏幕空间
        var point = Input.mousePosition - playerScreenPoint;//鼠标坐标减去角色坐标，得到指向鼠标的向量
        var angle = Mathf.Atan2(point.x, point.y) * Mathf.Rad2Deg;//把角度*一个弧度转角度的常量，赋值给角色的欧拉角
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,angle, transform.eulerAngles.z);
    }
}
