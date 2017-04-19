﻿namespace VRTK
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class VRTK_Haptics : MonoBehaviour
    {
        protected Dictionary<VRTK_ControllerReference, Coroutine> hapticLoopCoroutines = new Dictionary<VRTK_ControllerReference, Coroutine>();

        [Obsolete("`VRTK_Haptics.TriggerHapticPulse(controllerIndex, strength)` has been replaced with `VRTK_Haptics.TriggerHapticPulse(controllerReference, strength)`. This method will be removed in a future version of VRTK.")]
        public virtual void TriggerHapticPulse(uint controllerIndex, float strength)
        {
            TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(controllerIndex), strength);
        }

        public virtual void TriggerHapticPulse(VRTK_ControllerReference controllerReference, float strength)
        {
            CancelHapticPulse(controllerReference);
            var hapticPulseStrength = Mathf.Clamp(strength, 0f, 1f);
            VRTK_SDK_Bridge.HapticPulseOnControllerReference(controllerReference, hapticPulseStrength);
        }

        [Obsolete("`VRTK_Haptics.TriggerHapticPulse(controllerIndex, strength, duration, pulseInterval)` has been replaced with `VRTK_Haptics.TriggerHapticPulse(controllerReference, strength, duration, pulseInterval)`. This method will be removed in a future version of VRTK.")]
        public virtual void TriggerHapticPulse(uint controllerIndex, float strength, float duration, float pulseInterval)
        {
            TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(controllerIndex), strength, duration, pulseInterval);
        }

        public virtual void TriggerHapticPulse(VRTK_ControllerReference controllerReference, float strength, float duration, float pulseInterval)
        {
            CancelHapticPulse(controllerReference);
            var hapticPulseStrength = Mathf.Clamp(strength, 0f, 1f);
            var hapticModifiers = VRTK_SDK_Bridge.GetHapticModifiers();
            Coroutine hapticLoop = StartCoroutine(HapticPulse(controllerReference, duration * hapticModifiers.durationModifier, hapticPulseStrength, pulseInterval * hapticModifiers.intervalModifier));
            if (!hapticLoopCoroutines.ContainsKey(controllerReference))
            {
                hapticLoopCoroutines.Add(controllerReference, hapticLoop);
            }
        }

        protected virtual void OnDisable()
        {
            foreach (KeyValuePair<VRTK_ControllerReference, Coroutine> hapticLoopCoroutine in hapticLoopCoroutines)
            {
                CancelHapticPulse(hapticLoopCoroutine.Key);
            }
        }

        protected virtual void CancelHapticPulse(VRTK_ControllerReference controllerReference)
        {
            if (hapticLoopCoroutines.ContainsKey(controllerReference) && hapticLoopCoroutines[controllerReference] != null)
            {
                StopCoroutine(hapticLoopCoroutines[controllerReference]);
            }
        }

        protected virtual IEnumerator HapticPulse(VRTK_ControllerReference controllerReference, float duration, float hapticPulseStrength, float pulseInterval)
        {
            if (pulseInterval <= 0)
            {
                yield break;
            }

            while (duration > 0)
            {
                VRTK_SDK_Bridge.HapticPulseOnControllerReference(controllerReference, hapticPulseStrength);
                yield return new WaitForSeconds(pulseInterval);
                duration -= pulseInterval;
            }
        }
    }
}