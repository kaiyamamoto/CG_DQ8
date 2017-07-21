//＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/
//! @file  :SlimeA.cs
//! @brief :スライムAのスクリプト
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

public class SlimeA : MonoBehaviour
{
    //アニメーションフラグのキー
    private const string ANIME_1 = "Action_01";

    //アニメーター
    private Animator m_anime;

    //スライムの位置
    private Vector3 m_slime1Pos = new Vector3(12.57f, 0.0f, 5.15f);


    void Start()
    {
        // スライムAの座標記録
        m_slime1Pos = transform.position;

        //アニメーター
        m_anime = GetComponent<Animator>();

        /*--[アニメーションの制御]--*/

        // １～７秒は立ってる

        // ダメージ１秒
        Observable.Timer(TimeSpan.FromSeconds(9))
            .Subscribe(_ =>
            {
                //transform.DOMove(Vector3(13.4f, 0, 0), 1);
                m_anime.SetTrigger(ANIME_1);
                Debug.Log("アニメーション");
            });

    }

    void Update()
    {

    }
}
