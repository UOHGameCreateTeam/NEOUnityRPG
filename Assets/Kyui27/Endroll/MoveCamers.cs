using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamers : MonoBehaviour
{
    float UnderLimit = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;
 
        // 座標を取得
        Vector3 pos = myTransform.position;
        if(pos.y > UnderLimit){
            pos.y -= 0.001f;    // y座標へ0.01加算
            Debug.Log(pos.y);
        }
        
 
        myTransform.position = pos;  // 座標を設定
    }
}