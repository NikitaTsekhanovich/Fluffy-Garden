using GameItems;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace PlayerControllers
{
    public class SawChecker : MonoBehaviour
    {
        private HashSet<Saw> _registrationsSaws = new ();

        public static Action OnResetCounterBonus;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Saw"))
            {
                var saw = col.GetComponent<Saw>();
                saw.CollapseReady();
                _registrationsSaws.Add(saw);
            }
        }

        public void CheckJumpedSaws()
        {
            foreach (var saw in _registrationsSaws)
            {
                if (saw != null)
                    saw.Collapse();
            }
            _registrationsSaws.Clear();
            OnResetCounterBonus?.Invoke();
        }
    }
}

