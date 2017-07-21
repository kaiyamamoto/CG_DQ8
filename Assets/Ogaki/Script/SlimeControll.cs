//!＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/
//! @file  :SlimeControll.cs
//!
//! @brief :スライム用のスクリプト
//!
//! @date  :2017/07/07
//!
//! @author:T.Ogaki
//!＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;

public class SlimeControll : MonoBehaviour
{
    private Animator animator;

    // アニメーションフラグのキー
    private const string ANIME_1 = "Damage_01";
    private const string ANIME_2 = "Jump 1";
    private const string ANIME_3 = "Action3";
    private const string ANIME_4 = "Action4";
    private const string ANIME_5 = "Action5";
    private const string ANIME_6 = "Action6";
    private const string ANIME_7 = "Action7";
    private const string ANIME_8 = "Action8";
    private const string ANIME_9 = "Action9";
    private const string ANIME_10 = "Action10";


    // スライムの位置
    private Vector3 m_slime1Pos = new Vector3(12.07f, 0.0f, 5.65f);
    private Vector3 m_slime2Pos = new Vector3(4.4f, 0.0f, 4.6f);
    private Vector3 m_slime3Pos = new Vector3(-4.4f, 0.0f, 4.6f);


    void Start()
    {
        animator = GetComponent<Animator>();

        //  ジャンプモーション
        Observable.Timer(TimeSpan.FromSeconds(5))
            .Subscribe(_ => {
                animator.SetTrigger(ANIME_2);
                Debug.Log("ジャンプ");
            });

        // ダメージモーション
        Observable.Timer(TimeSpan.FromSeconds(10))
            .Subscribe(_ => {
                animator.SetTrigger(ANIME_1);
                Debug.Log("ダメージ");
            });


    }

}
