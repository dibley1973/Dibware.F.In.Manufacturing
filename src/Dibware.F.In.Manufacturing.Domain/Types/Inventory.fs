namespace Dibware.F.In.Manufacturing.Domain.Types

open Dibware.F.In.Manufacturing.Domain.Types.Mining
open Dibware.F.In.Manufacturing.Domain.Types.Materials

type InventoryItem =
    | Rock of Rock
    | Ore of Ore
    | Raw of RawMaterial
    | Processed of ProcessedMaterial
    | ComponentItem of Component