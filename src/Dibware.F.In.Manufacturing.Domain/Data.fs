namespace Dibware.F.In.Manufacturing.Domain.Data

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
    | Ore
    | Oil
    | Gas
    | Lumber

/// <summary>
/// Describes a material that can be used in manufacturing, which can be either raw or processed / refined.
/// </summary>
type ProcessedMaterial = {
    Name: string
}

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