using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TestText : MonoBehaviour
{
    [SerializeField] private ControllerManager cm;

    public Text text; // Textオブジェクト
    public Text angle;

    // 初期化
    void Start()
    {
    }

    // 更新
    void Update()
    {
        text.text = "入力なし";

        cm.Update();

        float atan = cm.GetLeftAngle();

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


        if (cm.RightStickUp())
        {
            text.text = "右スティック：上";
        }
        if (cm.RightStickDown())
        {
            text.text = "右スティック：下";
        }
        if (cm.RightStickRight())
        {
            text.text = "右スティック：右";
        }
        if (cm.RightStickLeft())
        {
            text.text = "右スティック：左";
        }
        if (cm.RightStickRightUp())
        {
            text.text = "右スティック：右上";
        }
        if (cm.RightStickRightDown())
        {
            text.text = "右スティック：右下";
        }
        if (cm.RightStickLeftUp())
        {
            text.text = "右スティック：左上";
        }
        if (cm.RightStickLeftDown())
        {
            text.text = "右スティック：左下";
        }

        angle.text = "atan2:" + atan.ToString();
    }
}