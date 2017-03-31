//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using System;
using UnityEngine;

namespace Fizix
{


    public class GroundDetector : MonoBehaviour, IGroundDetector
    {

        public bool IsGrounding { get; set; }
        public GameObject LastDetectedGround { get; set; }
        private SphereCaster caster;
        

        private void Start()
        {
            caster = new SphereCaster();
            caster.IgnoreMyLayer(this.gameObject);
        }


        private void Update()
        {
            IsGrounding = caster.Cast(this.transform.position);
            LastDetectedGround = caster.LastDetectedObject;
        }

    }


    

}