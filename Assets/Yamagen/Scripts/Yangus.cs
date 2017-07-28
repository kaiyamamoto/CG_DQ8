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
    private Vector3 m_target1Pos;
    private Vector3 m_target2Pos;

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

        m_target1Pos = new Vector3(5.6f, 0.0f, 5.0f);
        m_target2Pos = new Vector3(13.07f, 0.0f, 4.8f);

        // アニメーター
        m_anime = GetComponent<Animator>();

        float y = transform.position.y;
        Sequence jump = DOTween.Sequence()
            .Append(transform.DOMoveY(y+5, 0.25f))
            .Append(transform.DOMoveY(y, 0.25f))
            .SetAutoKill(false);
        jump.Complete();

        /*--[アニメーションの制御]--*/

        //１～12秒は立ってる

        float time1 = 13.3f;
        float time2 = time1 + 0.5f;
        float time3 = time2 + 0.5f;
        float time4 = time3 + 0.5f;
        float time5 = time4 + 1.0f;
        float time6 = time5 + 9.0f;
        float time7 = time6 + 0.5f;
        float time8 = time7 + 0.3f;
        float time9 = time8 + 0.7f;
        float time10 = time9 + 1.0f;
        float time11 = time10 + 1.0f;

        //前方ジャンプ１秒
        Observable.Timer(TimeSpan.FromSeconds(time1))
            .Subscribe(_ => {
                m_anime.SetTrigger(JUMP);
                transform.DOMoveX(m_target1Pos.x, 1);
                transform.DOMoveZ(m_target1Pos.z, 1);
                transform.DORotateQuaternion(Quaternion.LookRotation(m_target1Pos - m_firstPos), 1);
                jump.Restart();
            });
        // ジャンプ
        Observable.Timer(TimeSpan.FromSeconds(time2))
            .Subscribe(_ => {
                m_anime.SetTrigger(JUMP);
                jump.Restart();
            });

        //攻撃１秒
        Observable.Timer(TimeSpan.FromSeconds(time3))
            .Subscribe(_ => {
                m_anime.SetTrigger(ATTACK);
            });

        //後方ジャンプ１秒
        Observable.Timer(TimeSpan.FromSeconds(time4))
            .Subscribe(_ => {
                m_anime.SetTrigger(BACKJUMP);
                transform.DOMove(m_firstPos, 0.8f);
                transform.DORotate(new Vector3(0, 0, 0), 0.8f);
            });



        //立ってる9秒
        Observable.Timer(TimeSpan.FromSeconds(time5))
            .Subscribe(_ => {
                m_anime.SetTrigger(IDLE);
            });



        //前方移動１秒
        Observable.Timer(TimeSpan.FromSeconds(time6))
            .Subscribe(_ =>
            {
                m_anime.SetTrigger(JUMP);
                transform.DOMoveX(m_target2Pos.x, 1);
                transform.DOMoveZ(m_target2Pos.z, 1);
                transform.rotation = Quaternion.LookRotation(m_target2Pos - m_firstPos);
                jump.Restart();
            });

        Observable.Timer(TimeSpan.FromSeconds(time7))
            .Subscribe(_ =>
            {
                m_anime.SetTrigger(JUMP);
                jump.Restart();
            });

        //攻撃１秒
        Observable.Timer(TimeSpan.FromSeconds(time8))
            .Subscribe(_ => {
                m_anime.SetTrigger(ATTACK);
            });

        //後方ジャンプ１秒
        Observable.Timer(TimeSpan.FromSeconds(time9))
            .Subscribe(_ => {
                m_anime.SetTrigger(BACKJUMP);
                transform.DOMoveX(m_firstPos.x, 0.8f);
                transform.DOMoveZ(m_firstPos.z, 0.8f);
                transform.DOMoveY(-0.2f, 1.0f);
                transform.DORotate(new Vector3(0, 0, 0), 0.8f);
                jump.Kill();
            });


        //武器しまう1.5秒
        Observable.Timer(TimeSpan.FromSeconds(time10))
            .Subscribe(_ => {
                m_anime.SetTrigger(END);
            });

        //武器しまい終わり1.5秒
        Observable.Timer(TimeSpan.FromSeconds(time11))
            .Subscribe(_ =>
            {
				//剣を切り離して、背中に着ける
				m_club.transform.parent = m_born.transform;
				m_club.transform.position = m_born.transform.position;
				m_club.transform.rotation = m_born.transform.rotation;
			});
    }
}
