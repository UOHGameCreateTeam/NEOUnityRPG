using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene("hugehugeScene"); // ‘JˆÚ‚µ‚½‚¢Scene–¼‚ð“ü‚ê‚é
        Debug.Log("ƒ{ƒ^ƒ“‰Ÿ‚µ‚½");
    }

}
