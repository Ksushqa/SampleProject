using System.Collections.Generic;
using Modules.ResourcesModule.Providers;
using UnityEditor;
using UnityEngine;

namespace Modules.ResourcesModule.Editor
{
    [CustomEditor(typeof(ResourcesCollection))]
    public class ResourcesCollectionEditor : UnityEditor.Editor
    {
        private readonly List<ResourceReferenceDrawer> _referenceDrawers = new List<ResourceReferenceDrawer>();
        
        private bool _isFoldoutOpened;
        private int _arraySize;

        public override void OnInspectorGUI()
        {
            var resources = serializedObject.FindProperty("_resources");

            if (_arraySize == 0 && resources.arraySize > 0)
            {
                _arraySize = resources.arraySize;
                
                for (var i = 0; i < _arraySize; i++)
                {
                    resources.InsertArrayElementAtIndex(resources.arraySize);
                    var resource = resources.GetArrayElementAtIndex(i);
                    var resourceDrawer = new ResourceReferenceDrawer(resource, i);
                    _referenceDrawers.Add(resourceDrawer);
                }
            }

            if (_arraySize != resources.arraySize)
            {
                _referenceDrawers.Clear();

                for (var i = 0; i < _arraySize; i++)
                {
                    if (i <= resources.arraySize)
                    {
                        resources.InsertArrayElementAtIndex(resources.arraySize);
                        var resource = resources.GetArrayElementAtIndex(i);
                        var resourceDrawer = new ResourceReferenceDrawer(resource, i);
                        _referenceDrawers.Add(resourceDrawer);
                    }
                    else
                    {
                        resources.DeleteArrayElementAtIndex(i);

                        if (_referenceDrawers.Count > 0)
                        {
                            _referenceDrawers.RemoveAt(_referenceDrawers.Count - 1);
                        }
                    }
                }
            }

            resources.arraySize = _arraySize;

            var size = GetClampedSize(_arraySize);
            _arraySize = GetClampedSize(EditorGUILayout.IntField("Collection size", size));

            if (_referenceDrawers.Count > 0)
            {
                for (var i = 0; i < resources.arraySize; i++)
                {
                    _referenceDrawers[i].Draw();
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        private int GetClampedSize(int value)
        {
            return Mathf.Clamp(value, 0, value);
        }
    }
}