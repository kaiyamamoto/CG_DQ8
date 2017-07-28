//************************************************/
//* @file  :Ikazuchi.cs
//* @brief :雷の移動用のスクリプト
//* @date  :2017/07/21
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using UniRx;
using UniRx.Triggers;

public class IkazuchiMover : MonoBehaviour {

    [SerializeField]
    private Transform[] m_target;

    private NavMeshAgent m_agent;

    private int m_nextTarget = 0;

    // Use this for initialization
    void Start () {
        m_agent = GetComponent<NavMeshAgent>();

        //最初の目的地
        m_agent.destination = m_target[m_nextTarget].position;
        m_nextTarget++;

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                if (Vector3.Distance(transform.position, m_agent.destination) < 0.1f)
                {
                    m_agent.destination = (m_target[m_nextTarget].position);
                    m_nextTarget++;

                    if (m_nextTarget >= m_target.Length)
                    {
                        m_nextTarget = 0;
                    }
                }
            });
    }

}
