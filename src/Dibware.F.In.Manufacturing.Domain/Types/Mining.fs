namespace Dibware.F.In.Manufacturing.Domain.Types.Mining

/// <summary>
/// Describes different types of rocks that contain ores.
/// </summary>
type Rock = 
    | IronImpregnatedRock   // Contains iron ore
    | CoalImpregnatedRock   // Contains coal
    | CopperImpregnatedRock // Contains copper ore
    | GasShale              // Sedimentary rock that contains natural gas
    | OilShale              // Sedimentary rock that contains oil 
    | Spoil                 // Waste rock removed during mining
    | Useless               // Rock that does not contain any ore.or substance of value
    | VoidOfAnyRock         // Absence of rock, e.g., in a tunnel or cavern, or where rock has been already mined

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