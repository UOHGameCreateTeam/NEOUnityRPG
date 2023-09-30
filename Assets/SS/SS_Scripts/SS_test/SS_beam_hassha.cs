using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_beam_hassha : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3.0f;
    [SerializeField] private GameObject beamPrefab; // ビームのプレハブ
    private GameObject player; // プレイヤーオブジェクト
    private Vector3 player_position;
    private Vector3 endPosition;
    private GameObject currentBeam;
    private LineRenderer lineRenderer;
    
    void Start()
    {
        player = GameObject.FindWithTag("test_cube_1");
    }

    void Update()
    {
    }
    public void player_search()
    {
        player_position = player.transform.position;
        Vector3 instanse_position = new Vector3(transform.position.x, transform.position.y+3, transform.position.z);
        // ビームのプレハブをインスタンス化して、現在のビームとして設定
        currentBeam = Instantiate(beamPrefab, instanse_position, Quaternion.identity);
        Destroy(currentBeam, lifeTime);

        // 対象物と自分自身の座標からベクトルを算出
        Vector3 vector3 = player_position - currentBeam.transform.position;

        // Quaternion(回転値)を取得
        Quaternion quaternion = Quaternion.LookRotation(vector3);

        // 算出した回転値をこのゲームオブジェクトのrotationに代入
        currentBeam.transform.rotation = quaternion;
    }
}