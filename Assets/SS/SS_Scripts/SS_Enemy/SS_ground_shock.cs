using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_ground_shock : MonoBehaviour
{
    [SerializeField] private GameObject createObject; // 生成するオブジェクト
    private GameObject Player;
    [SerializeField] private int itemCount = 40; // 生成するオブジェクトの数

    [SerializeField] private float radius = 10f; // 半径

    [SerializeField] private float repeat = 2f; // 何周期するか
    [SerializeField] private int e_damage = 30;
    [SerializeField] private float Jump_speed = 2f; // 何周期するか
    [SerializeField] private float speed = 5f;
    public float jumpForce = 80f;
    public float jumpDelay = 2f;
    public float jumpRange = 50f;
    private float lastJumpTime;
    private Rigidbody rb;
    private Transform player;
    private float ct = 0f;
    private int count = 0;
    private bool jump_flag = false;
    private bool ground_flag = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ct = 0f;
        
    }

    private void Update()
    {
        //Debug.Log(ct);
        ct += Time.deltaTime;
        player = GameObject.FindWithTag("test_cube_1").transform; 
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (ct >= 2 && count == 0)
        {
            if (jump_flag == false) {
                Jump();
                count++;
                jump_flag = true;
            }
            
        }
        if (ct >= 4 && count == 1)
        {
            if (ground_flag == false)
            {
                this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
                tackle();
                count++;
                ground_flag = true;
            }
        }
    }
    public void Initialize()
    {
        // 変数の初期化処理を実装する

        ct = 0f;
        count = 0;
        ground_flag = false;
        jump_flag = false;
    }
    private void Jump()
    {
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        Vector3 uppow = new Vector3(0, 1, 0);


        rb.AddForce(uppow * jumpForce, ForceMode.Impulse);
        lastJumpTime = Time.time;
    }

    private void tackle()
    {
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        Vector3 downpow = new Vector3(0, -1, 0);
        rb.AddForce(downpow * jumpForce, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (ct >= 2) {
            Debug.Log("当たったよ");
            if (collision.gameObject.tag == "ground")
            {
                Debug.Log("当たったよ");
                inpact_object();
                rb.velocity = Vector3.zero;
                Initialize();
                SoundManager.Instance.PlaySE(SESoundData.SE.devil_jump, SourceData.Source.yellow_devil);
            }
            if (collision.gameObject.tag == "test_cube_1")
            {
                inpact_object();
                addDamage(e_damage, collision.gameObject);
                rb.velocity = Vector3.zero;
                Initialize();
                SoundManager.Instance.PlaySE(SESoundData.SE.devil_jump, SourceData.Source.yellow_devil);
            }
        }
            
        
        
      
    }
    private void addDamage(int damage, GameObject gameobject)
    {
        Debug.Log(damage);
        int now_hp = gameobject.GetComponent<tkp_player_tkp>().get_hp();
        gameobject.GetComponent<tkp_player_tkp>().set_hp(now_hp - damage);
    }
    public void inpact_object()
    {
        var oneCycle = 2.0f * Mathf.PI; // sin の周期は 2π

        for (var i = 0; i < itemCount; ++i)
        {

            var point = ((float)i / itemCount) * oneCycle; // 周期の位置 (1.0 = 100% の時 2π となる)
            var repeatPoint = point * repeat; // 繰り返し位置

            var x = Mathf.Cos(repeatPoint) * radius;
            var z = Mathf.Sin(repeatPoint) * radius;

            var position = new Vector3(this.transform.position.x + x, 0, this.transform.position.z + z);

            GameObject inpact = Instantiate(
                createObject,
                position,
                Quaternion.identity
            );

            Destroy(inpact, 3.0f);
        }
    }
}
