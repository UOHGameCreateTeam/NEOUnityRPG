using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("hogehogeScene"); // ‘JˆÚ‚µ‚½‚¢Scene‚ð“ü‚ê‚é
        Debug.Log("ƒ{ƒ^ƒ“‰Ÿ‚µ‚½");
    }
}
