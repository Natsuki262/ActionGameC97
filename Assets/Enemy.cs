using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int m_hp = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Damage(3);
        }
    }
    
    void Damage(int damage)
    {
        m_hp -= damage;
        if(m_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
