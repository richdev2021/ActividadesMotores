using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Utils.AdresableLoader {
    public class AdressableLoader
    {
        public static async UniTask<T> InstantiateAsync<T>(string styleName)
        {
            var task = Addressables.InstantiateAsync(styleName).Task.AsUniTask();
            var asset = await task;
            return asset.GetComponent<T>();
        }
    }
}

