using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]
    private float Speed;
    private float x;//x方向のInput値
    private float z;//z方向のInput値
    private float y;
    private Vector3 Player_pos;
    bool Ground = true;
    [SerializeField]
    float JunpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Player_pos = GetComponent<Transform>().position;//プレイヤーポジション取得
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }   
    private void FixedUpdate()
    {
         x = Input.GetAxis("Horizontal") * Speed;
         z = Input.GetAxis("Vertical") * Speed;
        rb.AddForce(x, y, z);
        //rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Vector3 diff = transform.position - Player_pos;

        if(diff.magnitude>0.01f)//回転処理
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
        Player_pos = transform.position;

        //if (Ground)
        //{
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("エレガント");
                rb.AddForce(Vector3.up *JunpSpeed );
                Ground = false;
            }
       // }
        void OnTrigger(Collider col)
        {
            if (col.gameObject.tag == "Ground")
            {
                if (!Ground)
                {
                    Ground = true;
                }
            }
        }

        
    }
}