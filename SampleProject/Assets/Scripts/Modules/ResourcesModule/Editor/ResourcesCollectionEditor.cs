using System.Collections.Generic;
using Modules.ResourcesModule.Providers;
using UnityEditor;

namespace Modules.ResourcesModule.Editor
{
    [CustomEditor(typeof(ResourcesCollection))]
    public class ResourcesCollectionEditor : UnityEditor.Editor
    {
        private readonly List<ResourceReferenceDrawer> _referenceDrawers = new List<ResourceReferenceDrawer>();
        
        private bool _isFoldoutOpened;
        
        public override void OnInspectorGUI()
        {
            var resources = serializedObject.FindProperty("_resources");

            if (_referenceDrawers.Count < resources.arraySize)
            {
                for (var i = _referenceDrawers.Count; i < resources.arraySize; i++)
                {
                    var resource = resources.GetArrayElementAtIndex(i);
                    var resourceDrawer = new ResourceReferenceDrawer(resource, i);
                    _referenceDrawers.Add(resourceDrawer);
                }
            }

            //_isFoldoutOpened = EditorGUILayout.Foldout(_isFoldoutOpened, "Resources Collection");
            //if (_isFoldoutOpened)
            {
                for (var i = 0; i < resources.arraySize; i++)
                {
                    _referenceDrawers[i].Draw();
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}