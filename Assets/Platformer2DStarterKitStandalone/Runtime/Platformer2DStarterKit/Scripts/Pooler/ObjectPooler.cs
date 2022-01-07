using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public interface IPooler<out T> where T : Component {
        T Get();
        IEnumerable<T> CreatedPrefabs { get; }
        System.Type PoolType { get; }
    }
    public class Pooler<T> : IPooler<T> where T : Component {
        public T Prefab;
        public System.Type PoolType => typeof(T);

        private readonly HashSet<T> createdPrefabs = new HashSet<T>();
        public IEnumerable<T> CreatedPrefabs => createdPrefabs;
        public IEnumerable<T> GetActivePrefabs() {
            foreach (T t in createdPrefabs) {
                if (t.gameObject.activeSelf)
                    yield return t;
            }
        }

        public T Get() {
            foreach (T item in createdPrefabs) {
                if (!item.gameObject.activeSelf)
                    return item;
            }
            T newPrefab = InstantiatePrefab();
            createdPrefabs.Add(newPrefab);
            return newPrefab;
        }

        protected virtual T InstantiatePrefab() {
            return Object.Instantiate(Prefab);
        }
    }
    public class ObjectPooler<T> : MonoBehaviour, IPooler<T> where T : Component {
        public T Prefab;
        public System.Type PoolType => typeof(T);

        private readonly HashSet<T> createdPrefabs = new HashSet<T>();
        public IEnumerable<T> CreatedPrefabs => createdPrefabs;
        public IEnumerable<T> GetActivePrefabs() {
            foreach (T t in createdPrefabs) {
                if (t.gameObject.activeSelf)
                    yield return t;
            }
        }

        public T Get() {
            foreach (T item in createdPrefabs) {
                if (!item.gameObject.activeSelf)
                    return item;
            }
            T newPrefab = InstantiatePrefab();
            createdPrefabs.Add(newPrefab);
            return newPrefab;
        }

        protected virtual T InstantiatePrefab() {
            return Instantiate(Prefab);
        }

    }
}
