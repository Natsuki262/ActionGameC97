using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int m_hp = 10;

    public GameObject m_popItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            Damage(3);
        }
    }
    
    void Damage(int damage)
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
