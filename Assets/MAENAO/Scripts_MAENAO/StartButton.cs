using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject textObject;
    private Text startText;
    private Color currentStartColor;
    
    // Start is called before the first frame update
    void Start()
    {
        startText = textObject.GetComponent<Text>();
        currentStartColor = startText.color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        SceneManager.LoadScene("TAMIYANOMAR_Scene_MAENAO"); // メインのゲームシーン
        //Debug.Log("ボタン押した");
    }

    public void ChangeStartColor() // カーソルが乗ったら色変わる
    {
        startText.color = new Color(255f, 255f, 255f, 255f);
    }
    public void ResetStartCloror() // カーソルが離れたら元の色に戻る
    {
        startText.color = currentStartColor;
    }
    
       


}
