using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkp_draw_line : MonoBehaviour
{
    private Vector3 player_pos;
    private Vector3 enemy_pos;
    public float vent = 0.05f;
    void Update()
    {
        //プレイヤー、敵それぞれの位置を取得
        player_pos = GameObject.Find("Player_1").transform.position;
        enemy_pos = GameObject.Find("tkp_Enemy").transform.position;
        // メッシュを作成
        Mesh mesh = new Mesh();

        // 頂点リストを作成
        List<Vector3> vertices = new List<Vector3>
        {
            new Vector3(player_pos.x,player_pos.y,player_pos.z),
            new Vector3(player_pos.x - vent,player_pos.y,player_pos.z),
            new Vector3(player_pos.x - vent,player_pos.y - vent,player_pos.z),
            new Vector3(player_pos.x,player_pos.y - vent,player_pos.z),
            new Vector3(enemy_pos.x + vent,enemy_pos.y,enemy_pos.z),
            new Vector3(enemy_pos.x,enemy_pos.y,enemy_pos.z),
            new Vector3(enemy_pos.x,enemy_pos.y + vent,enemy_pos.z),
            new Vector3(enemy_pos.x + vent,enemy_pos.y + vent,enemy_pos.z),
            // new Vector3(1.0f, 1.0f, 1.0f),
            // new Vector3(-1.0f, 1.0f, 1.0f),
            // new Vector3(-1.0f, -1.0f, 1.0f),
            // new Vector3(1.0f, -1.0f, 1.0f),
            // new Vector3(1.0f, -1.0f, -1.0f),
            // new Vector3(-1.0f, -1.0f, -1.0f),
            // new Vector3(-1.0f, 1.0f, -1.0f),
            // new Vector3(1.0f, 1.0f, -1.0f),
        };

        // 面を構成するインデックスリストを作成
        List<int> triangles = new List<int> {
            0, 1, 2,  // 奥面
            0, 2, 3,  // 奥面
            4, 5, 6,  // 前面
            4, 6, 7,  // 前面
            0, 4, 7,  // 右面
            0, 3, 4,  // 右面
            6, 2, 1,  // 左面
            6, 5, 2,  // 左面
            6, 1, 0,  // 上面
            7, 6, 0,  // 上面
            4, 3, 2,  // 下面
            5, 4, 2,  // 下面
        };

        // メッシュに頂点を登録する
        mesh.SetVertices(vertices);

        // メッシュに面を構成するインデックスリストを登録する
        mesh.SetTriangles(triangles, 0);

        // 作成したメッシュをメッシュフィルターに設定する
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }
}
