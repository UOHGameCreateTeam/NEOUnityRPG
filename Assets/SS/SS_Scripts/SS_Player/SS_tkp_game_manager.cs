using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_tkp_game_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            //Debug.Log("Z");
            //Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
