namespace Dibware.F.In.Manufacturing.Domain.Types.Materials

module DeleteMeLater =
    let x = 42
(*
This module is to be deleted later.
It contains material type definitions that
are to be replaced by the alternative
material type definitions provided
by Brian Berns.
*)

///// <summary>
///// Describes the base for any material used in manufacturing.
///// </summary>
//type Material = {
//    /// <summary>
//    /// The name of the material
//    /// </summary>
//    Name: string
//}

///// <summary>
///// Describes the type of raw, unprocessed material
///// </summary>
//type RawMaterial =
//    | Ore    //of Material
//        //| IronOre //of Material
//        //| Coal    //of Material
//        //| CopperOre of Material
//        //| AluminumOre of Material
//        //| GoldOre of Material
//        //| SilverOre of Material
//    | Oil    of Material
//        | CrudeOil of Material
//    | Gas    of Material
//        | NaturalGas of Material
//    | Timber of Material
//        | Logs of Material

///// <summary>
///// Describes the type of processed / refined material
///// </summary>
//type PrimaryMaterialType =
//    | MetalIngot of Material
//    | PlasticPellets of Material
//    | Logs of Material
//    | CompositeFibers of Material

///// <summary>
///// Describes plant that Smelts ores into processed materials.
///// </summary>
//type SmeltingPlant = 
//    | IronOreSmelter

///// <summary>
///// Describes a processed material used in manufacturing.
///// </summary>
//type ProcessedMaterial =
//    | Iron of Material
//    | Steel of Material
//    | Plastic of Material

///// <summary>
///// Describes a component manufacturedfrom processed materials.
///// </summary>
//type BasicComponent = {
//    Name: string
//    Materials: ProcessedMaterial list
//}

//type AssembledComponent = {
//    Name: string
//    SubComponents: BasicComponent list
//}

//type Component =
//    | Basic of BasicComponent
//    | Assembled of AssembledComponent


//type Product = {
//    Name: string
//    Components: Component list
//}

//type MaterialType =
//    | Metal
//    | Plastic
//    | Wood
//    | Composite

//type MetalIngotType =
//    | IronIngot // of ProcessedMaterialType.MetalIngot
//    | SteelIngot //of ProcessedMaterialType.MetalIngot