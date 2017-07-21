//************************************************/
//* @file  :PerformanceCamera.cs
//* @brief :カメラ演出用のスクリプト
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

public class PerformanceCamera : MonoBehaviour {

    //正面位置　スライム３匹
    private Vector3 m_frontPos = new Vector3(4.5f, 2.0f, -5.0f);


    void Start () {

        float time1 = 8.0f;
        float time2 = time1 + 3.2f;
        float time3 = time2 + 2.0f;
        float time4 = time3 + 2.5f;
        float time5 = time4 + 2.8f;
        float time6 = time5 + 2.0f;
        float time7 = time6 + 1.5f;
        float time8 = time7 + 3.0f;
        float time9 = time8 + 2.5f;

        //１～７秒は正面
        transform.position = m_frontPos;
        transform.rotation = Quaternion.LookRotation(new Vector3(0.0f, 0.0f,0.0f), Vector3.up);

        //主人公->スライムA　攻撃
        Observable.Timer(TimeSpan.FromSeconds(time1))
            .Subscribe(_ => {
                transform.position = new Vector3(-8.0f,3.5f,12.0f);
                transform.rotation = Quaternion.Euler(6.0f,150.0f,-3.0f);
            });


        //スライムB->ヤンガス　攻撃
        Observable.Timer(TimeSpan.FromSeconds(time2))
            .Subscribe(_ => {
                transform.position = new Vector3(7.3f, 3.5f, 11.73f);
                transform.rotation = Quaternion.Euler(20.0f, 175.0f, .0f);
                transform.DOMove(new Vector3(8.42f, 3.5f, -1.13f), 0.5f);
            });

        //ヤンガス->スライムB　攻撃
        Observable.Timer(TimeSpan.FromSeconds(time3))
            .Subscribe(_ => {
                transform.position = new Vector3(2.8f, 3.5f, -15f);
                transform.rotation = Quaternion.Euler(10.0f, 26.5f, 0.0f);
                transform.DOMove(new Vector3(1.5f, 3.5f, -4.84f), 1.5f);
            });



        //スライムC->ヤンガス　攻撃
        Observable.Timer(TimeSpan.FromSeconds(time4))
            .Subscribe(_ => {
                transform.position = new Vector3(17f, 3.5f, 12.3f);
                transform.rotation = Quaternion.Euler(15.0f, 194.5f, 0.0f);
                transform.DOMove(new Vector3(11.9f, 3.5f, -1.7f), 1.5f);
            });



        //正面
        Observable.Timer(TimeSpan.FromSeconds(time5))
            .Subscribe(_ => {
                transform.position = m_frontPos;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            });


        //スライムC->主人公　攻撃
        Observable.Timer(TimeSpan.FromSeconds(time6))
            .Subscribe(_ => {
                transform.position = new Vector3(17f, 3.5f, 12.3f);
                transform.rotation = Quaternion.Euler(15.0f, 194.5f, 0.0f);
                transform.DOMove(new Vector3(-0.3f, 3.5f, -3.3f), 0.8f);
            });


        //主人公->スライムC
        Observable.Timer(TimeSpan.FromSeconds(time7))
            .Subscribe(_ => {
                transform.position = new Vector3(-8f, 3.0f, -8.0f);
                transform.rotation = Quaternion.Euler(10.0f, 70.0f, 0.0f);
                transform.DOMove(new Vector3(6f, 3.0f, 4f),1.0f);
            });



        //ヤンガス->スライムC
        Observable.Timer(TimeSpan.FromSeconds(time8))
            .Subscribe(_ => {
                transform.position = new Vector3(18f, 3.5f, 14f);
                transform.rotation = Quaternion.Euler(10.0f, 208.0f, 0.0f);
            });



        //戦闘終了
        Observable.Timer(TimeSpan.FromSeconds(time9))
            .Subscribe(_ => {
                transform.position = new Vector3(9f, 6f, 0.5f);
                transform.rotation = Quaternion.Euler(20.0f, 210.0f, 0.0f);
                transform.DOMove(new Vector3(0.0f, 6.5f, 2.3f), 20.0f);
                transform.DORotate(new Vector3(20, 163.0f, 0), 20.0f);
            });
    }
}
