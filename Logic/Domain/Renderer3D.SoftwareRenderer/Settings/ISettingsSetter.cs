using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Settings;

internal interface ISettingsSetter
{
    Settings Set(RenderSettings settings, Settings container);
}
