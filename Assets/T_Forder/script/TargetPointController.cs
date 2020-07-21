using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointController : MonoBehaviour
{

    public GameObject player;
    public GameObject giantBeast;

    private CameraController cameraController;

    private float nonOperationTimer = 0.0f;
    private bool autoCameraFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        //カメラ操作コンポーネント取得
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        //**********************************************************
        //今のところ索敵モードのみ設定
        //**********************************************************


        //**********************************************************
        //ターゲットである自身のポジション設定
        //**********************************************************
        //無操作状態の検知
        if (Input.anyKey || Input.GetAxis("RightStickHorizontal") != 0 || Input.GetAxis("RightStickVertical") != 0)
        {
            if (autoCameraFlag)
            {
                nonOperationTimer = 0.0f;
                autoCameraFlag = false;
                Debug.Log("オートカメラモード　OFF!!");
                // cameraController.SetCameraMode(CameraController.CameraMode.Free);
            }
        }
        else//なんも押されてなかったら
        {
            nonOperationTimer += Time.deltaTime;
            if (!autoCameraFlag && nonOperationTimer >= 3.0f)
            {
                autoCameraFlag = true;
                Debug.Log("オートカメラモード　ON!!");
                //  cameraController.SetCameraMode(CameraController.CameraMode.FollowTarget);

            }
        }


        if (Input.GetButton("Maru"))
        {
            //索敵モードカメラワーク
            //巨獣とプレイヤーの間くらいを見る
            transform.position = (player.transform.position + giantBeast.transform.position) / 2;
        }
        else
        {
            //自由カメラ??
            transform.position = player.transform.position + player.transform.forward * 5.0f;

        }


        //**********************************************************
        //カメラの目線設定(eyeを設定)
        //**********************************************************
        //ターゲット方向からプレイヤーの後ろに直線的に設置
        //方向設定
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        //セット
        Vector3 eyePos;
        eyePos = player.transform.position + direction * 5.0f;
        eyePos += Vector3.up * 3.0f;
        cameraController.SetEyePosition(eyePos);
    }
}
