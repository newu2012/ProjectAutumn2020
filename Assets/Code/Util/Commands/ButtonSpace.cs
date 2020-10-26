using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class ButtonSpace : Command
    {
        private Player player;
        public override void Execute() 
        {
            player.Jump();
        }
    }
}
