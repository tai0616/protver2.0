using UnityEngine;
using System.Collections;

public class CursorShot : MonoBehaviour
{

    //　カーソルに使用するテクスチャ
    [SerializeField]
    private Texture2D cursor;
    [SerializeField]
    private GameObject kenjyaku;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private GameObject Target;


    private float extend = 1f;
    private bool extendFrag = false;

    void Start()
    {
        //　カーソルを自前のカーソルに変更
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2.0f, cursor.height / 2.0f), CursorMode.ForceSoftware);
        //カーソルをウィンドウ内に
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //　マウスの左クリックで撃つ
        if (Input.GetButtonDown("R2"))
        {
            Shot();
        }

       // Ray ray = Camera.main.ScreenPointToRay(new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z));

        //伸びてる途中
        if (extendFrag)
        {
            kenjyaku.transform.LookAt(Target.transform);

            // y軸を軸にして5度、x軸を軸にして5度、回転させるQuaternionを作成（変数をrotとする）
            Quaternion rot = Quaternion.Euler(90f, 0, 0);
            // 現在の自信の回転の情報を取得する。
            Quaternion q = kenjyaku.transform.rotation;
            // 合成して、自身に設定
            kenjyaku.transform.rotation = q * rot;

            extend += 15.0f * Time.deltaTime;

            if (extend > 50f)
            {
                extendFrag = false;
                extend = 0.2f;
            }

            kenjyaku.transform.localScale = new Vector3(0.2f, extend, 0.2f);
            
        }
        else  //伸びてないとき
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            kenjyaku.transform.rotation = Quaternion.LookRotation(ray.direction);


            // y軸を軸にして5度、x軸を軸にして5度、回転させるQuaternionを作成（変数をrotとする）
            Quaternion rot = Quaternion.Euler(90f, 0, 0);
            // 現在の自信の回転の情報を取得する。
            Quaternion q = kenjyaku.transform.rotation;
            // 合成して、自身に設定
            kenjyaku.transform.rotation = q * rot;
        }
    }

    //　敵を撃つ
    void Shot()
    {

        //Ray ray = Camera.main.ScreenPointToRay();

        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy")))
        {
            // Destroy(hit.collider.gameObject);
            Target = hit.collider.gameObject;
            //岩に当たってないと伸びません
            extendFrag = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
        {

        }
    }
}