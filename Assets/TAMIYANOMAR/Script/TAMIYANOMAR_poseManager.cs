using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_poseManager : MonoBehaviour
{
    private bool posed = false;

    private float pose_end = 0f;

    private float timer = 0f;
    // Update is called once per frame
    void Update()
    {
        if(posed)
        {
            SoundMaster.instance.VolBGM(0.5f);
            timer += Time.deltaTime;
            if (pose_end - timer < 1)
            {
                SoundMaster.instance.VolBGM(1.0f - (pose_end - timer) * 0.5f);
            }
            if(timer >= pose_end)
            {
                SoundMaster.instance.VolBGM(1.0f);
                posed = false;
                timer = 0f;
                pose_end = 0f;
            }
        }
    }

    public void StartPose(float end_time)
    {
        posed = true;
        pose_end = end_time;
        timer = 0f;
    }

    public bool GetPosed()
    {
        return posed;
    }
}
