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
        SoundManager.Instance.PlaySE(SESoundData.SE.test1,SourceData.Source.test1);
        Invoke("ChangeScene", 1.5f);
    }
    public void ChangeScene(){
        SceneManager.LoadScene("TAMIYANOMAR/TAMIYANOMAR_Scene"); // ���C���̃Q�[���V�[��
        //Debug.Log("�{�^��������");
    }

    public void ChangeStartColor() // �J�[�\�����������F�ς��
    {
        startText.color = new Color(255f, 255f, 255f, 255f);
    }
    public void ResetStartCloror() // �J�[�\�������ꂽ�猳�̐F�ɖ߂�
    {
        startText.color = currentStartColor;
    }
    
       


}
