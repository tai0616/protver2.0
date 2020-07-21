using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**********************************************************
//メモ：Cameraコンポーネントがついているオブジェクトにつけて下さい
//**********************************************************

public class CameraController : MonoBehaviour
{
    public GameObject targetPoint;  //目標オブジェクト
    public float speed = 0.01f;      //補間スピード

    private Vector3 eyePos;

    private float rotSpeed = 30.0f;

    public enum CameraMode
    {
        FollowTarget,
        Free
    }

    CameraMode cameraMode = CameraMode.FollowTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (cameraMode)
        {
            case CameraMode.FollowTarget:
                //==================================================
                //ターゲット方向へ向く
                //==================================================
                // ターゲット方向のベクトルを取得
                Vector3 targetPosition = targetPoint.transform.position - this.transform.position;
                // 方向を、回転情報に変換
                Quaternion targetRotation = Quaternion.LookRotation(targetPosition);
                // 現在の回転情報と、ターゲット方向の回転情報を補完する
                transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, speed);
                break;

            case CameraMode.Free:
                transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("RightStickHorizontal"));
                transform.Rotate(-Vector3.right * Time.deltaTime * rotSpeed * Input.GetAxis("RightStickVertical"));

                
                break;
        }
        //==================================================
        //カメラの位置を設定
        //==================================================
        transform.position = Vector3.Lerp(this.transform.position, eyePos, 0.01f);

       

    }



    public void SetEyePosition(Vector3 _eyePos)
    {
        //距離を
        //Vector3 work = _eyePos - eyePos;
        //float distance = work.magnitude;
        eyePos = _eyePos;
    }

    public void SetCameraMode(CameraMode _mode)
    {
        cameraMode = _mode;
    }

}
