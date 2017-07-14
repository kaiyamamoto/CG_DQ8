//************************************************/
//* @file  :Yangus.cs
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
    //アニメーションフラグのキー
    private const string IDLE = "IDLE";
    private const string JUMP = "JUMP";
    private const string ATTACK = "ATTACK";
    private const string BACKJUMP = "BACKJUMP";
    private const string END = "END";
    private const string ENDIDLE = "ENDIDLE";
 
    // アニメーター
    private Animator m_anime;

    // 自身の初期位置
    private Vector3 m_firstPos = new Vector3(0, 0, 0);

    // スライムの位置
    private Vector3 m_slime1Pos = new Vector3(12.07f, 0.0f, 5.65f);
    private Vector3 m_slime2Pos = new Vector3(4.4f, 0.0f, 4.6f);
    private Vector3 m_slime3Pos = new Vector3(-4.4f, 0.0f, 4.6f);

    //棍棒
    [SerializeField]
    private GameObject m_club;

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

        Sequence jump = DOTween.Sequence()
            .Append(transform.DOMoveY(5, 0.25f))
            .Append(transform.DOMoveY(0, 0.25f))
            .SetAutoKill(false);
        jump.Complete();

        /*--[アニメーションの制御]--*/

        //１～12秒は立ってる

        //前方ジャンプ１秒
        Observable.Timer(TimeSpan.FromSeconds(13))
            .Subscribe(_ => {
                m_anime.SetTrigger(JUMP);
                transform.DOMoveX(m_slime2Pos.x, 1);
                transform.DOMoveZ(m_slime2Pos.z, 1);
                transform.DORotateQuaternion(Quaternion.LookRotation(m_slime2Pos - m_firstPos), 1);
                jump.Restart();
            });
        // ジャンプ
        Observable.Timer(TimeSpan.FromSeconds(13.5f))
            .Subscribe(_ => {
                m_anime.SetTrigger(JUMP);
                jump.Restart();
            });

        //攻撃１秒
        Observable.Timer(TimeSpan.FromSeconds(14))
            .Subscribe(_ => {
                m_anime.SetTrigger(ATTACK);
            });

        //後方ジャンプ１秒
        Observable.Timer(TimeSpan.FromSeconds(14.5f))
            .Subscribe(_ => {
                m_anime.SetTrigger(BACKJUMP);
                transform.DOMove(m_firstPos, 0.8f);
                transform.DORotate(new Vector3(0, 0, 0), 0.8f);
            });



        //立ってる9秒
        Observable.Timer(TimeSpan.FromSeconds(15.5f))
            .Subscribe(_ => {
                m_anime.SetTrigger(IDLE);
            });



        //前方移動１秒
        Observable.Timer(TimeSpan.FromSeconds(25))
            .Subscribe(_ =>
            {
                m_anime.SetTrigger(JUMP);
                transform.DOMoveX(m_slime1Pos.x, 1);
                transform.DOMoveZ(m_slime1Pos.z, 1);
                transform.rotation = Quaternion.LookRotation(m_slime1Pos - m_firstPos);
                jump.Restart();
            });
        Observable.Timer(TimeSpan.FromSeconds(25.5f))
            .Subscribe(_ =>
            {
                m_anime.SetTrigger(JUMP);
                jump.Restart();
            });

        //攻撃１秒
        Observable.Timer(TimeSpan.FromSeconds(26))
            .Subscribe(_ => {
                m_anime.SetTrigger(ATTACK);
            });

        //後方ジャンプ１秒
        Observable.Timer(TimeSpan.FromSeconds(27))
            .Subscribe(_ => {
                m_anime.SetTrigger(BACKJUMP);
                transform.DOMove(m_firstPos, 0.8f).SetEase(Ease.OutSine);
                transform.DORotate(new Vector3(0, 0, 0), 0.8f);
                jump.Kill();
            });


        //武器しまう1.5秒
        Observable.Timer(TimeSpan.FromSeconds(28))
            .Subscribe(_ => {
                m_anime.SetTrigger(END);
            });

        //武器しまい終わり1.5秒
        Observable.Timer(TimeSpan.FromSeconds(29.5f))
            .Subscribe(_ =>
            {
                //剣を切り離して、背中に着ける
                m_anime.SetTrigger(ENDIDLE);
            });
        Observable.Timer(TimeSpan.FromSeconds(30))
              .Subscribe(_ =>
            {
                //剣を切り離して、背中に着ける
                m_club.transform.parent = m_born.transform;
            });
    }
}
