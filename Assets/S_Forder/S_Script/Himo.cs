using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Himo : MonoBehaviour
{
    [SerializeField] private GameObject Base;       // SpringJointコンポーネントを追加する方：今回の場合は鯨

    [SerializeField] private float spring;  // 引っ張る力：要調整
    [SerializeField] private float damper;  // 引っ張りを抑制する：要調整

    [SerializeField] private float decay;   // 引っ張る力の減衰地：使わない

    static RaycastHit hitObj;

    //static int frameCnt;

    static bool flg;    // ケンジャクがヒットしたらの代わり

    // Start is called before the first frame update
    void Start()
    {
        //frameCnt = 0;
        flg = false;
    }

    // Update is called once per frame
    void Update()
    {
        //frameCnt++;

        if (Input.GetButtonDown("Maru"))
        {
            flg = RayCheck();
        }
        if (Input.GetButtonDown("Batu"))
        {
            flg = false;
        }

        if (flg)
        {
            if (Input.GetButtonDown("R1"))
            {
                if (Base.GetComponent<SpringJoint>() == null)   // flgがtrueかつSpringJointがなければ追加
                {
                    SpringJoint baseJoint = Base.AddComponent<SpringJoint>();   // 追加
                    baseJoint.connectedBody = hitObj.rigidbody;                 // Rayが当たったTargetをセット
                    // SpringJointの各種設定
                    baseJoint.anchor = new Vector3(0, 0, 0);
                    baseJoint.autoConfigureConnectedAnchor = false;     // 必ずfalse
                    baseJoint.connectedAnchor = new Vector3(0, 0, 0);
                    baseJoint.spring = spring;
                    baseJoint.damper = damper;
                    baseJoint.enableCollision = true;                   // 必ずtrue
                }
                //else
                //{
                //    spring += 0.05f;     // コンポーネントが存在するとき連打で引っ張る力が強くなるサンプル
                //}
            }
            //else
            //{
            //    if(frameCnt%60==0&& Base.GetComponent<SpringJoint>() != null)   // 60frame毎、SpringJointあれば
            //    {
            //        spring -= decay;     // コンポーネントが存在するとき操作しないと引っ張る力が減少する
            //        if (spring < 0)
            //        {
            //            spring = 0;     // 0が最小値
            //            flg = false;    // かけ引き負け
            //        }
            //    }
            //}
        }
        else
        {
            if (Base.GetComponent<SpringJoint>() != null)   // コンポーネントがあるかどうか
            {
                Destroy(Base.GetComponent<SpringJoint>());  // 削除
            }
        }

        //if (Base.GetComponent<SpringJoint>() != null)   // コンポーネントがあるかどうか
        //{
        //    SpringJoint baseJoint = Base.GetComponent<SpringJoint>();
        //    // 引っ張る強さ：抑制のアップデート
        //    baseJoint.spring = spring;
        //    baseJoint.damper = damper;
        //}
    }

    bool RayCheck()
    {
        Vector3 origin = GameObject.Find("Icon").transform.position;
        Vector3 camera = GameObject.Find("Main Camera").transform.position;
        // カメラからアイコンに向くベクトルの算出：それをRayを飛ばす方向とする
        Vector3 direction;
        direction.x = origin.x - camera.x;
        direction.y = origin.y - camera.y;
        direction.z = origin.z - camera.z;
        if (Physics.Raycast(origin, direction, out hitObj, Mathf.Infinity))
        {
            if (hitObj.collider.tag == "Target")
            {
                Debug.Log("RayがTargetに衝突");
                return true;
            }
        }

        return false;
    }
}
