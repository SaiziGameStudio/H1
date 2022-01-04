using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    //ToolTip 控件主要用于显示提示信息，当鼠标移至指定位置时，会显示相应的提示信息
    [Tooltip("Angular velocity in degrees per second")]
    public float degPerSec = 60.0f;

    [Tooltip("Rotation axis")]
    public Vector3 rotAxis = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        // 他会把一个向量直接变成 长度为一的 单位向量。
        rotAxis.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotAxis, degPerSec * Time.deltaTime);
    }
}
