using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_beam2 : MonoBehaviour
{
    public GameObject player; // プレイヤーオブジェクト
    public GameObject beamPrefab; // ビームのプレハブ
    public float beamSpeed = 5.0f; // ビームの速度
    public float maxBeamLength = 10.0f; // ビームの最大長さ
    private Transform tttt;
    Vector3 endPosition;
    private GameObject currentBeam;
    private LineRenderer lineRenderer;
    private float currentBeamLength = 0.0f;

    void Start()
    {
        // ビームのプレハブをインスタンス化して、現在のビームとして設定
        currentBeam = Instantiate(beamPrefab, transform.position, Quaternion.identity);
        lineRenderer = currentBeam.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        endPosition = transform.position;
        lineRenderer.SetPosition(0, transform.position); // ビームの開始位置を設定
        lineRenderer.SetPosition(1, endPosition); // ビームの終了位置も開始位置と同じに設定
    }

    void Update()
    {
        // 対象物と自分自身の座標からベクトルを算出
        Vector3 vector3 = player.transform.position - currentBeam.transform.position;
        // もし上下方向の回転はしないようにしたければ以下のようにする。
        // vector3.y = 0f;

        // Quaternion(回転値)を取得
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        // 算出した回転値をこのゲームオブジェクトのrotationに代入
        currentBeam.transform.rotation = quaternion;
        if (currentBeamLength < maxBeamLength)
        {
            // ビームの伸び具合を更新
            currentBeamLength += beamSpeed * Time.deltaTime;
            currentBeamLength = Mathf.Clamp(currentBeamLength, 0.0f, maxBeamLength);

            // ビームの終了位置を更新
            endPosition = endPosition + currentBeam.transform.forward * currentBeamLength;
            lineRenderer.SetPosition(1, endPosition);
        }
    }
}
