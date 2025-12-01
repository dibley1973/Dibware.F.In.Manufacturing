namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Dibware.F.In.Manufacturing.Domain.Types.ProcessingPlants
open Dibware.F.In.Manufacturing.Domain.Behaviours.Operations
open Dibware.F.In.Manufacturing.Domain.Types.Recipies.Metals
open Dibware.F.In.Manufacturing.Domain.Types.Manufacturing
open Dibware.F.In.Manufacturing.Domain.Types.Materials
open Dibware.F.In.Manufacturing.Domain.Types.Mining

/// <summary>
/// Tests for "Alloying" behaviour
/// </summary>
[<TestClass>]
type AlloyingTests () =

    let ironIngot = IronIngot |> RefinedIngot |> Refined
    let coal = Ore.Coal |> RawOre |> Raw
    let aluminaPowder = Powder.AluminaPowder |> RefinedPowder |> Refined
    let causticSoda = Chemical.CausticSoda |> SynthesizedChemical |> Chemical

    [<TestMethod>]
    member this.tryMakeSteelIngot_WhenGivenIncorrectMill_ReturnsNone () =
        // Arrange
        let incorrectMill = MillingPlant.AlluminiumMill
        let recipe = Alloying.steelRecipe
        let materialList = MaterialList [ (ironIngot, 2); (coal, 1) ]

        // Act
        let actual = Alloying.tryMakeSteelIngot incorrectMill recipe materialList

        // Assert
        Assert.IsTrue(actual.IsNone)

    [<TestMethod>]
    member this.tryMakeSteelIngot_WhenGivenIncorrectRecipe_ReturnsNone () =
        let millingPlant = MillingPlant.SteelMill
        let incorrectRecipe = Alloying.aluminiumRecipe
        let materialList = MaterialList [ (ironIngot, 2); (coal, 1) ]

        // Act
        let actual = Alloying.tryMakeSteelIngot millingPlant incorrectRecipe materialList

        // Assert
        Assert.IsTrue(actual.IsNone)

    [<TestMethod>]
    member this.tryMakeSteelIngot_WhenGivenIncorrectMateialList_ReturnsNone () =
        let millingPlant = MillingPlant.SteelMill
        let recipe = Alloying.steelRecipe
        let incorrectMaterialList = MaterialList [ (aluminaPowder, 3); (causticSoda, 1) ]

        // Act
        let actual = Alloying.tryMakeSteelIngot millingPlant recipe incorrectMaterialList

        // Assert
        Assert.IsTrue(actual.IsNone)

    [<TestMethod>]
    member this.tryMakeSteelIngot_WhenGivenEmptyMateialList_ReturnsNone () =
        let millingPlant = MillingPlant.SteelMill
        let recipe = Alloying.steelRecipe
        let emptyMaterialList = Map.empty

        // Act
        let actual = Alloying.tryMakeSteelIngot millingPlant recipe emptyMaterialList

        // Assert
        Assert.IsTrue(actual.IsNone)

    [<TestMethod>]
    member this.tryMakeSteelIngot_WhenInputsAreCorrect_ReturnsSteelIngot() =
        let millingPlant = MillingPlant.SteelMill
        let recipe = Alloying.steelRecipe
        let materialList = MaterialList [ (ironIngot, 2); (coal, 1) ]

        // Act
        let actual = Alloying.tryMakeSteelIngot millingPlant recipe materialList

        // Assert
        Assert.IsTrue(actual.IsSome)
        Assert.AreEqual(Alloying.steelIngot, actual.Value)