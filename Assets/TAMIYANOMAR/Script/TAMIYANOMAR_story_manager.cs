using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMIYANOMAR_story_manager : MonoBehaviour
{
    //[SerializeField] private GameObject story_object;
    [SerializeField] private string story;
    private float timer = 0f;
    private float _story_time = 0f;
    private bool activated = false;
    void Update()
    {
        if (activated)
        {
            timer += Time.deltaTime;
            Debug.Log(story);
            //‚±‚±‚ÅUI‚Ì•\Ž¦‚ðs‚¤
            if (timer > _story_time)
            {
                activated = false;
            }
        }
    }

    public void StartManager(float story_time)
    {
        _story_time = story_time;
        activated = true;
    }
}
