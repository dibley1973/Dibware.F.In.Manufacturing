namespace Dibware.F.In.Manufacturing.Domain.Types.Materials

/// <summary>
/// Describes the base for any material used in manufacturing.
/// </summary>
type Material = {
    /// <summary>
    /// The name of the material
    /// </summary>
    Name: string
}

//type Mat(name: string) 
//    
//type Rmat() =
//    inherit Mat()

//// Level 2
//type Raw2Material = Raw2Material of Material
//type Processed2Material = Processed2Material of Material
//type Rock2 = Rock2 of Raw2Material

//type Timber2 = Timber2 of Raw2Material

//type Ore2 = Ore2 of Raw2Material
//type Oil2 = Oil2 of Raw2Material
//type Gas2 = Gas2 of Raw2Material
//type IronOre2 = IronOre2 of Ore2
//type Coal2 = Coal2 of Ore2

//type O2 =
//    | IronOre2 of Ore2
//    | Coal2 of Ore2
//    | CopperOre2 of Ore2


/// <summary>
/// Describes the type of raw, unprocessed material
/// </summary>
type RawMaterial =
    | Ore    //of Material
        //| IronOre //of Material
        //| Coal    //of Material
        //| CopperOre of Material
        //| AluminumOre of Material
        //| GoldOre of Material
        //| SilverOre of Material
    | Oil    of Material
        | CrudeOil of Material
    | Gas    of Material
        | NaturalGas of Material
    | Timber of Material
        | Logs of Material

/// <summary>
/// Describes the type of processed / refined material
/// </summary>
type PrimaryMaterialType =
    | MetalIngot of Material
    | PlasticPellets of Material
    | Logs of Material
    | CompositeFibers of Material

/// <summary>
/// Describes plant that Smelts ores into processed materials.
/// </summary>
type SmeltingPlant = 
    | IronOreSmelter

///// <summary>
///// Describes a material that can be used in manufacturing, which can be either raw or processed / refined.
///// </summary>
//type Material = { Name : string }

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

type MetalIngotType =
    | IronIngot // of ProcessedMaterialType.MetalIngot
    | SteelIngot //of ProcessedMaterialType.MetalIngot