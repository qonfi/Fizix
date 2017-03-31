//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using UnityEngine;

namespace Fizix
{

    /// <summary>
    ///  コンポーネント。重力計算のインターフェイスと接地判定のインターフェイスに依存している。
    /// </summary>
    public class GravitySimulator : MonoBehaviour, IMovementCalculator
    {

        IGravityCalculator calculator;
        IGroundDetector detector;
        
        public float FloatingTime { get; private set; }
        public Vector3 FixedMovement { get; set; }
        public  Vector3 MovementPerFrame { get; set; }
        private Vector3 constantGravity;


        private void Start()
        {
            calculator = new GravityCalculator();
            detector = GetComponent<GroundDetector>();
            constantGravity = Vector3.down * 0.2f;
        }


        private void Update()
        {
            if (detector.IsGrounding)
            {
                FloatingTime = 0f;
                // MovementPerFrame = Vector3.zero; // ?
                MovementPerFrame = constantGravity;   // エレベータでのバウンドを防ぐ。応急的。重力計算を 浮遊時間*加速度+定数 にするか？
                return;
            }

            FloatingTime += Time.deltaTime;
            MovementPerFrame = calculator.CalcMovement(FloatingTime) * Vector3.down;
        }

    }
}