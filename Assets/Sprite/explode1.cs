using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode1 : MonoBehaviour
{
    public GameObject exp1;//爆炸效果
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "wall1") 
        { 
            Instantiate(exp1, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
 
   
}
