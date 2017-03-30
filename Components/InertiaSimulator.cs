//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using System;
using UnityEngine;

namespace Fizix
{

    /// <summary>
    /// コンポーネント。VelocityCalculatorクラスと接地判定のインターフェイスに依存している。
    /// 慣性を簡易シミュレートする。(足場の rotate からは影響を受けない)
    /// 慣性という単語は厳密には当てはまらないかもしれないが、代替となる言葉がわからない。
    /// </summary>
    public class InertiaSimulator : MonoBehaviour, IMovementCalculator
    {

        public Vector3 FixedMovement { get; set; }
        public Vector3 MovementPerFrame { get; set; }

        private IGroundDetector detector;
        private VelocityCalculator calculator;


        private void Start()
        {
            detector = GetComponent<IGroundDetector>();
            calculator = new VelocityCalculator();
        }


        private void Update()
        {
            // 接地していない場合は何もしない(現在の移動量も変更しない)。
            if (detector.IsGrounding == false)
            {
                calculator.ResetLastInfo();
                return;
            }


             GameObject currentGround = detector.LastDetectedGround;

            calculator.UpdateCurrentInfo(currentGround);

            // 足場となっているオブジェクトが変わっていない場合、そのオブジェクトと同じ移動量を得る。
            if (calculator.CurrentGround == calculator.LastGround)
            {
                MovementPerFrame = calculator.CalcVelocity();
                MovementPerFrame = new Vector3(MovementPerFrame.x, 0f, MovementPerFrame.z); // テスト中
            }

            //Debug.Log(
            //"CurrentGround : " + calculator.CurrentGround + " at " + calculator.CurrentPosition + "\n" +
            //"LastGround : " + calculator.LastGround + " at " + calculator.LastPosition + "\n"
            //);

            calculator.UpdateLastInfo(currentGround);
            
        }
        



        // 接地していないとき : 現在の移動をそのまま続ける
        // 接地中 : 足場と同じ移動量ぶん移動する
        // 接地終了 : LastGround の情報をリセットする。
    }
}