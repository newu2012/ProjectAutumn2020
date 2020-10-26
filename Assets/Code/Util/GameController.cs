using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern 
{
    public class GameController : MonoBehaviour
    {
        private Command buttonSpace;

        // Start is called before the first frame update
        void Start()
        {
            //player = this;
            //buttonSpace = new JumpCommand(player);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                buttonSpace.Execute();
        }
    }
}

