//************************************************/
//* @file  :Hero.cs
//* @brief :主人公用のスクリプト
//* @date  :2017/06/30
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;

public class Hero : MonoBehaviour {

    //アニメーションフラグのキー
    private const string ANIME_1  = "Action1";
    private const string ANIME_2  = "Action2";
    private const string ANIME_3  = "Action3";
    private const string ANIME_4  = "Action4";
    private const string ANIME_5  = "Action5";
    private const string ANIME_6  = "Action6";
    private const string ANIME_7  = "Action7";
    private const string ANIME_8  = "Action8";
    private const string ANIME_9  = "Action9";
    private const string ANIME_10 = "Action10";

    //アニメーター
    private Animator m_anime;

    //自身の初期位置
    private Vector3 m_firstPos = new Vector3(0, 0, 0);

    //スライムの位置
    private Vector3 m_slime1Pos = new Vector3(12.57f, 0.0f, 5.15f);
    private Vector3 m_slime2Pos = new Vector3(4.4f, 0.0f, 4.6f);
    private Vector3 m_slime3Pos = new Vector3(-4.4f, 0.0f, 4.6f);

    //剣　切り離す用
    [SerializeField]
    private GameObject m_sword;

    //剣　付ける用
    [SerializeField]
    private GameObject m_born;

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start () {

        //初期位置を記録
        m_firstPos = transform.position;

        //アニメーター
        m_anime = GetComponent<Animator>();


        /*--[アニメーションの制御]--*/

        float time1 = 8.0f;
        float time2 = time1 + 1.0f;
        float time3 = time2 + 1.0f;
        float time4 = time3 + 1.0f;
        float time5 = time4 + 11.0f;
        float time6 = time5 + 1.0f;
        float time7 = time6 + 1.0f;
        float time8 = time7 + 1.0f;
        float time9 = time8 + 3.0f;
        float time10 = time9 + 1.3f;

        //１～７秒は立ってる

        //前方ジャンプ１秒
        Observable.Timer(TimeSpan.FromSeconds(time1))
            .Subscribe(_ => {
                m_anime.SetTrigger(ANIME_1);
                transform.DOMove(m_slime3Pos, 1);
                transform.DORotateQuaternion(Quaternion.LookRotation(m_slime3Pos - m_firstPos), 1);
            });

        //攻撃１秒
        Observable.Timer(TimeSpan.FromSeconds(time2))
            .Subscribe(_ =>    {
                m_anime.SetTrigger(ANIME_2);
            });

        //後方ジャンプ１秒
        Observable.Timer(TimeSpan.FromSeconds(time3))
            .Subscribe(_ =>   {
                m_anime.SetTrigger(ANIME_3);
                transform.DOMove(m_firstPos, 0.8f);
                transform.DORotate(new Vector3(0,0,0),0.8f);
            });



        //立ってる11秒
        Observable.Timer(TimeSpan.FromSeconds(time4))
            .Subscribe(_ =>   {
                m_anime.SetTrigger(ANIME_4);
            });



        //前方移動１秒
        Observable.Timer(TimeSpan.FromSeconds(time5))
            .Subscribe(_ =>   {
                m_anime.SetTrigger(ANIME_5);
                transform.DOMove(m_slime1Pos, 1);
                transform.rotation = Quaternion.LookRotation(m_slime1Pos - m_firstPos);
            });

        //攻撃１秒
        Observable.Timer(TimeSpan.FromSeconds(time6))
            .Subscribe(_ =>   {
                m_anime.SetTrigger(ANIME_6);
            });

        //後方ジャンプ１秒
        Observable.Timer(TimeSpan.FromSeconds(time7))
            .Subscribe(_ =>   {
                m_anime.SetTrigger(ANIME_7);
                transform.DOMove(m_firstPos, 0.4f).SetEase(Ease.OutSine);
                transform.DORotate(new Vector3(0, 0, 0), 0.4f);
            });



        //立ってる３秒
        Observable.Timer(TimeSpan.FromSeconds(time8))
            .Subscribe(_ =>   {
                m_anime.SetTrigger(ANIME_8);
            });

        //武器しまう1.5秒
        Observable.Timer(TimeSpan.FromSeconds(time9))
            .Subscribe(_ =>   {
                //アニメーションでずれる位置の調整
                transform.DOLocalMoveZ(m_firstPos .z - 0.35f, 1.5f);

                m_anime.SetTrigger(ANIME_9);
            });

        //武器しまい終わり1.5秒
        Observable.Timer(TimeSpan.FromSeconds(time10))
            .Subscribe(_ => {
                //アニメーションでずれる位置の調整
                transform.DOLocalMoveZ(m_firstPos.z, 1.5f);

                //剣を切り離して、背中に着ける
                m_sword.transform.parent = m_born.transform;
                m_anime.SetTrigger(ANIME_10);
            });
    }

}
