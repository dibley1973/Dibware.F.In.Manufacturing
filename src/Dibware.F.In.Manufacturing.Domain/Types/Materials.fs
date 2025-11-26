namespace Dibware.F.In.Manufacturing.Domain.Types.Materials

/// <summary>
/// Describes a raw, unprocessed material used in manufacturing.
/// </summary>
type RawMaterial = {
    /// <summary>
    /// The name of the material
    /// </summary>
    Name: string
}

/// <summary>
/// Describes the type of raw, unprocessed material
/// </summary>
type RawMaterialType =
    | Ore //of Ore
    | Oil
    | Gas
    | Lumber

/// <summary>
/// Describes the type of processed / refined material
/// </summary>
type ProcessedMaterialType =
    | MetalIngot
    | PlasticPellets
    | WoodPlanks
    | CompositeFibers

/// <summary>
/// Describes plant that Smelts ores into processed materials.
/// </summary>
type SmeltingPlant = 
    | IronOreSmelter

/// <summary>
/// Describes a material that can be used in manufacturing, which can be either raw or processed / refined.
/// </summary>
type Material = { Name : string }

/// <summary>
/// Describes a processed material used in manufacturing.
/// </summary>
type ProcessedMaterial =
    | Iron of Material
    | Steel of Material
    | Plastic of Material

/// <summary>
/// Describes a component manufacturedfrom processed materials.
/// </summary>
type BasicComponent = {
    Name: string
    Materials: ProcessedMaterial list
}

type AssembledComponent = {
    Name: string
    SubComponents: BasicComponent list
}

type Component =
    | Basic of BasicComponent
    | Assembled of AssembledComponent


type Product = {
    Name: string
    Components: Component list
}

type MaterialType =
    | Metal
    | Plastic
    | Wood
    | Composite