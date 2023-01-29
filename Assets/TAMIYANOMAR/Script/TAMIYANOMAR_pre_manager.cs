using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_pre_manager : MonoBehaviour
{
    [SerializeField] GameObject playerObj;

    private bool activated = false;
    private bool arrived = false;
    private bool first_activated = false;
    private bool bgm_start = false;
    private float bgm_timer = 0f;
    private Vector2 destination;

    [SerializeField] private AudioClip fieldbgm;
    [SerializeField] private AudioClip fieldintro;
    [SerializeField] private AudioClip battlebgm;
    [SerializeField] private AudioClip battleintro;

    private void Start()
    {
        activated = false;
        arrived = false;
    }

    void Update()
    {
        if(activated == true)
        {
            if(first_activated ==false)
            {
                bgm_timer += Time.deltaTime / 3.0f;
                if (bgm_start == false)
                {
                    
                    bgm_start = true;
                }
                SoundMaster.instance.VolBGM(1 - bgm_timer);
                if(bgm_timer >= 1.0f)
                {
                    SoundMaster.instance.PlayBGM(fieldbgm, fieldintro, 1);
                    SoundMaster.instance.VolBGM(1f);
                    bgm_timer = 0f;
                    first_activated = true;
                }
            }

            float gap_x = Mathf.Abs(playerObj.transform.position.x - destination.x);
            float gap_z = Mathf.Abs(playerObj.transform.position.z - destination.y);


            
            float dis = Mathf.Pow((gap_x * gap_x)+(gap_z * gap_z), 0.5f);

            //サウンドをシームレスに変化
            if (dis <= 65f)
            {
                if (((dis - 25f) / 30f) <= 1)
                {
                    SoundMaster.instance.VolBGM(((dis - 25f) / 65f));
                }
            }

            if (dis <= 15f)
            {
                SoundMaster.instance.PlayBGM(battlebgm, battleintro, 2);
                SoundMaster.instance.VolBGM(1.0f);

                //バトルサウンドにする
                //Debug.Log("arrived true");
                arrived = true;
                activated = false;
                TAMIYANOMAR_destination_manager destination_Manager = this.gameObject.GetComponent<TAMIYANOMAR_destination_manager>();
                destination_Manager.deactivateDestination();
            }
        }
    }

    public void setActive(Vector2 dest)
    {
        //Debug.Log("activate dest");
        activated = true;
        destination = dest;
        arrived = false;
        first_activated = false;
        bgm_start = false;
        TAMIYANOMAR_destination_manager destination_Manager =  this.gameObject.GetComponent<TAMIYANOMAR_destination_manager>();
        destination_Manager.activateDestination(dest);
    }

    public bool getArrived()
    {
        return arrived;
    }


    //not needed
    public Vector3 getDestination()
    {
        return new Vector3(destination.x, 0f, destination.y);
    }
}
