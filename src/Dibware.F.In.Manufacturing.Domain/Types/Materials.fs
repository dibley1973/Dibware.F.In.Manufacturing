namespace Dibware.F.In.Manufacturing.Domain.Types.Materials

(*
This is a modified version of my origianlal material type definitions, created
from a suggestion by Brian Berns, and shared on Stack Overflow.
Source - https://stackoverflow.com/a/79833562
Posted by Brian Berns, modified by community. See post 'Timeline' for change history
*)

type Ore =
    | IronOre
    | Coal
    | CopperOre
    | GoldOre
    | SilverOre

type Oil = CrudeOil

type Gas = NaturalGas

type Timber = Logs

type RawMaterial =
    | RawOre of Ore
    | RawOil of Oil
    | RawGas of Gas
    | RawTimber of Timber

type Ground =
    | IronImpregnatedRock
    | CoalImpregnatedRock
    | CopperImpregnatedRock
    | GasShale
    | OilShale
    | Spoil
    | Useless
    | VoidOfAnyRock

type Ingot =
    | IronIngot
    | SteelIngot

type Lumber = Planks

type Sheet =
    | IronSheet
    | SteelSheet

type ProcessedMaterial = 
    | IronSheet of Sheet
    | SteelSheet of Sheet

type RefinedMaterial =
    | RefinedIngot of Ingot
    | RefinedLumber of Lumber

type Material =
    | Raw of RawMaterial
    | Refined of RefinedMaterial
    | Rock of Ground
