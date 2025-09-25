using AltTester.AltTesterSDK.Driver;
using AltTester.AltTesterUnitySDK.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AltTester.BuildScripts
{
    public class UnityCloudBuildScript
    {
        public static void OnPreExportWindows()
        {
            Debug.Log("Unity Cloud Build - OnPreExportWindows called");

            var buildTargetGroup = BuildTargetGroup.Standalone;

            if (buildTargetGroup == UnityEditor.BuildTargetGroup.Standalone)
            {
                AltBuilder.CreateJsonFileForInputMappingOfAxis();
            }
            var instrumentationSettings = new AltInstrumentationSettings();
            instrumentationSettings.AltServerHost = "127.0.0.1";
            instrumentationSettings.AltServerPort = 13000;
            instrumentationSettings.AppName = "__default__";
            instrumentationSettings.ResetConnectionData = true;
            AltBuilder.InsertAltInScene("Assets/Scenes/SampleScene.unity", instrumentationSettings);
        }
    }
}

