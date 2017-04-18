namespace VRTK
{
    using UnityEngine;
    using System.Collections;

    public struct VRTKTrackedControllerEventArgs
    {
        public uint currentIndex;
        public uint previousIndex;
    }

    public delegate void VRTKTrackedControllerEventHandler(object sender, VRTKTrackedControllerEventArgs e);

    public class VRTK_TrackedController : MonoBehaviour
    {
        public event VRTKTrackedControllerEventHandler ControllerEnabled;
        public event VRTKTrackedControllerEventHandler ControllerDisabled;
        public event VRTKTrackedControllerEventHandler ControllerIndexChanged;

        protected Coroutine enableControllerCoroutine = null;
        protected GameObject aliasController;
        protected VRTK_ControllerReference controllerReference;

        public virtual void OnControllerEnabled(VRTKTrackedControllerEventArgs e)
        {
            if (controllerReference.IsValid() && ControllerEnabled != null)
            {
                ControllerEnabled(this, e);
            }
        }

        public virtual void OnControllerDisabled(VRTKTrackedControllerEventArgs e)
        {
            if (controllerReference.IsValid() && ControllerDisabled != null)
            {
                ControllerDisabled(this, e);
            }
        }

        public virtual void OnControllerIndexChanged(VRTKTrackedControllerEventArgs e)
        {
            if (controllerReference.IsValid() && ControllerIndexChanged != null)
            {
                ControllerIndexChanged(this, e);
            }
        }

        public virtual VRTK_ControllerReference GetControllerReference()
        {
            return controllerReference;
        }

        protected virtual VRTKTrackedControllerEventArgs SetEventPayload(uint previousIndex = uint.MaxValue)
        {
            VRTKTrackedControllerEventArgs e;
            e.currentIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
            e.previousIndex = previousIndex;
            return e;
        }

        protected virtual void OnEnable()
        {
            aliasController = VRTK_DeviceFinder.GetScriptAliasController(gameObject);
            if (aliasController == null)
            {
                aliasController = gameObject;
            }

            if (enableControllerCoroutine != null)
            {
                StopCoroutine(enableControllerCoroutine);
            }
            enableControllerCoroutine = StartCoroutine(Enable());
        }

        protected virtual void OnDisable()
        {
            Invoke("Disable", 0f);
        }

        protected virtual void Disable()
        {
            if (enableControllerCoroutine != null)
            {
                StopCoroutine(enableControllerCoroutine);
            }

            OnControllerDisabled(SetEventPayload());
        }

        protected virtual void FixedUpdate()
        {
            VRTK_SDK_Bridge.ControllerProcessFixedUpdate(controllerReference);
        }

        protected virtual void Update()
        {
            uint checkIndex = VRTK_DeviceFinder.GetControllerIndex(gameObject);
            if (controllerReference != null && controllerReference.IsValid() && checkIndex != controllerReference.index)
            {
                uint previousIndex = controllerReference.index;
                controllerReference = VRTK_ControllerReference.GetControllerReference(checkIndex);
                OnControllerIndexChanged(SetEventPayload(previousIndex));
            }

            VRTK_SDK_Bridge.ControllerProcessUpdate(controllerReference);

            if (aliasController != null && gameObject.activeInHierarchy && !aliasController.activeSelf)
            {
                aliasController.SetActive(true);
            }
        }

        protected virtual IEnumerator Enable()
        {
            yield return new WaitForEndOfFrame();

            while (!gameObject.activeInHierarchy)
            {
                yield return null;
            }

            controllerReference = VRTK_ControllerReference.GetControllerReference(gameObject);
            OnControllerEnabled(SetEventPayload());
        }
    }
}