namespace VRTK
{
    using UnityEngine;
    using System.Collections.Generic;

    public static class VRTK_SDK_Bridge
    {
        private static SDK_BaseSystem systemSDK = null;
        private static SDK_BaseHeadset headsetSDK = null;
        private static SDK_BaseController controllerSDK = null;
        private static SDK_BaseBoundaries boundariesSDK = null;

        #region Controller Methods

        public static void ControllerProcessUpdate(VRTK_ControllerReference controllerReference, Dictionary<string, object> options = null)
        {
            GetControllerSDK().ProcessUpdate(controllerReference.index, options);
        }

        public static void ControllerProcessFixedUpdate(VRTK_ControllerReference controllerReference, Dictionary<string, object> options = null)
        {
            GetControllerSDK().ProcessFixedUpdate(controllerReference.index, options);
        }

        public static string GetControllerDefaultColliderPath(SDK_BaseController.ControllerHand hand)
        {
            return GetControllerSDK().GetControllerDefaultColliderPath(hand);
        }

        public static string GetControllerElementPath(SDK_BaseController.ControllerElements element, SDK_BaseController.ControllerHand hand, bool fullPath = false)
        {
            return GetControllerSDK().GetControllerElementPath(element, hand, fullPath);
        }

        public static uint GetControllerIndex(GameObject controller)
        {
            return GetControllerSDK().GetControllerIndex(controller);
        }

