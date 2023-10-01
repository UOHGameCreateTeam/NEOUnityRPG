using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScene", 115f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("MAENAO/StartScene");
    }
}
