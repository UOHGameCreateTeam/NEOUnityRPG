using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horming4 : MonoBehaviour
{
    [SerializeField] public float maxHeight = 5f; // 放物線の最大高さ
    [SerializeField] public float throwAngle = 45f; // 放物線の角度
    [SerializeField] public float throwSpeed = 10f; // 放物線の速度
    private GameObject player;
    private GameObject hasshadai;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float initialVelocity;

    void Start()
    {
        player = GameObject.FindWithTag("test_cube_1");
        hasshadai = GameObject.FindWithTag("test_hassha");
        if (hasshadai.transform == null || player.transform == null)
        {
            Debug.LogError("Start Object and Target Object must be assigned.");
            return;
        }

        initialPosition = hasshadai.transform.position;
        targetPosition = player.transform.position;

        // 初速度を計算
        initialVelocity = CalculateInitialVelocity();

        // 放物線を描くコルーチンを開始
        StartCoroutine(ThrowObject());
    }

    float CalculateInitialVelocity()
    {
        // 初速度を計算する式
        float distance = Vector3.Distance(initialPosition, targetPosition);
        float g = Physics.gravity.magnitude;
        float tanTheta = Mathf.Tan(throwAngle * Mathf.Deg2Rad);
        float velocity = Mathf.Sqrt((distance * g) / (2.0f * (maxHeight - initialPosition.y * tanTheta)));
        return velocity;
    }

    IEnumerator ThrowObject()
    {
        float startTime = Time.time;

        while (true)
        {
            float elapsedTime = Time.time - startTime;

            // 放物線の水平方向の位置を計算
            float horizontalDistance = initialVelocity * elapsedTime;
            Vector3 horizontalDirection = (targetPosition - initialPosition).normalized;
            Vector3 horizontalPosition = initialPosition + horizontalDirection * horizontalDistance;

            // 放物線の垂直方向の位置を計算
            float verticalPosition = initialPosition.y + (Mathf.Tan(throwAngle * Mathf.Deg2Rad) * horizontalDistance - (Physics.gravity.magnitude * horizontalDistance * horizontalDistance) / (2.0f * initialVelocity * initialVelocity));

            // オブジェクトの位置を更新
            transform.position = new Vector3(horizontalPosition.x, verticalPosition, horizontalPosition.z);

            if (elapsedTime >= (2.0f * initialVelocity * Mathf.Sin(throwAngle * Mathf.Deg2Rad) / Physics.gravity.magnitude))
            {
                // 放物線が終了したらコルーチンを終了
                yield break;
            }

            yield return null;
        }
    }
}
