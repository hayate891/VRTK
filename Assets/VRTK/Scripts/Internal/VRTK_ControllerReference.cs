namespace VRTK
{
    using UnityEngine;
    using System;
    using System.Collections.Generic;

    public class VRTK_ControllerReference : IEquatable<VRTK_ControllerReference>
    {
        public static Dictionary<GameObject, VRTK_ControllerReference> controllerReferences = new Dictionary<GameObject, VRTK_ControllerReference>();

        public static VRTK_ControllerReference GetControllerReference(uint controllerIndex)
        {
            if (controllerIndex < uint.MaxValue)
            {
                GameObject scriptAlias = VRTK_SDK_Bridge.GetControllerByIndex(controllerIndex, false);
                if (scriptAlias != null)
                {
                    if (controllerReferences.ContainsKey(scriptAlias))
                    {
                        return controllerReferences[scriptAlias];
                    }
                    return new VRTK_ControllerReference(scriptAlias);
                }
            }
            return null;
        }

        public static VRTK_ControllerReference GetControllerReference(GameObject controllerObject)
        {
            GameObject scriptAlias = null;
            uint controllerIndex = VRTK_SDK_Bridge.GetControllerIndex(controllerObject);
            if (controllerIndex < uint.MaxValue)
            {
                //Get the actual script alias of the given object
                scriptAlias = VRTK_SDK_Bridge.GetControllerByIndex(controllerIndex, false);
            }

            //if the script alias is still null, then try and get it from the model object
            scriptAlias = (scriptAlias == null ? GetScriptAliasFromHand(VRTK_SDK_Bridge.GetControllerModelHand(controllerObject)) : scriptAlias);
            if (scriptAlias != null)
            {
                if (controllerReferences.ContainsKey(scriptAlias))
                {
                    return controllerReferences[scriptAlias];
                }
                return new VRTK_ControllerReference(scriptAlias);
            }

            return null;
        }

        public static VRTK_ControllerReference GetControllerReference(SDK_BaseController.ControllerHand controllerHand)
        {
            GameObject scriptAlias = GetScriptAliasFromHand(controllerHand);
            if (scriptAlias != null)
            {
                if (controllerReferences.ContainsKey(scriptAlias))
                {
                    return controllerReferences[scriptAlias];
                }
                return new VRTK_ControllerReference(scriptAlias);
            }
            return null;
        }

        public static uint GetRealIndex(VRTK_ControllerReference controllerReference)
        {
            return (controllerReference != null ? controllerReference.index : uint.MaxValue);
        }

        protected SDK_BaseController.ControllerHand storedHand;
        protected GameObject storedControllerScriptAlias;

        public VRTK_ControllerReference(uint controllerIndex) : this(VRTK_SDK_Bridge.GetControllerByIndex(controllerIndex, false))
        {
        }

        public VRTK_ControllerReference(GameObject controllerObject) : this(GetControllerHand(controllerObject))
        {
            uint controllerIndex = VRTK_SDK_Bridge.GetControllerIndex(controllerObject);
            if (controllerIndex < uint.MaxValue)
            {
                //store the actual script alias of the given object
                storedControllerScriptAlias = VRTK_SDK_Bridge.GetControllerByIndex(controllerIndex, false);
            }

            //if the script alias is still null, then check to see if the given object is a model and try and get it from that.
            storedControllerScriptAlias = (storedControllerScriptAlias == null ? GetScriptAliasFromHand(VRTK_SDK_Bridge.GetControllerModelHand(controllerObject)) : storedControllerScriptAlias);
            if (storedControllerScriptAlias != null)
            {
                AddToCache();
            }
        }

        public VRTK_ControllerReference(SDK_BaseController.ControllerHand controllerHand)
        {
            storedHand = controllerHand;
            storedControllerScriptAlias = (storedControllerScriptAlias == null ? GetScriptAliasFromHand(storedHand) : storedControllerScriptAlias);
            AddToCache();
        }

        public uint index
        {
            get
            {
                return VRTK_SDK_Bridge.GetControllerIndex(GetScriptAlias());
            }
        }

        public GameObject scriptAlias
        {
            get
            {
                return GetScriptAlias();
            }
        }

        public GameObject actual
        {
            get
            {
                uint controllerIndex = VRTK_SDK_Bridge.GetControllerIndex(GetScriptAlias());
                return VRTK_SDK_Bridge.GetControllerByIndex(controllerIndex, true);
            }
        }

        public GameObject model
        {
            get
            {
                return VRTK_SDK_Bridge.GetControllerModel(GetScriptAlias());
            }
        }

        public SDK_BaseController.ControllerHand hand
        {
            get
            {
                return storedHand;
            }
        }

        public bool IsValid()
        {
            return (index < uint.MaxValue);
        }

        public override int GetHashCode()
        {
            return (int)index;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            VRTK_ControllerReference objAsPart = obj as VRTK_ControllerReference;
            if (objAsPart == null)
            {
                return false;
            }
            else
            {
                return Equals(objAsPart);
            }
        }

        public bool Equals(VRTK_ControllerReference other)
        {
            if (other == null)
            {
                return false;
            }
            return (index.Equals(other.index));
        }

        protected virtual GameObject GetScriptAlias()
        {
            GameObject checkObject = GetScriptAliasFromHand(storedHand);
            return (checkObject == null ? storedControllerScriptAlias : checkObject);
        }

        protected virtual void AddToCache()
        {
            if (storedControllerScriptAlias != null && controllerReferences.ContainsKey(storedControllerScriptAlias))
            {
                controllerReferences.Remove(storedControllerScriptAlias);
            }

            if (storedControllerScriptAlias != null && !controllerReferences.ContainsKey(storedControllerScriptAlias))
            {
                controllerReferences.Add(storedControllerScriptAlias, this);
            }
        }

        private static GameObject GetScriptAliasFromHand(SDK_BaseController.ControllerHand controllerHand)
        {
            switch (controllerHand)
            {
                case SDK_BaseController.ControllerHand.Left:
                    return VRTK_SDK_Bridge.GetControllerLeftHand(false);
                case SDK_BaseController.ControllerHand.Right:
                    return VRTK_SDK_Bridge.GetControllerRightHand(false);
            }
            return null;
        }

        private static SDK_BaseController.ControllerHand GetControllerHand(GameObject controllerObject)
        {
            if (VRTK_SDK_Bridge.IsControllerLeftHand(controllerObject))
            {
                return SDK_BaseController.ControllerHand.Left;
            }
            else if (VRTK_SDK_Bridge.IsControllerRightHand(controllerObject))
            {
                return SDK_BaseController.ControllerHand.Right;
            }
            return VRTK_SDK_Bridge.GetControllerModelHand(controllerObject);
        }
    }
}