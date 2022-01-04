
using UnityEngine;

public class Fire1 : MonoBehaviour
{



    public GameObject firePoint;//发射点
    //public GameObject exp1;//爆炸效果
    public Rigidbody pp1;//子弹


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1")) 
        {
            
            Debug.Log("yes!!!!");
            Rigidbody clone1;
            clone1 = Instantiate(pp1, transform.position, transform.rotation) as Rigidbody;//生成pp1，位置，角度
            clone1.velocity = transform.TransformDirection(Vector3.left * 20);//向前进方向生成子弹
            
        }
            
    }
}
