using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float Speed;
    private float x;//x方向のInput値
    private float z;//z方向のInput値
    private float y;
    private Vector3 Player_pos;
    bool Ground = true;
    [SerializeField]
    private float JunpSpeed;

    public GameObject targetObject;

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
            //Debug.Log(y);
        x = Input.GetAxis("Horizontal") * Speed;
        z = Input.GetAxis("Vertical") * Speed;
        //Debug.Log(y);
        rb.AddForce(x, 0, z);
        //rb.velocity = Vector3.zero;
        //rb.angularVelocity = Vector3.zero;

        //this.transform.LookAt(targetObject.transform);
        
        Vector3 diff = transform.position - Player_pos;
        diff.y = 0;
        //Player_pos = transform.position;
        //Debug.Log(diff);
            Debug.Log(diff+"a");
        if (diff.magnitude > 0.01f)//回転処理
        {
            Debug.Log(diff+"b");


            transform.rotation = Quaternion.LookRotation(diff);
            //transform.rotationy= 0;
            Debug.Log(diff+"c");



            /*Debug.Log(x);
            Debug.Log(z);
           Debug.Log(transform.rotation);*/
        }
        Debug.Log(diff+"d");


        Player_pos = transform.position;
        Debug.Log(diff+"e");

        Ray ray = new Ray(transform.position, Vector3.down);
        {
            //接地判定
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 0.5f))//Rayの大きさ
            {
                // Debug.DrawRay(transform.position, Vector3.down , Color.green);
                //Debug.DrawRay(transform.position, Vector3.down);
                //Debug.Log(hit.collider);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Debug.Log("エレガント");
                    rb.AddForce(transform.up * JunpSpeed);
                    // Debug.Log(JunpSpeed);
                }

            }

        }
    }
    /* void OnCollsionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "Ground")
         {
             Debug.Log("Hit");
             Debug.Log(collision.gameObject.name);
         }
     }*/
}




