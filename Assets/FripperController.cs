using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //タッチ操作が行われた時
        //１箇所目のタップ
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //タップした時
            if (touch.phase == TouchPhase.Began)
            {
                FlickFripper(touch.position);
            }
            //タップが終わった時
            if (touch.phase == TouchPhase.Ended)
            {
                RevertFripper(touch.position);
            }
        }
        //２箇所目のタップ
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(1);
            //タップした時
            if (touch1.phase == TouchPhase.Began)
            {
                FlickFripper(touch1.position);
            }
            //タップが終わった時
            if (touch1.phase == TouchPhase.Ended)
            {
                RevertFripper(touch1.position);
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
    //フリッパーをフリック
    public void FlickFripper(Vector2 pos)
    {
        if ((pos.x < Screen.width / 2) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if ((pos.x >= Screen.width / 2) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
    }
    //フリッパーを元に戻す
    public void RevertFripper(Vector2 pos)
    {
        if ((pos.x < Screen.width / 2) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if ((pos.x >= Screen.width / 2) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }
}
