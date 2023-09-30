using UnityEngine;

public class SS_beam : MonoBehaviour
{
    private GameObject ppp;
    public GameObject tt;
    private Transform target; // ターゲットのTransformコンポーネント
    public float stretchSpeed = 1.0f; // 伸縮の速度

    private Vector3 initialScale; // オブジェクトの初期スケール
    private bool isStretching = true; // 伸縮中かどうか

    private void Start()
    {
        ppp = GameObject.FindWithTag("beam");

        target = tt.transform;
    }

    private void Update()
    {
        if (isStretching)
        {
            initialScale = ppp.transform.localScale;
            // ターゲットの位置からオブジェクトへのベクトルを取得
            Vector3 directionToTarget = target.position - ppp.transform.position;

            // ターゲットの位置に向かって伸縮
            float distanceToTarget = directionToTarget.magnitude;

            // オブジェクトのスケールを変更して伸縮させる
            ppp.transform.localScale = initialScale + Vector3.forward * (distanceToTarget * stretchSpeed);

            // ターゲットに到達したら伸縮を停止
            if (distanceToTarget < 0.1f)
            {
                isStretching = false;
            }
        }
    }
}