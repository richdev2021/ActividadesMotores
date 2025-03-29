using System.Net;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace DefaultNamespace.Utils.DataApi
{
    public struct GraphQLQuery
    {
        public string query;
        public object variables;
    }
    public class GraphQLUtils
    {
        private const string URL = "https://localhost:4000/graphql";
        private const string requestName = "Content-Type";
        private const string requestType = "aplication/json";
        public JObject GetData(JObject data) => data == null ? null: JObject.Parse(data["data"].ToString());
        
        public async UniTask<T> GetModel<T>(GraphQLQuery query,string queryName ,CancellationToken token)
        {
            var webRequest = new UnityWebRequest(URL, UnityWebRequest.kHttpVerbPOST);
            var json = JsonConvert.SerializeObject(query);
            var payload = Encoding.UTF8.GetBytes(json);
            webRequest.uploadHandler = new UploadHandlerRaw(payload);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader(requestName,requestType);
            await webRequest.SendWebRequest().WithCancellation(token);
            T modelData = default;

            if (webRequest.result != UnityWebRequest.Result.Success) return modelData;
            var dataObject = JObject.Parse(webRequest.downloadHandler.text);
            modelData = JsonUtility.FromJson<T>(GetData(dataObject)[queryName]?.ToString());
            

            return modelData;
        }
    }
}