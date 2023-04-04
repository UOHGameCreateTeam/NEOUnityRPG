using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnFadeOut : MonoBehaviour
{
    GameObject Fade;
    ClearEffect script;
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        Fade = GameObject.Find("Panel");
        script = Fade.GetComponent<ClearEffect>();
        Text.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFadeOut() // �{�^����������N���A���\�������悤�Ɉ�U���Ă�
    {
        script.fadeout = true;
        Text.SetActive(true);
    }
}
