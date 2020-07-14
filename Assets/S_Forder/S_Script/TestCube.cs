using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float x;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("LeftStickHorizontal");
        z = Input.GetAxis("LeftStickVertical");

        if (Input.GetButtonDown("Maru"))
        {
            rb.velocity += new Vector3(0, 10, 0);
        }

        rb.velocity += new Vector3(x, 0, z);
    }
}
