using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TestText : MonoBehaviour
{
    [SerializeField] private ControllerManager cm;

    public Text text; // Textオブジェクト
    public Text Horizontal, Vertical;

    // 初期化
    void Start()
    {
    }

    // 更新
    void Update()
    {
        text.text = "入力なし";

        cm.Update();

        float hori = cm.GetNormLeftStickHorizontal();
        float ver = cm.GetNormLeftStickVertical();

        if (cm.LeftStickUp())
        {
            text.text = "左スティック：上";
        }
        if(cm.LeftStickDown())
        {
            text.text = "左スティック：下";
        }
        if (cm.LeftStickRight())
        {
            text.text = "左スティック：右";
        }
        if (cm.LeftStickLeft())
        {
            text.text = "左スティック：左";
        }
        if (cm.LeftStickRightUp())
        {
            text.text = "左スティック：右上";
        }
        if (cm.LeftStickRightDown())
        {
            text.text = "左スティック：右下";
        }
        if (cm.LeftStickLeftUp())
        {
            text.text = "左スティック：左上";
        }
        if (cm.LeftStickLeftDown())
        {
            text.text = "左スティック：左下";
        }

        Horizontal.text = "Horizontal:" + hori.ToString();
        Vertical.text = "Vertical:" + ver.ToString();
    }
}