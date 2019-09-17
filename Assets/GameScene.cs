using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    GameTimer m_gameTimer;
    // Start is called before the first frame update
    void Start()
    {
        m_gameTimer = GetComponent<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_gameTimer.m_isTimeUp)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
