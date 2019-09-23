using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State
    {
        enBattleOn,
        enBattleOff,

    }
    int m_hp = 10;
    public float speed = 5.0f;
    public GameObject m_popItem;
    Rigidbody rigidbody;
    GameObject player;
    public float m_speed = 0.0f;
    Animator m_animator;
    List<string> m_hitObjects = new List<string>();
    public GameObject m_attackCollider;
    float m_attackJudgeTime = 0.0f;
    public float m_battleBorder = 0.0f;
    State m_state = State.enBattleOff;
    public float m_attackIntervalTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();

        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            Damage(3);
        }
        switch(m_state)
        {
            case State.enBattleOn:
                Battle();
                break;
            case State.enBattleOff:
                Move();
                break;
        }
        Debug.Log(m_state);

        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0.0f;
        direction.Normalize();
        transform.rotation = Quaternion.LookRotation(direction);

        m_animator.SetFloat("moveSpeed", rigidbody.velocity.sqrMagnitude);
    }

    void Battle()
    {
        m_attackIntervalTimer += Time.deltaTime;
        if(5.0f < m_attackIntervalTimer)
        {
            m_attackIntervalTimer = 0.0f;
            m_animator.Play("Attack");
        }
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0.0f;
        if ( m_battleBorder < direction.sqrMagnitude)
        {
            m_state = State.enBattleOff;
        }

    }


    public void AttackJudgeOff()
    {
        m_attackCollider.SetActive(false);
        m_hitObjects.Clear();

    }

    public void AttackTimeUpdate()
    {
        if (0.0f < m_attackJudgeTime)
        {
            m_attackJudgeTime -= Time.deltaTime;
            if (m_attackJudgeTime < 0.0f)
            {
                AttackJudgeOff();
            }
        }
    }

    void Move()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0.0f;
        if (direction.sqrMagnitude < m_battleBorder)
        {
            m_state = State.enBattleOn;
            m_animator.Play("Idle");
            rigidbody.velocity = Vector3.zero;
            return;
        }
        m_animator.SetFloat("distance", direction.magnitude);
        direction.Normalize();
        float moveY = rigidbody.velocity.y;
        direction *= m_speed;
        direction.y = moveY;
        rigidbody.velocity = direction;
    }

    public void Death()
    {
        GameObject gameObj = Instantiate(m_popItem);
        gameObj.transform.position = transform.position;
        Destroy(gameObject);
    }

    public void Damage(int damage)
    {
        m_hp -= damage;
        if(m_hp <= 0)
        {
            m_animator.Play("Death");
        }
        else
        {
            m_animator.Play("Damage");

        }
    }
    void AttackStart(float attackJudgeTime)
    {
        m_attackCollider.SetActive(true);
        m_attackJudgeTime = attackJudgeTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            bool isHit = true;
            string name = other.gameObject.name;
            foreach (string hitObject in m_hitObjects)
            {
                if (hitObject == name)
                {
                    isHit = false;
                    break;
                }
            }
            if (isHit)
            {
                m_hitObjects.Add(name);
            }
        }
    }
}
