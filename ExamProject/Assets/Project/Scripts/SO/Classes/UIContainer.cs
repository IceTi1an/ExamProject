using Game.UI;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Lists/Containers", fileName = "UIContainer")]

    public class UIContainer : ScriptableObject
    {
        public List<UIBase> uis;

        public UIBase GetUI(string uiName)
        {
            UIBase result = uis.Find(ui => ui.name.Contains(uiName));
            return result;
        }
    }
}