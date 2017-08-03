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

    //アニメーター
    public Animator m_anime;

    //スライムの位置
    private Vector3 m_slimeAPos = new Vector3(0, 0, 0);

    // アタック座標(ヤンガス)
    private Vector3 _yangasuPos = new Vector3(9.49f, 0f, -7.0f);
    private Vector3 _HeroPos = new Vector3(-2.2f, 0, -9.24f);

    // ノックバック
    private Vector3 _NockBack = new Vector3(13.4f, 1.2f, 9.0f);


    void Start()
    {

        //アニメーター
        m_anime = GetComponent<Animator>();

        // スライムAの座標記録
        m_slimeAPos = transform.position;

        Animation ani = GetComponent<Animation>();

        /*--[アニメーションの制御]--*/

        // 10秒後アニメーション

        // ジャンプ(1秒間)
        Observable.Timer(TimeSpan.FromSeconds(15.5f))
            .Subscribe(_ =>
            {
                Sequence Seq = DOTween.Sequence()

                // ジャンプ１      終了座標   高さ  回数  時間
                .Append(transform.DOLocalJump
                (new Vector3(14.0f, 0.0f, 0), 2.0f, 1, 0.5f))

                // ジャンプ２
                .Append(transform.DOLocalJump
                (new Vector3(6.0f, 0.0f, -3.5f),2.0f, 1, 0.5f))

                // ジャンプ３
                .Append(transform.DOLocalJump
                (_yangasuPos, 1.0f, 1, 0.4f))

                // その場ジャンプ          終了座標                    高さ  回数  時間
                .Append(transform.DOLocalJump
                (new Vector3(9.3f, 1.0f, -8.5f), 1.5f, 1, 0.2f))

                // 攻撃
                .Append(transform.DOLocalMove
                (new Vector3(9.3f, 0.0f, -7), 0.3f))

				// 元の場所にジャンプ
                .Append(transform.DOLocalJump
                (new Vector3(13.4f,0,6.7f), 3.5f, 1, 0.5f))
                .SetAutoKill(false);
            });

        // アタック(1秒間)
        Observable.Timer(TimeSpan.FromSeconds(21.0f))
            .Subscribe(_ =>
            {
                Sequence Seq = DOTween.Sequence()

                // ヒーローのところへジャンプ    終了座標                    高さ  回数  時間
                .Append(transform.DOLocalJump
                (new Vector3(-2.0f, 0, -7), 1.5f, 1, 0.7f))

                // その場ジャンプ
                .Append(transform.DOLocalJump
                (new Vector3(-2.3f, 0, -7.7f), 1.5f, 1, 0.3f))

                // 元の場所にジャンプ
                .Append(transform.DOLocalJump
                (new Vector3(13.4f, 0, 6.7f), 3.5f, 1, 0.5f))

                .SetAutoKill(false);

            });



        // ダメージ(1秒間)
        Observable.Timer(TimeSpan.FromSeconds(26.0f))
            .Subscribe(_ =>
            {
                // ジャンプ
                transform.DOLocalJump(_NockBack, 2, 2, 1);

                // 1.5秒かけて後ろへ回転
                transform.DORotate(new Vector3(-270, -180), 0.8f);

                // アニメーションを止める
                m_anime.speed = 0;

            });

		Observable.Timer(TimeSpan.FromSeconds(28.5f))
.Subscribe(_ =>
{
Destroy(gameObject);
});


	}
}
