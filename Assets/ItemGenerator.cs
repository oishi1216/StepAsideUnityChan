using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //unityChanを入れる
    public GameObject unityChan;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //アイテム生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;


    // Use this for initialization
    void Start()
    {
        //シーン中のunitychanオブジェクトを取得
        unityChan = GameObject.Find("unitychan");
        //時間間隔を決定する
        interval = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {

        //時間計測
        time += Time.deltaTime;

        //移動距離が20mを超えて、ユニティちゃんがゴール50m前よりも手前にいる場合
        if (time > interval && unityChan.transform.position.z < goalPos - 50)
        {
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                //アイテムを置くZ座標のオフセットをランダムに設定
                int offsetZ = Random.Range(40, 50);

                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                    {
                        //コーンを生成
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        //unityChanがいる位置から40m先に設定
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unityChan.transform.position.z + offsetZ);
                    }
                }
                else
                {
                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(40, 50);

                        //60%コイン配置:30%車配置:10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            //unityChanがいる位置から40m～50m先に設定
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unityChan.transform.position.z + offsetZ);
                            //コインの位置がカメラよりも後ろになったら
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            //unityChanがいる位置から40m～50m先に設定
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, unityChan.transform.position.z + offsetZ);
                        }
                    }

                }
            //経過時間を初期化して再度時間計測を始める
            time = 0f;
        }

    }

}