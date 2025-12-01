namespace Dibware.F.In.Manufacturing.Domain.Types.ProcessingPlants

/// <summary>
/// Describes plant that Smelts ores into processed materials.
/// </summary>
type SmeltingPlant = 
    | IronOreSmelter

/// <summary>
/// Describes plants that Mill processed materials into finished goods.
/// </summary>
type MillingPlant =
    | AlluminiumMill
    | SteelMill