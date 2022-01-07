using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer2DStarterKit {
    public abstract class PlayerControls<T> : MonoBehaviour where T : IInputActionCollection, IDisposable, new() {
        private T input;

        private void Awake() {
            input = new T();
            AddListener(input);
        }
        private void OnDestroy() {
            RemoveListener(input);
            input.Dispose();
        }

        private void OnEnable() => input.Enable();
        private void OnDisable() => input.Disable();

        protected abstract void AddListener(T input);
        protected abstract void RemoveListener(T input);

    }
}
