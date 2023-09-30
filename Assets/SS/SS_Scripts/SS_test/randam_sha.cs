using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randam_sha : MonoBehaviour
{
    public GameObject objectToLaunch; // 射出するオブジェクト
    public float launchForce = 10f; // 射出力

    void Start()
    {
        // オブジェクトを自動生成し、ランダムな方向に射出する
        StartCoroutine(LaunchObjects());
    }

    IEnumerator LaunchObjects()
    {
        while (true)
        {
            // 新しいオブジェクトを生成
            GameObject newObject = Instantiate(objectToLaunch, transform.position, Quaternion.identity);

            // ランダムな方向に射出するベクトルを計算
            Vector3 launchDirection = Random.onUnitSphere;
            launchDirection.y = 1;

            // 射出力を適用
            Rigidbody rb = newObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
            }
           
            Destroy(newObject, 6.0f);
            

            // 一定の間隔でオブジェクトを生成
            yield return new WaitForSeconds(1.0f);

        }
    }
}