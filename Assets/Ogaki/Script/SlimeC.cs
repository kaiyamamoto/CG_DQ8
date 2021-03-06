﻿//＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/
//! @file  :SlimeC.cs
//! @brief :スライムCのスクリプト
//! @date  : 2017 / 07 / 21
//! @author:T.Ogaki
//＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;

public class SlimeC : MonoBehaviour
{
    //アニメーションフラグのキー
    private const string ANIME_1 = "Action_01";

    //アニメーター
    public Animator m_anime;


    //スライムの位置
    private Vector3 m_slime1Pos = new Vector3(-4.8f, 0, 6.7f);

    // ノックバック
    private Vector3 _NockBack = new Vector3(-4.8f, 1.2f, 9.0f);


    void Start()
    {
        //アニメーター
        m_anime = GetComponent<Animator>();

        // スライムAの座標記録
        m_slime1Pos = transform.position;

        Animation ani = GetComponent<Animation>();

        /*--[アニメーションの制御]--*/

        // ８秒後アニメーション

        // ダメージ(1秒間)
        Observable.Timer(TimeSpan.FromSeconds(9.5f))
            .Subscribe(_ =>
            {
                // ジャンプ
                transform.DOLocalJump(_NockBack, 2, 2, 1);

                // 1.5秒かけて後ろへ回転
                transform.DORotate(new Vector3(-270, -180), 0.8f);

                // アニメーションを止める
                m_anime.speed = 0;

            });

		Observable.Timer(TimeSpan.FromSeconds(11.5f))
	.Subscribe(_ =>
	{
		Destroy(gameObject);
	});

	}
}
