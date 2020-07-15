using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float stdSpeed = 30.0f;

    private Transform camTrans;

    // Start is called before the first frame update
    void Start()
    {
        camTrans = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Z方向速度決定
        float speed = stdSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= 1.5f;
        }
        //回転速度決定
        float rotSpeed=100.0f;

        Vector3 dirForward = new Vector3(camTrans.forward.x, 0.0f, camTrans.forward.z);
        dirForward.Normalize();
        Vector3 dirRight = new Vector3(camTrans.right.x, 0.0f, camTrans.right.z);
        dirForward.Normalize();

        

        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += Vector3.forward * Time.deltaTime * speed;
            //transform.position += dirForward * Time.deltaTime * speed;
            
            transform.Rotate(Vector3.left*Time.deltaTime* rotSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.position -= Vector3.forward * Time.deltaTime * speed;
            //transform.position -= dirForward * Time.deltaTime * speed;
            
            transform.Rotate(-Vector3.left * Time.deltaTime * rotSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += Vector3.left * Time.deltaTime * speed;
            //transform.position -= dirRight * Time.deltaTime * speed;
            
            transform.Rotate(-Vector3.up * Time.deltaTime * rotSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.position -= Vector3.left * Time.deltaTime * speed;
            //transform.position += dirRight * Time.deltaTime * speed;
            
            transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //transform.position += Vector3.up * Time.deltaTime * speed;
            //transform.position += camTrans.up * Time.deltaTime * speed;
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //transform.position -= Vector3.up * Time.deltaTime * speed;
            //transform.position -= camTrans.up * Time.deltaTime * speed;
        }

        

        transform.rotation.Normalize();

        //カメラの回転をそのままぶち込む
        //transform.rotation = camTrans.rotation;

    }
}
