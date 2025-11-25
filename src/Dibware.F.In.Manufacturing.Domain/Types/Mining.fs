namespace Dibware.F.In.Manufacturing.Domain.Types.Mining

/// <summary>
/// Describes different types of rocks that contain ores.
/// </summary>
type Rock = 
    | IronImpregnatedRock
    | CoalimpregnatedRock
    | CopperImpregnatedRock
    | Shale

/// <summary>
/// Describes different types of ores used as raw materials.
/// </summary>
type Ore = 
    | IronOre
    | Coal
    | CopperOre
    | AluminumOre
    | GoldOre
    | SilverOre

/// <summary>
/// Describes a mining operation that extracts raw materials from the earth.
/// </summary>
type Mine = 
    | CoalMine
    | CopperMine
    | IronOreMine