# UnityEditorTcpServer

This creates a simple TCP server in Unity Editor.

## How to use
### Coding
1. Copy `EditorTcpServer.cs` into your Unity project
2. Implement class extending `EditorTcpServer`
   - `Sample/SampleServer.cs` could be your help

### Actual using
1. Open the window you specified by `[MenuItem("Window/WINDOW_NAME")]` attribute
   - If you have no idea, try copying `Sample/SampleServer.cs` and see `Window/SampleServer`
2. Push `Start Server` and the magic works

<img width="732" height="513" alt="image" src="https://github.com/user-attachments/assets/92171120-8a7d-4475-b248-01bc7f4bae06" />
