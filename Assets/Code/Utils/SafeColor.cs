
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SafeColor : Singleton<SafeColor>
{
    
    [System.Serializable]
    public class  DictionColor
    {
        public TypeColor type;
        public Color color;
    }

    public List<DictionColor> _listColor = new();


    public Color GetColorByType(TypeColor typeColor)
    {
        return _listColor.FirstOrDefault(x => x.type == typeColor).color;
    }
    
    
    
}

public enum TypeColor
{
    none,
    white,
    black,
    heightlight,
    hlenemyy
}


