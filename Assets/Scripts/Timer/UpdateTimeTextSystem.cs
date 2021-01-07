using System;
using TMPro;
using Unity.Entities;

public class UpdateTimeTextSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities
            .WithoutBurst()
            .ForEach((in TextMeshProUGUI text, in TimeComponent time) =>
        {
            text.text = TimeSpan.FromSeconds(time.Time).ToString(@"mm\:ss\:fff");
        }).Run();
    }
}
