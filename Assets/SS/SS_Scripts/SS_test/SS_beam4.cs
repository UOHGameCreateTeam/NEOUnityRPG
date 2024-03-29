using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_beam4 : MonoBehaviour
{
    private Vector3 hitPos;
    public GameObject player; // プレイヤーオブジェクト
    public GameObject beamPrefab; // ビームのプレハブ
    public float base_beamSpeed = 30f;
    private float beamSpeed; // ビームの速度
    public float maxBeamLength = 100.0f; // ビームの最大長さ
    public float mae = 0f;
    private Transform tttt;
    private Vector3 player_position;
    Vector3 endPosition;
    private GameObject currentBeam;
    private LineRenderer lineRenderer;
    private float currentBeamLength = 0.0f;
    private float lightdis = 0f;
    private bool beam_flag = false;
    private float time = 0f;
    public float intarval = 2f;
    public float lifeTime = 5.0f;
    void Start()
    {
        
    }

    void Update()
    {
       

        if (beam_flag == true)
        {
            beam_flag = beam_attack();
        }
}
    public void player_search() {
        beamSpeed = base_beamSpeed;
        currentBeamLength = 0;
        player_position = player.transform.position;
        // ビームのプレハブをインスタンス化して、現在のビームとして設定
        currentBeam = Instantiate(beamPrefab, transform.position + transform.forward * mae, Quaternion.identity);
        Destroy(currentBeam, lifeTime);
        lineRenderer = currentBeam.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        endPosition = currentBeam.transform.position;
        lineRenderer.SetPosition(0, transform.position); // ビームの開始位置を設定
        lineRenderer.SetPosition(1, endPosition); // ビームの終了位置も開始位置と同じに設定
    }

    public void attack_flag() { 
        beam_flag = true;
    }

    private bool beam_attack() {
        // 対象物と自分自身の座標からベクトルを算出
        Vector3 vector3 = player_position - currentBeam.transform.position;
        // もし上下方向の回転はしないようにしたければ以下のようにする。
        // vector3.y = 0f;

        // Quaternion(回転値)を取得
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        // 算出した回転値をこのゲームオブジェクトのrotationに代入
        currentBeam.transform.rotation = quaternion;

        lightdis = Vector3.Distance(currentBeam.transform.position, endPosition);
        Vector3 direction = currentBeam.transform.forward * lightdis;
        //Vector3 rayStartPosition = hand.transform.forward * lazerStartPointDistance;
        //Vector3 pos = hand.transform.position;
        RaycastHit hit;
        Ray ray = new Ray(currentBeam.transform.position, currentBeam.transform.forward);

        //lineRenderer.SetPosition(0, pos + rayStartPosition);
        /*
        if (Physics.Raycast(ray, out hit, lightdis))
        {
            hitPos = hit.point;
            lineRenderer.SetPosition(1, hitPos);
        }
        else
        {
            lineRenderer.SetPosition(1, pos + direction);
        }*/


        //Debug.DrawRay(ray.origin, ray.direction * lightdis, Color.red, 5.0f); // 長さ３０、赤色で５秒間可視
        if (currentBeamLength < maxBeamLength)
        {
            if (Physics.Raycast(ray, out hit, lightdis))
            {
                hitPos = hit.point;
                Debug.Log(hit.collider.gameObject.name);
                lineRenderer.SetPosition(1, hitPos);
                //Destroy(currentBeam);
                return false;
            }
            else
            {
                // ビームの伸び具合を更新
                currentBeamLength += beamSpeed * Time.deltaTime;
                currentBeamLength = Mathf.Clamp(currentBeamLength, 0.0f, maxBeamLength);

                // ビームの終了位置を更新
                endPosition = currentBeam.transform.position + currentBeam.transform.forward * currentBeamLength;
                lineRenderer.SetPosition(1, endPosition);
                return true;
            }

        }
        else { 
            return false;
        }
    }
}
