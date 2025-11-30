namespace Dibware.F.In.Manufacturing.Domain.Types.Materials_Alternative_Brian

(*
Source - https://stackoverflow.com/a/79833562
Posted by Brian Berns, modified by community. See post 'Timeline' for change history
Retrieved 2025-11-30, License - CC BY-SA 4.0
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

type Rock =
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
    | SomeOtherIngot

type Lumber = Planks

type RefinedMaterial =
    | RefinedIngot of Ingot
    | RefinedLumber of Lumber

type Material =
    | Raw of RawMaterial
    | Refined of RefinedMaterial
