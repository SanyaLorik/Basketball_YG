using System;
using UnityEngine;

namespace Basketball_YG.Animation
{
    public class NotificationPopup
    {
        public void NotifyBallAlreadySelected()
        {
            Debug.Log("Ball has already selected!");
        }

        public void NotifyNoEnoughtMoney()
        {
            Debug.Log("No enought money!");
        }
    }
}