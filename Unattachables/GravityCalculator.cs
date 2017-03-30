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
    /// コンポーネントではない。
    /// </summary>
    public class GravityCalculator : IGravityCalculator
    {
        public float GravityAccel { get; set; }

        public GravityCalculator()
        {
            GravityAccel = 20f;
        }

        public float CalcMovement(float floatingTime)
        {
            return floatingTime * GravityAccel;
        }
    }
}