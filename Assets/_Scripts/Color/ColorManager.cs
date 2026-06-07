using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using core.Singleton;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<colorSetup> colorSetups;

    public void ChangeColorByType(ArtManager.ArtType artType)
    {
       var setup = colorSetups.Find(i => i.artType == artType);

        for(int i = 0; i < materials.Count; i++)
        {
            materials[i].SetColor("_Color", setup.colors[i]);
        }
    }
}

[System.Serializable]
public class colorSetup
{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}
