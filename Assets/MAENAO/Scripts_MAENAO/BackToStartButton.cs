using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class BackToStartButton : MonoBehaviour
{
    [SerializeField] GameObject textObject;
    private Text RestartText;
    private Color currentRestartColor;
    // Start is called before the first frame update
    void Start()
    {
        RestartText = textObject.GetComponent<Text>();
        currentRestartColor = RestartText.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("StartScene"); // 遷移したいScene名

    }

    public void ChangeBackToStartColor() // カーソルが乗ったら色変わる
    {
        RestartText.color = new Color(255f, 255f, 255f, 255f);
    }
    public void ResetBackToStartStartCloror() // カーソルが離れたら元の色に戻る
    {
        RestartText.color = currentRestartColor;
    }
}
