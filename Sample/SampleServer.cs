#if UNITY_EDITOR

using UnityEditor;

namespace EditorTcpServer.Sample
{
    public class SampleServer : EditorTcpServer
    {
        [MenuItem("Window/Sample TCP Server")]
        public static void ShowWindow()
        {
            GetWindow<SampleServer>("Sample TCP Server");
        }

        public override string ProcessRequest(string request)
        {
            return $"Dummy: {request}";
        }

        protected override void OnGUI()
        {
            base.OnGUI();

            // whatever
        }
    }
}

#endif
