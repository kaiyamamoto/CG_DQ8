//************************************************/
//* @file  :Hero.cs
//* @brief :ヤンガス用のスクリプト
//* @date  :2017/06/30
//* @author:K.Yamamoto
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;

public class Yangus : MonoBehaviour
{

    // アニメーションフラグのキー
    private const string ANIME_1 = "Action1";
    private const string ANIME_2 = "Action2";
    private const string ANIME_3 = "Action3";
    private const string ANIME_4 = "Action4";
    private const string ANIME_5 = "Action5";
    private const string ANIME_6 = "Action6";
    private const string ANIME_7 = "Action7";
    private const string ANIME_8 = "Action8";
    private const string ANIME_9 = "Action9";
    private const string ANIME_10 = "Action10";

    // アニメーター
    private Animator m_anime;

    // 自身の初期位置
    private Vector3 m_firstPos = new Vector3(0, 0, 0);

    // スライムの位置
    private Vector3 m_slime1Pos = new Vector3(12.07f, 0.0f, 5.65f);
    private Vector3 m_slime2Pos = new Vector3(4.4f, 0.0f, 4.6f);
    private Vector3 m_slime3Pos = new Vector3(-4.4f, 0.0f, 4.6f);

    // 棍棒
    [SerializeField]
    private GameObject m_sword;

    // ボーン
    [SerializeField]
    private GameObject m_born;

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start()
    {

        // 初期位置記録
        m_firstPos = transform.position;

        // アニメーター
        m_anime = GetComponent<Animator>();

        // アニメーション
    }

}
