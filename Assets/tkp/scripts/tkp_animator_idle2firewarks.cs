using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkp_animator_idle2firewarks : MonoBehaviour
{
    //
    private GameObject enemy_obj;
    private int now_atk_time;
    private float timer = 0f;

    private Animator animators;

    private int atk_interval;

    private int offset = 500;
    private int blow_away_time;
    private int spray_dmg_area_time;
    // Start is called before the first frame update
    void Start()
    {
        enemy_obj = transform.root.gameObject;
        atk_interval = enemy_obj.GetComponent<tkp_Enemy_atk_blow_away>().get_atk_interval();
        blow_away_time = enemy_obj.GetComponent<tkp_Enemy_atk_blow_away>().get_wave_time();
        spray_dmg_area_time = enemy_obj.GetComponent<tkp_Enemy_atk_blow_away>().get_spray_time();
        
        animators = this.gameObject.GetComponent<Animator>();
        // Debug.Log(transform.root.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int now_atk_time = enemy_obj.GetComponent<tkp_Enemy_atk_blow_away>().get_now_time();

        if(now_atk_time < spray_dmg_area_time)
        {
            if((int)(timer*10) % 10 == 0)
            {
                SoundManager.Instance.PlaySE(SESoundData.SE.wave_launch, SourceData.Source.wave);
            }
            
            animators.SetBool("firewarks", true);
        }
        else
        {
            animators.SetBool("firewarks", false);
        }
        

        if(((now_atk_time + offset) % blow_away_time == 0))
        {
            animators.SetBool("wave", true);
        }
        else if(now_atk_time < spray_dmg_area_time)
        {
            animators.SetBool("wave", false);
        }
    }
}

