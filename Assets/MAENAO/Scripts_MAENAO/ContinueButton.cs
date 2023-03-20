using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] GameObject textObject;
    private Text ContinueText;
    private Color currentContinueColor;
    // Start is called before the first frame update
    void Start()
    {
        ContinueText = textObject.GetComponent<Text>();
        currentContinueColor = ContinueText.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene("StartScene"); // �J�ڂ�����Scene��������
        Debug.Log("�{�^��������");
    }

    public void ChangeContinueColor() // �J�[�\�����������F�ς��
    {
        ContinueText.color = new Color(255f, 255f, 255f, 255f);
    }
    public void ResetContinueCloror() // �J�[�\�������ꂽ�猳�̐F�ɖ߂�
    {
        ContinueText.color = currentContinueColor;
    }

}
