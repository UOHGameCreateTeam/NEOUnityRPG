using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kyui_BackToStartButton : MonoBehaviour
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

    public void ChangeBackToStartColor() // �J�[�\�����������F�ς��
    {
        RestartText.color = new Color(255f, 255f, 255f, 255f);
    }
    public void ResetBackToStartStartCloror() // �J�[�\�������ꂽ�猳�̐F�ɖ߂�
    {
        RestartText.color = currentRestartColor;
    }
    public void OnClick()
    {
        SceneManager.LoadScene("Kyui27/Ending_Scenes");
    }
}
