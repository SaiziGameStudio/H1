using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow1 : MonoBehaviour
{
    public GameObject Camera;
    public Rigidbody rd;
    public float Sportspeed2 = 5;
    private Camera camera;
    public float Rotatespeed;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInChildren<Camera>(); //这句是赋值在unity中不用再赋值；
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 speed = new Vector3(h, 0, v);
        rd.velocity = speed * Sportspeed2;
        float X = Input.GetAxis("Mouse X") * Rotatespeed;
        float Y = Input.GetAxis("Mouse Y") * Rotatespeed;
        camera.transform.localRotation = camera.transform.localRotation * Quaternion.Euler(-Y, 0, 0);
        transform.localRotation = transform.localRotation * Quaternion.Euler(0, X, 0);

    }
}
