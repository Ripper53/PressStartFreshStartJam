using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class PoolerRepository : MonoBehaviour {
        private readonly Dictionary<System.Type, Dictionary<string, IPooler<Component>>> dict = new Dictionary<System.Type, Dictionary<string, IPooler<Component>>>();

        public IPooler<T> Get<T>(string tag) where T : Component {
            return (IPooler<T>)dict[typeof(T)][tag];
        }

        public void Add<T>(string tag, IPooler<Component> value) where T : Component {
            Add(typeof(T), tag, value);
        }

        public void Add(System.Type type, string tag, IPooler<Component> value) {
            if (!dict.ContainsKey(type))
                dict.Add(type, new Dictionary<string, IPooler<Component>>(1));

            dict[type].Add(tag, value);
        }

    }
}
