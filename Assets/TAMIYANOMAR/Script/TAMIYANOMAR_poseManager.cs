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
            timer += Time.deltaTime;
            if(timer >= pose_end)
            {
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
