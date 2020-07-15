using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleController : MonoBehaviour
{
    public float HP;
    public float STM;

    [SerializeField] private Transform catslePos;
    /// <summary>
    /// レイの当たり判定
    /// </summary>
    Ray ray;
    RaycastHit hit;            //Rayが当たったオブジェクトの情報を入れる箱
    [SerializeField] private float ray_distance;
    [SerializeField] private Transform ray_startpos;


    /// <summary>
    /// 巨獣の動くスピード関連
    /// </summary>
    Rigidbody KyojyuuRb;
    [SerializeField] private float frontSpeed = 1;
    [SerializeField] private float sidePower = 1;
    [SerializeField] private bool movenow = false;

    private float hogetime;//避ける時の時間計算に必要
    private int rlRandom = 0;//岩山を避ける時にどっちに避けるか
    public float sMoveTime;//横に移動する秒数

    public float wPattern = 1;//体のフックのパターン

    //巨獣の抵抗
    private float resisTime;
    private bool resisNow = false;
    private void Start()
    {
        KyojyuuRb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        //巨獣の移動
        this.transform.LookAt(catslePos);
        KyojyuuRb.velocity = (catslePos.position.normalized - transform.position.normalized) * frontSpeed;

        //float step = frontSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, catslePos.position, step);

        ///////////////レイで岩山を判断///////////////
        ray = new Ray(ray_startpos.transform.position, transform.TransformDirection(new Vector3(0, 0, ray_distance)));

        //レイを可視化
        Debug.DrawRay(ray_startpos.transform.position, transform.TransformDirection(new Vector3(0, 0, ray_distance)), Color.yellow);

        //岩山を自動で避ける時
        if (Physics.Raycast(ray, out hit, ray_distance))//Rayの当たり判定
        {
            //Rayが当たったオブジェクトのtagがPlayerだったら
            if (hit.collider.tag == "RockMountain" && movenow == false)
            {
                movenow = true;
                rlRandom = Random.Range(0,1);
                KyojyuuRb.velocity = Vector3.zero;
                hogetime = 0;
                //KyojyuuRb.angularVelocity = Vector3.zero;
            }
        }

        //横に移動処理
        if (movenow == true)//横に移動中
        {
            hogetime += Time.deltaTime;

            //巨獣の動き
            if (rlRandom == 0)//右に移動
            {
                //KyojyuuRb.AddForce(sidePower, 0, 0);
                KyojyuuRb.AddForce(sidePower, 0, 0, ForceMode.Impulse);

                if (hogetime >= sMoveTime)//移動終わったら
                {
                    movenow = false;
                }

                Debug.Log(hogetime);
            }
            else//左に移動
            {
                //KyojyuuRb.AddForce(-sidePower, 0, 0);
                KyojyuuRb.AddForce(sidePower, 0, 0, ForceMode.Impulse);

                if (hogetime >= sMoveTime)//移動終わったら
                {
                    movenow = false;
                }
                Debug.Log(hogetime);
            }
        }


        //if (KenjakuMode == true)
        //{
        //    resisTime += Time.deltaTime;

        //    if (resisTime >= 5 && resisNow == false)//抵抗中
        //    {
        //        resisNow = true;

        //        if (resisTime >= 10)//抵抗終わり
        //        {
        //            resisNow = false;
        //        }
        //    }


        //    if (PullMode == true && resisNow == false)
        //    {
        //        STM -= 0.3f;
        //    }
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RockMountain")
        {
            if (wPattern == 1)
            {
                transform.Find("HookP2").gameObject.SetActive(true);
                transform.Find("HookP1").gameObject.SetActive(false);
                Destroy(collision.gameObject);
                wPattern++;
            }
            else if (wPattern == 2)
            {
                transform.Find("HookP3").gameObject.SetActive(true);
                transform.Find("HookP2").gameObject.SetActive(false);
                Destroy(collision.gameObject);
                wPattern++;
            }
            else if (wPattern == 3)
            {
                transform.Find("HookP1").gameObject.SetActive(true);
                transform.Find("HookP3").gameObject.SetActive(false);
                Destroy(collision.gameObject);
                wPattern = 1;
            }
        }
    }
}
