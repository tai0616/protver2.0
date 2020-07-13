using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    static float leftStickHorizontal, leftStickVertical;
    static float rightStickHorizontal, rightStickVertical;
    static float crossHorizontal, crossVertical;

    float a;

    static float normLeftStickHorizontal, normLeftStickVertical;
    static float normRightStickHorizontal, normRightStickVertical;

    public void Update()
    {
        //左スティックの入力値を取得
        leftStickHorizontal = Input.GetAxis("LeftStickHorizontal");
        leftStickVertical = Input.GetAxis("LeftStickVertical");
        //左スティックの入力値を正規化
        a = Mathf.Sqrt((leftStickHorizontal * leftStickHorizontal) + (leftStickVertical * leftStickVertical));
        if (a > 0)
        {
            a = 1.0f / a;
        }
        normLeftStickHorizontal = leftStickHorizontal * a;
        normLeftStickVertical = leftStickVertical * a;

        //右スティックの入力値を取得
        rightStickHorizontal = Input.GetAxis("RightStickHorizontal");
        rightStickVertical = Input.GetAxis("RightStickVertical");
        //右スティックの入力値を正規化
        a = Mathf.Sqrt((rightStickHorizontal * rightStickHorizontal) + (rightStickVertical * rightStickVertical));
        if (a > 0)
        {
            a = 1.0f / a;
        }
        normRightStickHorizontal = rightStickHorizontal * a;
        normRightStickVertical = rightStickVertical * a;

        ////十字キーの入力値を取得
        //crossHorizontal = Input.GetAxis("CrossHorizontal");
        //crossVertical = Input.GetAxis("CrossHorizontal");
        ////十字キーの入力値を正規化
    }

    //左スティックを上に傾けている判定
    public bool LeftStickUp()
    {
        bool check = false;

        if (Mathf.Cos(67.5f) >= normLeftStickHorizontal && normLeftStickHorizontal > Mathf.Cos(112.5f))
        {
            if (normLeftStickVertical > 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを下に傾けている判定
    public bool LeftStickDown()
    {
        bool check = false;

        if (Mathf.Cos(67.5f) >= normLeftStickHorizontal && normLeftStickHorizontal > Mathf.Cos(112.5f))
        {
            if (normLeftStickVertical < 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを右に傾けている判定
    public bool LeftStickRight()
    {
        bool check = false;

        if (Mathf.Sin(-22.5f) <= normLeftStickVertical && normLeftStickVertical < Mathf.Sin(22.5f))
        {
            if (normLeftStickHorizontal > 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを左に傾けている判定
    public bool LeftStickLeft()
    {
        bool check = false;

        if (Mathf.Sin(-22.5f) <= normLeftStickVertical && normLeftStickVertical < Mathf.Sin(22.5f))
        {
            if (normLeftStickHorizontal < 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを右上に傾けている判定
    public bool LeftStickRightUp()
    {
        bool check = false;

        if (Mathf.Sin(22.5f) <= normLeftStickVertical && normLeftStickVertical < Mathf.Sin(67.5f))
        {
            if (normLeftStickHorizontal > 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを左上に傾けている判定
    public bool LeftStickLeftUp()
    {
        bool check = false;

        if (Mathf.Sin(22.5f) <= normLeftStickVertical && normLeftStickVertical < Mathf.Sin(67.5f))
        {
            if (normLeftStickHorizontal < 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを右下に傾けている判定
    public bool LeftStickRightDown()
    {
        bool check = false;

        if (Mathf.Sin(-67.5f) <= normLeftStickVertical && normLeftStickVertical < Mathf.Sin(-22.5f))
        {
            if (normLeftStickHorizontal > 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを左下に傾けている判定
    public bool LeftStickLeftDown()
    {
        bool check = false;

        if (Mathf.Sin(-67.5f) <= normLeftStickVertical && normLeftStickVertical < Mathf.Sin(-22.5f))
        {
            if (normLeftStickHorizontal < 0)
            {
                check = true;
            }
        }

        return check;
    }

    //右スティックを上に傾けている判定
    public bool RightStickUp()
    {
        bool check = false;

        if (Mathf.Cos(67.5f) <= normRightStickHorizontal && normRightStickHorizontal < Mathf.Cos(112.5f))
        {
            if (normRightStickVertical > 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを下に傾けている判定
    public bool RightStickDown()
    {
        bool check = false;

        if (Mathf.Cos(67.5f) <= normRightStickHorizontal && normRightStickHorizontal < Mathf.Cos(112.5f))
        {
            if (normRightStickVertical < 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを右に傾けている判定
    public bool RightStickRight()
    {
        bool check = false;

        if (Mathf.Sin(-22.5f) <= normRightStickVertical && normRightStickVertical < Mathf.Sin(22.5f))
        {
            if (normRightStickHorizontal > 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを左に傾けている判定
    public bool RightStickLeft()
    {
        bool check = false;

        if (Mathf.Sin(-22.5f) <= normRightStickVertical && normRightStickVertical < Mathf.Sin(22.5f))
        {
            if (normRightStickHorizontal < 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを右上に傾けている判定
    public bool RightStickRightUp()
    {
        bool check = false;

        if (Mathf.Sin(22.5f) <= normRightStickVertical && normRightStickVertical < Mathf.Sin(67.5f))
        {
            if (normRightStickHorizontal > 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを左上に傾けている判定
    public bool RightStickLeftUp()
    {
        bool check = false;

        if (Mathf.Sin(22.5f) <= normRightStickVertical && normRightStickVertical < Mathf.Sin(67.5f))
        {
            if (normRightStickHorizontal < 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを右下に傾けている判定
    public bool RightStickRightDown()
    {
        bool check = false;

        if (Mathf.Sin(-67.5f) <= normRightStickVertical && normRightStickVertical < Mathf.Sin(-22.5f))
        {
            if (normRightStickHorizontal > 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを左下に傾けている判定
    public bool RightStickLeftDown()
    {
        bool check = false;

        if (Mathf.Sin(-67.5f) <= normRightStickVertical && normRightStickVertical < Mathf.Sin(-22.5f))
        {
            if (normRightStickHorizontal < 0)
            {
                check = true;
            }
        }

        return check;
    }

    public float GetNormLeftStickHorizontal()
    {
        return normLeftStickHorizontal;
    }

    public float GetNormLeftStickVertical()
    {
        return normLeftStickVertical;
    }
}