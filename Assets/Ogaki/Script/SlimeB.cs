//＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/＿/
//! @file  :SlimeB.cs
//! @brief :スライムBのスクリプト
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

public class SlimeB : MonoBehaviour
{

    //アニメーター
    public Animator m_anime;


    //スライムの位置
    private Vector3 m_slimeBPos = new Vector3(4.5f, 0, 6.7f);

    // アタック座標(ヤンガス)
    private Vector3 _yangasuPos = new Vector3(9.49f, 0f, -7);

    // ノックバック
    private Vector3 _NockBack = new Vector3(4.5f, 1.2f, 9.0f);


    void Start()
    {
        //アニメーター
        m_anime = GetComponent<Animator>();

        // スライムAの座標記録
        m_slimeBPos = transform.position;

        Animation ani = GetComponent<Animation>();

        /*--[アニメーションの制御]--*/

        // 10秒後アニメーション

        // ジャンプ(1秒間)
        Observable.Timer(TimeSpan.FromSeconds(11.5f))
            .Subscribe(_ =>
            {
                // ヤンガスの場所へジャンプ
                transform.DOLocalJump(_yangasuPos, 3.5f, 1, 0.5f);

            });

        // アタック(1秒間)
        Observable.Timer(TimeSpan.FromSeconds(12.5f))
            .Subscribe(_ =>
            {
                Sequence Seq = DOTween.Sequence()

                // その場ジャンプ          終了座標                    高さ  回数  時間
                .Append(transform.DOLocalJump
                (new Vector3(9.3f, 1.0f, -8.5f), 1.5f, 1, 0.2f))

                // 攻撃
                .Append(transform.DOLocalMove
                (new Vector3(9.3f, 0.0f, -7), 0.3f))
                .SetAutoKill(false);
            });

        // 戻るジャンプ(1秒間)
        Observable.Timer(TimeSpan.FromSeconds(13.0f))
            .Subscribe(_ =>
            {
                // 元の場所へジャンプ
                transform.DOLocalJump(m_slimeBPos, 3.5f, 0, 0.5f);
            });


        // ダメージ(1秒間)
        Observable.Timer(TimeSpan.FromSeconds(14.7f))
            .Subscribe(_ =>
            {
                // ジャンプ
                transform.DOLocalJump(_NockBack, 2, 2, 1);

                // 1.5秒かけて後ろへ回転
                transform.DORotate(new Vector3(-270, -180), 0.8f);

                // アニメーションを止める
                m_anime.speed = 0;
            });


		Observable.Timer(TimeSpan.FromSeconds(17.0f))
.Subscribe(_ =>
{
Destroy(gameObject);
});

	}
}
