//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using UnityEngine;

namespace Fizix
{

    /// <summary>
    /// コンポーネント。子オブジェクトとなることで慣性をシミュレートする。
    /// 接地判定のインターフェイスに依存している。
    /// </summary>
    public class AdoptiveInertia : MonoBehaviour
    {

        private IGroundDetector detector;


        private void Start()
        {
            detector = GetComponent<IGroundDetector>();
            
        }


        private void Update()
        {

            if (detector.LastDetectedGround == null) { return; }

            this.transform.parent = detector.LastDetectedGround.transform;

        }
    }
}