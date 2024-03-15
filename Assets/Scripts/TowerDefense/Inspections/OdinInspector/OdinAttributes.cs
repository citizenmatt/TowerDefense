using Sirenix.OdinInspector;
using UnityEngine;

namespace TowerDefense.Inspections.OdinInspector
{
    public class OdinAttributes : MonoBehaviour
    {
        // Code completion of group names
        [TabGroup("MainTab")] public string mainTabLabel;
        [TabGroup("SecondaryTab")] public string secondaryTabLabel;
        
        // Code completion of full path
        [BoxGroup("_DefaultTabGroup/MainTab/BoxGroup01")]
        private int x = 5;

        // Inspection for unknown group name
        [BoxGroup("_DefaultTabGroup/MainTab/BoxGroup02/NestedGroup")]
        private int y = 10;

        
        // Inspection for different group types for the same group path
        // Quick fix to convert to first group type attribute
        [BoxGroup("_DefaultTabGroup/MainTab/BoxGroup01/NestedGroup")]
        private int x1 = 5;

        [VerticalGroup("_DefaultTabGroup/MainTab/BoxGroup01/NestedGroup")]
        private int y1 = 5;
    }

    public class ColourAttributes : MonoBehaviour
    {
        // Colour highlighting, plus alt+enter colour picker
        [GUIColor("#F939C5")] 
        [BoxGroup("MainGroup")]
        private int x = 4;
    }

    public class ReferencingMembers : MonoBehaviour
    {
        // Completion after '$', Go To Definition, Find Usages, Rename of value
        [TitleGroup("$importantString")] 
        public string importantString;

        public string Something()
        {
            return importantString;
        }
    }

    public class FilePathCompletion : MonoBehaviour
    {
        [FilePath(ParentFolder = "Assets/Documentation")]
        public string relativeToParent;
        
        [FolderPath(ParentFolder = "Assets/Materials")]
        public string folderPath;
    }

    public class IntValueAnalysis : MonoBehaviour
    {
        [MaxValue(10)]
        public int lessThanTen;

        public void Example()
        {
            // MaxValue attribute tells Rider that the value can't be greater than 10
            if (lessThanTen > 20)
            {
                // ...
            }
        }
    }
}