using System.Collections;
using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.View;
using PoundSimulator.Controllers;
using PoundSimulator.View;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace PoundSimulator
{
    public class test : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var view = Load<GameObject>(nameof(MenuController));
           

        }

        public TResource Load<TResource>(string key) where TResource : Object
        {
            var asyncOperationHandle = Addressables.LoadAssetAsync<TResource>(key);
            return asyncOperationHandle.WaitForCompletion();
        }
    }
}
