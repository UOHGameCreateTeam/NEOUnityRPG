using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearEffect : MonoBehaviour
{
    public bool fadeout = false;
    private float speed = 0.02f;
    Image fadeoutPanel;
    private float red, green, blue, alpha;

    // Start is called before the first frame update
    void Start()
    {
        fadeoutPanel = GetComponent<Image>();
        red = fadeoutPanel.color.r;
        green = fadeoutPanel.color.g;
        blue = fadeoutPanel.color.b;
        alpha = fadeoutPanel.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout)
        {
            ClearFadeout();
        }
    }

    private void ClearFadeout()
    {
        alpha += speed;
        fadeoutPanel.color = new Color(red, green, blue, alpha);
        if (alpha >= 1)
        {
            fadeout = false;
        }
    }
}
