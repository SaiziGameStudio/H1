using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawStar : MonoBehaviour
{
    //新建一个准星图片
    public Texture2D texture;

    void OnGui()
    {
        Rect rect = new Rect(Input.mousePosition.x - (texture.width / 2),

        Screen.height - Input.mousePosition.y - (texture.height / 2),

        texture.width, texture.height);

        GUI.DrawTexture(rect, texture);
        // Start is called before the first frame update

    }
}
