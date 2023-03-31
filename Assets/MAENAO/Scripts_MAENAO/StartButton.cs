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

    public void ClickStartButton()
    {
        SceneManager.LoadScene("MAENAO_main_Scene"); // 
        
    }

    public void ChangeStartColor() //
    {
        startText.color = new Color(255f, 255f, 255f, 255f);
    }
    public void ResetStartCloror() //
    {
        startText.color = currentStartColor;
    }




}

