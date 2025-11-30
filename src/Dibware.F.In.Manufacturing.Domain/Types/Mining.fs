namespace Dibware.F.In.Manufacturing.Domain.Types.Mining

//open Dibware.F.In.Manufacturing.Domain.Types.Materials

/// <summary>
/// Describes different types of rocks that contain ores.
/// </summary>
type Rock = 
    | IronImpregnatedRock   //of Material // Contains iron ore
    | CoalImpregnatedRock   //of Material // Contains coal
    | CopperImpregnatedRock //of Material // Contains copper ore
    | GasShale              //of Material // Sedimentary rock that contains natural gas
    | OilShale              //of Material // Sedimentary rock that contains oil 
    | Spoil                 //of Material // Waste rock removed during mining
    | Useless               //of Material // Rock that does not contain any ore.or substance of value
    | VoidOfAnyRock         //of Material // Absence of rock, e.g., in a tunnel or cavern, or where rock has been already mined

/// <summary>
/// Describes different types of ores used as raw materials.
/// </summary>
type Ore =
    | IronOre     // of Ore 
    | Coal        //of Material 
    | CopperOre   //of Material 
    | AluminumOre //of Material 
    | GoldOre     //of Material
    | SilverOre   //of Material 

/// <summary>
/// Describes a mining operation that extracts raw materials from the earth.
/// </summary>
type Mine = 
    /// <summary>
    /// A surface mine where minerals are extracted from an open pit.
    /// </summary>
    | OpenPitMine

    /// <summary>
    /// An underground mine where minerals are extracted through tunnels.
    /// </summary>
    | UndergroundShaftMine
    
    /// <summary>
    /// A "mine" that extracts oil or natural gas through drilling.
    /// </summary>
    | DrillingRig