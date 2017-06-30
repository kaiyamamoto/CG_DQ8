//************************************************/
//* @file  :Hero.cs
//* @brief :主人公用のスクリプト
//* @date  :2017/06/23
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;

public class Yangus : MonoBehaviour
{

    //アニメーションフラグのキー
    private const string ANIME_1 = "Action1";
    //private const string ANIME_2 = "Action2";
    //private const string ANIME_3 = "Action3";
    //private const string ANIME_4 = "Action4";
    //private const string ANIME_5 = "Action5";
    //private const string ANIME_6 = "Action6";
    //private const string ANIME_7 = "Action7";
    //private const string ANIME_8 = "Action8";
    //private const string ANIME_9 = "Action9";
    //private const string ANIME_10 = "Action10";

    //アニメーター
    private Animator m_anime;

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start()
    {

        //アニメーター
        m_anime = GetComponent<Animator>();

        //アニメーションの制御
        Observable.Timer(TimeSpan.FromSeconds(2)).Subscribe(_ => { m_anime.SetBool(ANIME_1, true); });
        //Observable.Timer(TimeSpan.FromSeconds(4)).Subscribe(_ => { m_anime.SetTrigger(ANIME_2); });
        //Observable.Timer(TimeSpan.FromSeconds(6)).Subscribe(_ => { m_anime.SetTrigger(ANIME_3); });
        //Observable.Timer(TimeSpan.FromSeconds(8)).Subscribe(_ => { m_anime.SetTrigger(ANIME_4); });
        //Observable.Timer(TimeSpan.FromSeconds(10)).Subscribe(_ => { m_anime.SetTrigger(ANIME_5); });
        //Observable.Timer(TimeSpan.FromSeconds(12)).Subscribe(_ => { m_anime.SetTrigger(ANIME_6); });
        //Observable.Timer(TimeSpan.FromSeconds(14)).Subscribe(_ => { m_anime.SetTrigger(ANIME_7); });
        //Observable.Timer(TimeSpan.FromSeconds(16)).Subscribe(_ => { m_anime.SetTrigger(ANIME_8); });
        //Observable.Timer(TimeSpan.FromSeconds(18)).Subscribe(_ => { m_anime.SetTrigger(ANIME_9); });
        //Observable.Timer(TimeSpan.FromSeconds(20)).Subscribe(_ => { m_anime.SetTrigger(ANIME_10); });
    }

}
