using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int m_hp = 10;
    public float speed = 5.0f;
    public GameObject m_popItem;
    Rigidbody rigidbody;
    GameObject player;
    public float m_speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            Damage(3);
        }
        Move();
    }

    void Move()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0.0f;
        direction.Normalize();
        transform.rotation = Quaternion.LookRotation(direction);
        Debug.Log(transform.rotation);
        float moveY = rigidbody.velocity.y;
        direction *= m_speed;
        direction.y = moveY;
        rigidbody.velocity = direction;

    }

    public void Damage(int damage)
    {
        m_hp -= damage;
        if(m_hp <= 0)
        {
            GameObject gameObj = Instantiate(m_popItem);
            gameObj.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
