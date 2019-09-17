using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float m_timer = 300.0f;
    public bool m_isTimeUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timer -= Time.deltaTime;
        if(m_timer < 0.0f)
        {
            m_timer = 0.0f;
            m_isTimeUp = true;
        }
    }
}