        public static GameObject GetControllerByIndex(uint index, bool actual)
        {
            return GetControllerSDK().GetControllerByIndex(index, actual);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.GetControllerOrigin(controller)` has been replaced with `VRTK_SDK_Bridge.GetControllerOrigin(controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static Transform GetControllerOrigin(GameObject controller)
        {
            return GetControllerOrigin(VRTK_ControllerReference.GetControllerReference(controller));
        }

        public static Transform GetControllerOrigin(VRTK_ControllerReference controllerReference)
        {
            return GetControllerSDK().GetControllerOrigin(controllerReference.scriptAlias);
        }

        public static Transform GenerateControllerPointerOrigin(GameObject parent)
        {
            return GetControllerSDK().GenerateControllerPointerOrigin(parent);
        }

        public static GameObject GetControllerLeftHand(bool actual)
        {
            return GetControllerSDK().GetControllerLeftHand(actual);
        }

        public static GameObject GetControllerRightHand(bool actual)
        {
            return GetControllerSDK().GetControllerRightHand(actual);
        }

        public static bool IsControllerLeftHand(GameObject controller)
        {
            return GetControllerSDK().IsControllerLeftHand(controller);
        }

        public static bool IsControllerRightHand(GameObject controller)
        {
            return GetControllerSDK().IsControllerRightHand(controller);
        }

        public static bool IsControllerLeftHand(GameObject controller, bool actual)
        {
            return GetControllerSDK().IsControllerLeftHand(controller, actual);
        }

        public static bool IsControllerRightHand(GameObject controller, bool actual)
        {
            return GetControllerSDK().IsControllerRightHand(controller, actual);
        }

        public static GameObject GetControllerModel(GameObject controller)
        {
            return GetControllerSDK().GetControllerModel(controller);
        }

        public static SDK_BaseController.ControllerHand GetControllerModelHand(GameObject controllerModel)
        {
            return GetControllerSDK().GetControllerModelHand(controllerModel);
        }

        public static GameObject GetControllerModel(SDK_BaseController.ControllerHand hand)
        {
            return GetControllerSDK().GetControllerModel(hand);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.GetControllerRenderModel(controller)` has been replaced with `VRTK_SDK_Bridge.GetControllerRenderModel(controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static GameObject GetControllerRenderModel(GameObject controller)
        {
            return GetControllerRenderModel(VRTK_ControllerReference.GetControllerReference(controller));
        }

        public static GameObject GetControllerRenderModel(VRTK_ControllerReference controllerReference)
        {
            return GetControllerSDK().GetControllerRenderModel(controllerReference.actual);
        }

        public static void SetControllerRenderModelWheel(GameObject renderModel, bool state)
        {
            GetControllerSDK().SetControllerRenderModelWheel(renderModel, state);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.HapticPulseOnIndex(index, strength)` has been replaced with `VRTK_SDK_Bridge.HapticPulseOnControllerReference(controllerReference, strength)`. This method will be removed in a future version of VRTK.")]
        public static void HapticPulseOnIndex(uint index, float strength = 0.5f)
        {
            GetControllerSDK().HapticPulseOnIndex(index, strength);
        }

        public static void HapticPulseOnControllerReference(VRTK_ControllerReference controllerReference, float strength = 0.5f)
        {
            GetControllerSDK().HapticPulseOnIndex(controllerReference.index, strength);
        }

        public static SDK_ControllerHapticModifiers GetHapticModifiers()
        {
            return GetControllerSDK().GetHapticModifiers();
        }

        [System.Obsolete("`VRTK_SDK_Bridge.GetVelocityOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerVelocity(controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static Vector3 GetVelocityOnIndex(uint index)
        {
            return GetControllerSDK().GetVelocityOnIndex(index);
        }

        public static Vector3 GetControllerVelocity(VRTK_ControllerReference controllerReference)
        {
            return GetControllerSDK().GetVelocityOnIndex(controllerReference.index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.GetAngularVelocityOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerAngularVelocity(controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static Vector3 GetAngularVelocityOnIndex(uint index)
        {
            return GetControllerSDK().GetAngularVelocityOnIndex(index);
        }

        public static Vector3 GetControllerAngularVelocity(VRTK_ControllerReference controllerReference)
        {
            return GetControllerSDK().GetAngularVelocityOnIndex(controllerReference.index);
        }

        public static Vector2 GetControllerAxis(SDK_BaseController.ButtonTypes buttonType, VRTK_ControllerReference controllerReference)
        {
            switch (buttonType)
            {
                case SDK_BaseController.ButtonTypes.Touchpad:
                    return GetControllerSDK().GetTouchpadAxisOnIndex(controllerReference.index);
                case SDK_BaseController.ButtonTypes.Trigger:
                    return GetControllerSDK().GetTriggerAxisOnIndex(controllerReference.index);
                case SDK_BaseController.ButtonTypes.Grip:
                    return GetControllerSDK().GetGripAxisOnIndex(controllerReference.index);
            }
            return Vector2.zero;
        }

        public static float GetControllerHairlineDelta(SDK_BaseController.ButtonTypes buttonType, VRTK_ControllerReference controllerReference)
        {
            switch (buttonType)
            {
                case SDK_BaseController.ButtonTypes.Trigger:
                case SDK_BaseController.ButtonTypes.TriggerHairline:
                    return GetControllerSDK().GetTriggerHairlineDeltaOnIndex(controllerReference.index);
                case SDK_BaseController.ButtonTypes.Grip:
                case SDK_BaseController.ButtonTypes.GripHairline:
                    return GetControllerSDK().GetGripHairlineDeltaOnIndex(controllerReference.index);
            }
            return 0f;
        }

        public static bool GetControllerButtonState(SDK_BaseController.ButtonTypes buttonType, SDK_BaseController.ButtonPressTypes pressType, VRTK_ControllerReference controllerReference)
        {
            //Button One
            if (buttonType == SDK_BaseController.ButtonTypes.ButtonOne && pressType == SDK_BaseController.ButtonPressTypes.Press)
            {
                return GetControllerSDK().IsButtonOnePressedOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.ButtonOne && pressType == SDK_BaseController.ButtonPressTypes.PressDown)
            {
                return GetControllerSDK().IsButtonOnePressedDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.ButtonOne && pressType == SDK_BaseController.ButtonPressTypes.PressUp)
            {
                return GetControllerSDK().IsButtonOnePressedUpOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.ButtonOne && pressType == SDK_BaseController.ButtonPressTypes.Touch)
            {
                return GetControllerSDK().IsButtonOneTouchedOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.ButtonOne && pressType == SDK_BaseController.ButtonPressTypes.TouchDown)
            {
                return GetControllerSDK().IsButtonOneTouchedDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.ButtonOne && pressType == SDK_BaseController.ButtonPressTypes.TouchUp)
            {
                return GetControllerSDK().IsButtonOneTouchedUpOnIndex(controllerReference.index);
            }
            //Button Two
            else if (buttonType == SDK_BaseController.ButtonTypes.ButtonTwo && pressType == SDK_BaseController.ButtonPressTypes.Press)
            {
                return GetControllerSDK().IsButtonTwoPressedOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.ButtonTwo && pressType == SDK_BaseController.ButtonPressTypes.PressDown)
            {
                return GetControllerSDK().IsButtonTwoPressedDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.ButtonTwo && pressType == SDK_BaseController.ButtonPressTypes.PressUp)
            {
                return GetControllerSDK().IsButtonTwoPressedUpOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.ButtonTwo && pressType == SDK_BaseController.ButtonPressTypes.Touch)
            {
                return GetControllerSDK().IsButtonTwoTouchedOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.ButtonTwo && pressType == SDK_BaseController.ButtonPressTypes.TouchDown)
            {
                return GetControllerSDK().IsButtonTwoTouchedDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.ButtonTwo && pressType == SDK_BaseController.ButtonPressTypes.TouchUp)
            {
                return GetControllerSDK().IsButtonTwoTouchedUpOnIndex(controllerReference.index);
            }
            //Grip
            else if (buttonType == SDK_BaseController.ButtonTypes.Grip && pressType == SDK_BaseController.ButtonPressTypes.Press)
            {
                return GetControllerSDK().IsGripPressedOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Grip && pressType == SDK_BaseController.ButtonPressTypes.PressDown)
            {
                return GetControllerSDK().IsGripPressedDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Grip && pressType == SDK_BaseController.ButtonPressTypes.PressUp)
            {
                return GetControllerSDK().IsGripPressedUpOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Grip && pressType == SDK_BaseController.ButtonPressTypes.Touch)
            {
                return GetControllerSDK().IsGripTouchedOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Grip && pressType == SDK_BaseController.ButtonPressTypes.TouchDown)
            {
                return GetControllerSDK().IsGripTouchedDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Grip && pressType == SDK_BaseController.ButtonPressTypes.TouchUp)
            {
                return GetControllerSDK().IsGripTouchedUpOnIndex(controllerReference.index);
            }
            //Grip Hairline
            else if (buttonType == SDK_BaseController.ButtonTypes.GripHairline && pressType == SDK_BaseController.ButtonPressTypes.PressDown)
            {
                return GetControllerSDK().IsHairGripDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.GripHairline && pressType == SDK_BaseController.ButtonPressTypes.PressUp)
            {
                return GetControllerSDK().IsHairGripUpOnIndex(controllerReference.index);
            }
            //Start Menu
            else if (buttonType == SDK_BaseController.ButtonTypes.StartMenu && pressType == SDK_BaseController.ButtonPressTypes.Press)
            {
                return GetControllerSDK().IsStartMenuPressedOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.StartMenu && pressType == SDK_BaseController.ButtonPressTypes.PressDown)
            {
                return GetControllerSDK().IsStartMenuPressedDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.StartMenu && pressType == SDK_BaseController.ButtonPressTypes.PressUp)
            {
                return GetControllerSDK().IsStartMenuPressedUpOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.StartMenu && pressType == SDK_BaseController.ButtonPressTypes.Touch)
            {
                return GetControllerSDK().IsStartMenuTouchedOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.StartMenu && pressType == SDK_BaseController.ButtonPressTypes.TouchDown)
            {
                return GetControllerSDK().IsStartMenuTouchedDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.StartMenu && pressType == SDK_BaseController.ButtonPressTypes.TouchUp)
            {
                return GetControllerSDK().IsStartMenuTouchedUpOnIndex(controllerReference.index);
            }
            //Trigger
            else if (buttonType == SDK_BaseController.ButtonTypes.Trigger && pressType == SDK_BaseController.ButtonPressTypes.Press)
            {
                return GetControllerSDK().IsTriggerPressedOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Trigger && pressType == SDK_BaseController.ButtonPressTypes.PressDown)
            {
                return GetControllerSDK().IsTriggerPressedDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Trigger && pressType == SDK_BaseController.ButtonPressTypes.PressUp)
            {
                return GetControllerSDK().IsTriggerPressedUpOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Trigger && pressType == SDK_BaseController.ButtonPressTypes.Touch)
            {
                return GetControllerSDK().IsTriggerTouchedOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Trigger && pressType == SDK_BaseController.ButtonPressTypes.TouchDown)
            {
                return GetControllerSDK().IsTriggerTouchedDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Trigger && pressType == SDK_BaseController.ButtonPressTypes.TouchUp)
            {
                return GetControllerSDK().IsTriggerTouchedUpOnIndex(controllerReference.index);
            }
            //Trigger Hairline
            else if (buttonType == SDK_BaseController.ButtonTypes.TriggerHairline && pressType == SDK_BaseController.ButtonPressTypes.PressDown)
            {
                return GetControllerSDK().IsHairTriggerDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.TriggerHairline && pressType == SDK_BaseController.ButtonPressTypes.PressUp)
            {
                return GetControllerSDK().IsHairTriggerUpOnIndex(controllerReference.index);
            }
            //Touchpad
            else if (buttonType == SDK_BaseController.ButtonTypes.Touchpad && pressType == SDK_BaseController.ButtonPressTypes.Press)
            {
                return GetControllerSDK().IsTouchpadPressedOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Touchpad && pressType == SDK_BaseController.ButtonPressTypes.PressDown)
            {
                return GetControllerSDK().IsTouchpadPressedDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Touchpad && pressType == SDK_BaseController.ButtonPressTypes.PressUp)
            {
                return GetControllerSDK().IsTouchpadPressedUpOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Touchpad && pressType == SDK_BaseController.ButtonPressTypes.Touch)
            {
                return GetControllerSDK().IsTouchpadTouchedOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Touchpad && pressType == SDK_BaseController.ButtonPressTypes.TouchDown)
            {
                return GetControllerSDK().IsTouchpadTouchedDownOnIndex(controllerReference.index);
            }
            else if (buttonType == SDK_BaseController.ButtonTypes.Touchpad && pressType == SDK_BaseController.ButtonPressTypes.TouchUp)
            {
                return GetControllerSDK().IsTouchpadTouchedUpOnIndex(controllerReference.index);
            }

            return false;
        }

        [System.Obsolete("`VRTK_SDK_Bridge.GetTouchpadAxisOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerAxis(buttonType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static Vector2 GetTouchpadAxisOnIndex(uint index)
        {
            return GetControllerSDK().GetTouchpadAxisOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.GetTriggerAxisOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerAxis(buttonType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static Vector2 GetTriggerAxisOnIndex(uint index)
        {
            return GetControllerSDK().GetTriggerAxisOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.GetGripAxisOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerAxis(buttonType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static Vector2 GetGripAxisOnIndex(uint index)
        {
            return GetControllerSDK().GetGripAxisOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.GetTriggerHairlineDeltaOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerHairlineDelta(buttonType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static float GetTriggerHairlineDeltaOnIndex(uint index)
        {
            return GetControllerSDK().GetTriggerHairlineDeltaOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.GetGripHairlineDeltaOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerHairlineDelta(buttonType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static float GetGripHairlineDeltaOnIndex(uint index)
        {
            return GetControllerSDK().GetGripHairlineDeltaOnIndex(index);
        }

        //Trigger
        [System.Obsolete("`VRTK_SDK_Bridge.IsTriggerPressedOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsTriggerPressedOnIndex(uint index)
        {
            return GetControllerSDK().IsTriggerPressedOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsTriggerPressedDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsTriggerPressedDownOnIndex(uint index)
        {
            return GetControllerSDK().IsTriggerPressedDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsTriggerPressedUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsTriggerPressedUpOnIndex(uint index)
        {
            return GetControllerSDK().IsTriggerPressedUpOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsTriggerTouchedOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsTriggerTouchedOnIndex(uint index)
        {
            return GetControllerSDK().IsTriggerTouchedOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsTriggerTouchedDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsTriggerTouchedDownOnIndex(uint index)
        {
            return GetControllerSDK().IsTriggerTouchedDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsTriggerTouchedUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsTriggerTouchedUpOnIndex(uint index)
        {
            return GetControllerSDK().IsTriggerTouchedUpOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsHairTriggerDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsHairTriggerDownOnIndex(uint index)
        {
            return GetControllerSDK().IsHairTriggerDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsHairTriggerUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsHairTriggerUpOnIndex(uint index)
        {
            return GetControllerSDK().IsHairTriggerUpOnIndex(index);
        }

        //Grip
        [System.Obsolete("`VRTK_SDK_Bridge.IsGripPressedOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsGripPressedOnIndex(uint index)
        {
            return GetControllerSDK().IsGripPressedOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsGripPressedDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsGripPressedDownOnIndex(uint index)
        {
            return GetControllerSDK().IsGripPressedDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsGripPressedUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsGripPressedUpOnIndex(uint index)
        {
            return GetControllerSDK().IsGripPressedUpOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsGripTouchedOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsGripTouchedOnIndex(uint index)
        {
            return GetControllerSDK().IsGripTouchedOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsGripTouchedDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsGripTouchedDownOnIndex(uint index)
        {
            return GetControllerSDK().IsGripTouchedDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsGripTouchedUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsGripTouchedUpOnIndex(uint index)
        {
            return GetControllerSDK().IsGripTouchedUpOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsHairGripDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsHairGripDownOnIndex(uint index)
        {
            return GetControllerSDK().IsHairGripDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsHairGripUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsHairGripUpOnIndex(uint index)
        {
            return GetControllerSDK().IsHairGripUpOnIndex(index);
        }

        //Touchpad

        [System.Obsolete("`VRTK_SDK_Bridge.IsTouchpadPressedOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsTouchpadPressedOnIndex(uint index)
        {
            return GetControllerSDK().IsTouchpadPressedOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsTouchpadPressedDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsTouchpadPressedDownOnIndex(uint index)
        {
            return GetControllerSDK().IsTouchpadPressedDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsTouchpadPressedUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsTouchpadPressedUpOnIndex(uint index)
        {
            return GetControllerSDK().IsTouchpadPressedUpOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsTouchpadTouchedOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsTouchpadTouchedOnIndex(uint index)
        {
            return GetControllerSDK().IsTouchpadTouchedOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsTouchpadTouchedDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsTouchpadTouchedDownOnIndex(uint index)
        {
            return GetControllerSDK().IsTouchpadTouchedDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsTouchpadTouchedUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsTouchpadTouchedUpOnIndex(uint index)
        {
            return GetControllerSDK().IsTouchpadTouchedUpOnIndex(index);
        }

        //ButtonOne

        [System.Obsolete("`VRTK_SDK_Bridge.IsButtonOnePressedOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsButtonOnePressedOnIndex(uint index)
        {
            return GetControllerSDK().IsButtonOnePressedOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsButtonOnePressedDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsButtonOnePressedDownOnIndex(uint index)
        {
            return GetControllerSDK().IsButtonOnePressedDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsButtonOnePressedUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsButtonOnePressedUpOnIndex(uint index)
        {
            return GetControllerSDK().IsButtonOnePressedUpOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsButtonOneTouchedOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsButtonOneTouchedOnIndex(uint index)
        {
            return GetControllerSDK().IsButtonOneTouchedOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsButtonOneTouchedDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsButtonOneTouchedDownOnIndex(uint index)
        {
            return GetControllerSDK().IsButtonOneTouchedDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsButtonOneTouchedUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsButtonOneTouchedUpOnIndex(uint index)
        {
            return GetControllerSDK().IsButtonOneTouchedUpOnIndex(index);
        }

        //ButtonTwo

        [System.Obsolete("`VRTK_SDK_Bridge.IsButtonTwoPressedOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsButtonTwoPressedOnIndex(uint index)
        {
            return GetControllerSDK().IsButtonTwoPressedOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsButtonTwoPressedDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsButtonTwoPressedDownOnIndex(uint index)
        {
            return GetControllerSDK().IsButtonTwoPressedDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsButtonTwoPressedUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsButtonTwoPressedUpOnIndex(uint index)
        {
            return GetControllerSDK().IsButtonTwoPressedUpOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsButtonTwoTouchedOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsButtonTwoTouchedOnIndex(uint index)
        {
            return GetControllerSDK().IsButtonTwoTouchedOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsButtonTwoTouchedDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsButtonTwoTouchedDownOnIndex(uint index)
        {
            return GetControllerSDK().IsButtonTwoTouchedDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsButtonTwoTouchedUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsButtonTwoTouchedUpOnIndex(uint index)
        {
            return GetControllerSDK().IsButtonTwoTouchedUpOnIndex(index);
        }

        //StartMenu

        [System.Obsolete("`VRTK_SDK_Bridge.IsStartMenuPressedOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsStartMenuPressedOnIndex(uint index)
        {
            return GetControllerSDK().IsStartMenuPressedOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsStartMenuPressedDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsStartMenuPressedDownOnIndex(uint index)
        {
            return GetControllerSDK().IsStartMenuPressedDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsStartMenuPressedUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsStartMenuPressedUpOnIndex(uint index)
        {
            return GetControllerSDK().IsStartMenuPressedUpOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsStartMenuTouchedOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsStartMenuTouchedOnIndex(uint index)
        {
            return GetControllerSDK().IsStartMenuTouchedOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsStartMenuTouchedDownOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsStartMenuTouchedDownOnIndex(uint index)
        {
            return GetControllerSDK().IsStartMenuTouchedDownOnIndex(index);
        }

        [System.Obsolete("`VRTK_SDK_Bridge.IsStartMenuTouchedUpOnIndex(index)` has been replaced with `VRTK_SDK_Bridge.GetControllerButtonState(buttonType, pressType, controllerReference)`. This method will be removed in a future version of VRTK.")]
        public static bool IsStartMenuTouchedUpOnIndex(uint index)
        {
            return GetControllerSDK().IsStartMenuTouchedUpOnIndex(index);
        }

        #endregion

        #region Headset Methods

        public static void HeadsetProcessUpdate(Dictionary<string, object> options = null)
        {
            GetHeadsetSDK().ProcessUpdate(options);
        }

        public static void HeadsetProcessFixedUpdate(Dictionary<string, object> options = null)
        {
            GetHeadsetSDK().ProcessFixedUpdate(options);
        }

        public static Transform GetHeadset()
        {
            return GetHeadsetSDK().GetHeadset();
        }

        public static Transform GetHeadsetCamera()
        {
            return GetHeadsetSDK().GetHeadsetCamera();
        }

        public static Vector3 GetHeadsetVelocity()
        {
            return GetHeadsetSDK().GetHeadsetVelocity();
        }

        public static Vector3 GetHeadsetAngularVelocity()
        {
            return GetHeadsetSDK().GetHeadsetAngularVelocity();
        }

        public static void HeadsetFade(Color color, float duration, bool fadeOverlay = false)
        {
            GetHeadsetSDK().HeadsetFade(color, duration, fadeOverlay);
        }

        public static bool HasHeadsetFade(Transform obj)
        {
            return GetHeadsetSDK().HasHeadsetFade(obj);
        }

        public static void AddHeadsetFade(Transform camera)
        {
            GetHeadsetSDK().AddHeadsetFade(camera);
        }

        #endregion

        #region Boundaries Methods

        public static Transform GetPlayArea()
        {
            return GetBoundariesSDK().GetPlayArea();
        }

        public static Vector3[] GetPlayAreaVertices(GameObject playArea)
        {
            return GetBoundariesSDK().GetPlayAreaVertices(playArea);
        }

        public static float GetPlayAreaBorderThickness(GameObject playArea)
        {
            return GetBoundariesSDK().GetPlayAreaBorderThickness(playArea);
        }

        public static bool IsPlayAreaSizeCalibrated(GameObject playArea)
        {
            return GetBoundariesSDK().IsPlayAreaSizeCalibrated(playArea);
        }

        public static bool GetDrawAtRuntime()
        {
            return GetBoundariesSDK().GetDrawAtRuntime();
        }

        public static void SetDrawAtRuntime(bool value)
        {
            GetBoundariesSDK().SetDrawAtRuntime(value);
        }

        #endregion

        #region System Methods

        public static bool IsDisplayOnDesktop()
        {
            return GetSystemSDK().IsDisplayOnDesktop();
        }

        public static bool ShouldAppRenderWithLowResources()
        {
            return GetSystemSDK().ShouldAppRenderWithLowResources();
        }

        public static void ForceInterleavedReprojectionOn(bool force)
        {
            GetSystemSDK().ForceInterleavedReprojectionOn(force);
        }

        #endregion

        public static SDK_BaseSystem GetSystemSDK()
        {
            if (VRTK_SDKManager.instance != null)
            {
                return VRTK_SDKManager.instance.GetSystemSDK();
            }
            if (systemSDK == null)
            {
                systemSDK = ScriptableObject.CreateInstance<SDK_FallbackSystem>();
            }
            return systemSDK;
        }

        public static SDK_BaseHeadset GetHeadsetSDK()
        {
            if (VRTK_SDKManager.instance != null)
            {
                return VRTK_SDKManager.instance.GetHeadsetSDK();
            }
            if (headsetSDK == null)
            {
                headsetSDK = ScriptableObject.CreateInstance<SDK_FallbackHeadset>();
            }
            return headsetSDK;
        }

        public static SDK_BaseController GetControllerSDK()
        {
            if (VRTK_SDKManager.instance != null)
            {
                return VRTK_SDKManager.instance.GetControllerSDK();
            }
            if (controllerSDK == null)
            {
                controllerSDK = ScriptableObject.CreateInstance<SDK_FallbackController>();
            }
            return controllerSDK;
        }

        public static SDK_BaseBoundaries GetBoundariesSDK()
        {
            if (VRTK_SDKManager.instance != null)
            {
                return VRTK_SDKManager.instance.GetBoundariesSDK();
            }
            if (boundariesSDK == null)
            {
                boundariesSDK = ScriptableObject.CreateInstance<SDK_FallbackBoundaries>();
            }
            return boundariesSDK;
        }

        public static void InvalidateCaches()
        {
#if UNITY_EDITOR
            Object.DestroyImmediate(systemSDK);
            Object.DestroyImmediate(headsetSDK);
            Object.DestroyImmediate(controllerSDK);
            Object.DestroyImmediate(boundariesSDK);
#else
            Object.Destroy(systemSDK);
            Object.Destroy(headsetSDK);
            Object.Destroy(controllerSDK);
            Object.Destroy(boundariesSDK);
#endif

            systemSDK = null;
            headsetSDK = null;
            controllerSDK = null;
            boundariesSDK = null;
        }
    }
}