using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "PrefabDictionary", menuName = "DkIT/Scriptable Objects/Assets/Prefabs/PrefabDictionary", order = 1)]
    public class PrefabDictionary : ScriptableGameObject
    {
        [Tooltip("Relative folder path under Assets")]
        [Required]
        [InlineButton("LoadPrefabs", "Load Prefabs", Icon = SdfIconType.PersonBoundingBox)]
        [FolderPath(ParentFolder = "Assets", RequireExistingPath = true)]
        public string FolderPath;

        [Tooltip("Stores <GUID, object dictionary> for all GameObjects within a user-defined folder")]
        public Dictionary<string, GameObject> Prefabs;

        public void LoadPrefabs()
        {
            CheckErrors();
            List<GameObject> prefabList = AssetLoader.FindPrefabs("Assets/" + FolderPath, "t:Prefab");

            foreach (GameObject prefab in prefabList)
                Prefabs.TryAdd(prefab.name, prefab);
        }

        protected void CheckErrors()
        {
            if (FolderPath == null || FolderPath.Length == 0)
                return;

            if (Prefabs == null)
                Prefabs = new Dictionary<string, GameObject>();

            if (Prefabs.Count > 0)
                Prefabs.Clear();
        }
    }
}