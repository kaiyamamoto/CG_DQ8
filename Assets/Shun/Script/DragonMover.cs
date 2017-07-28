//************************************************/
//* @file  :DragonMover.cs
//* @brief :ドラゴンの移動用のスクリプト
//* @date  :2017/07/28
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;

public class DragonMover : MonoBehaviour {

	[SerializeField]
	private Transform[] m_target = new Transform[5];


	private float m_moveTime = 8.0f;

	void Start()
	{
		transform.DOMove(m_target[0].position, m_moveTime);
		transform.DORotateQuaternion(Quaternion.LookRotation(m_target[0].position - transform.position), 1);

		Observable.Timer(TimeSpan.FromSeconds(m_moveTime))
			.Subscribe(_ => {
				transform.DOMove(m_target[1].position, m_moveTime);
				transform.DORotateQuaternion(Quaternion.LookRotation(m_target[1].position - transform.position), 1);
			});

		Observable.Timer(TimeSpan.FromSeconds(m_moveTime*2))
			.Subscribe(_ => {
				transform.DOMove(m_target[2].position, m_moveTime);
				transform.DORotateQuaternion(Quaternion.LookRotation(m_target[2].position - transform.position), 1);
			});

		Observable.Timer(TimeSpan.FromSeconds(m_moveTime * 3))
			.Subscribe(_ =>
			{
				transform.DOMove(m_target[3].position, m_moveTime);
				transform.DORotateQuaternion(Quaternion.LookRotation(m_target[3].position - transform.position), 1);
			});

		Observable.Timer(TimeSpan.FromSeconds(m_moveTime * 4))
			.Subscribe(_ => {
				transform.DOMove(m_target[4].position, m_moveTime);
				transform.DORotateQuaternion(Quaternion.LookRotation(m_target[4].position - transform.position), 1);
			});
	}
}
