using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_EnemyJump : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private int e_damage = 30;
    public float jumpForce = 50f;
    public float jumpDelay = 1f;
    public float jumpRange = 1000f;
    private float lastJumpTime;
    private Rigidbody rb;
    private Transform player;
    private Transform player_po;
    private float ct = 0f;
    private int count = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ct = 0f;

    }
    
    private void Update()
    {
        //Debug.Log(ct);
        ct += Time.deltaTime;
        player = GameObject.FindWithTag("Player").transform; // "Player"タグが付いたオブジェクトを取得
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (ct >= 1 && count == 0)
        {
            player_po = player;
            Jump(player_po);
            count++;
        }
        if(ct >= 3 && count == 1)
        {
            tackle(player_po);
            count++;
        }
        if (ct >= 6 && count == 2)
        {

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            this.GetComponent<SS_EnemyJump>().enabled = false;

        }
    }
    public void Initialize()
    {
        // 変数の初期化処理を実装する

        ct = 0f;
        count = 0;
    }
    private void Jump(Transform player)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        
        directionToPlayer.y += 0.5f;
        
        
        rb.AddForce(directionToPlayer * jumpForce, ForceMode.Impulse);
        rb.angularVelocity = Vector3.zero;
        lastJumpTime = Time.time;
    }
    private void tackle(Transform player)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        rb.AddForce(directionToPlayer * jumpForce * 3, ForceMode.Impulse);
        rb.angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (ct >= 3 && count == 2)
        {
            if (collision.gameObject.tag == "ground")
            {
                rb.velocity = Vector3.zero;
                this.GetComponent<SS_EnemyJump>().enabled = false;
            }
            if (collision.gameObject.tag == "Player")
            {
                rb.velocity = Vector3.zero;
                this.GetComponent<SS_EnemyJump>().enabled = false;
                addDamage(e_damage, Player);
            }
        }


    }
    private void addDamage(int damage, GameObject gameobject)
    {
        Debug.Log(damage);
        int now_hp = gameobject.GetComponent<tkp_player_tkp>().get_hp();
        gameobject.GetComponent<tkp_player_tkp>().set_hp(now_hp - damage);
    }
    private void zero()
    {
        rb.velocity = Vector3.zero;
    }
}
