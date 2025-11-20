#if UNITY_EDITOR

using System.Threading.Tasks;
using UnityEditor;

namespace UnityEditorTcpServer.Sample
{
    public class SampleServer : EditorTcpServer
    {
        [MenuItem("Window/Sample TCP Server")]
        public static void ShowWindow()
        {
            GetWindow<SampleServer>("Sample TCP Server");
        }

        public override Task<string> ProcessRequest(string request)
        {
            // convert your original result to Task type by `Task.FromResult()`
            return Task.FromResult($"Dummy: {request}");
        }

        protected override void OnGUI()
        {
            base.OnGUI();

            // whatever
        }
    }
}

#endif
