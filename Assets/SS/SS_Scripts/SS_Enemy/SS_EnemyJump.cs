using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_EnemyJump : MonoBehaviour
{
    public float jumpForce = 3f;
    public float jumpDelay = 2f;
    public float jumpRange = 50f;
    private float lastJumpTime;
    private Rigidbody rb;
    private Transform player;
    private float ct = 0f;
    private int count = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ct = 0f;

    }
    
    private void Update()
    {
        Debug.Log(ct);
        ct += Time.deltaTime;
        player = GameObject.FindWithTag("Player").transform; // "Player"タグが付いたオブジェクトを取得
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (ct >= 1 && count == 0)
        {
            Jump();
            count++;
        }
        if(ct >= 3 && count == 1)
        {
            tackle();
            count++;
        }
    }
    public void Initialize()
    {
        // 変数の初期化処理を実装する

        ct = 0f;
        count = 0;
    }
    private void Jump()
    {
        rb.velocity = Vector3.zero;
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        
        directionToPlayer.y += 0.5f;
        
        
        rb.AddForce(directionToPlayer * jumpForce, ForceMode.Impulse);
        lastJumpTime = Time.time;
    }
    private void tackle()
    {
        rb.velocity = Vector3.zero;
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        jumpForce *= 3;
        rb.AddForce(directionToPlayer * jumpForce, ForceMode.Impulse);
    }
}
