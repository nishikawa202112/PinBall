using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //得点の初期化
    private int point = 0;

    //得点を表示するテキスト
    private GameObject gamepointText;

    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    // Use this for initialization
    void Start()
    {
        //シーン中のGamePointTextオブジェクトを取得
        this.gamepointText = GameObject.Find("GamePointText");

        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //ボールの衝突時に得点を計算する
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.point += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.point += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.point += 5;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.point += 7;
        }
        //GamePointTextに得点を表示
        this.gamepointText.GetComponent<Text>().text = this.point.ToString()+" 点";
    }
}
