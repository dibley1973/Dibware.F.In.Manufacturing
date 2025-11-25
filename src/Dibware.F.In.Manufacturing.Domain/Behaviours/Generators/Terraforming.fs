namespace Dibware.F.In.Manufacturing.Domain.Behaviours.Generators.Terraforming

open Dibware.F.In.Manufacturing.Domain.Types.Terraforming
open Dibware.F.In.Manufacturing.Domain.Types.Mining

module Terraforming =
    /// <summary>
    /// An array of available rock types.
    /// </summary>
    let rocks = [|
        IronImpregnatedRock; 
        CoalimpregnatedRock; 
        CopperImpregnatedRock; 
        Shale 
    |]

    /// <summary>
    /// A helper function that gets a random rock type.
    /// </summary>
    let public getRandomRock () : Rock =
        let randomIndex = System.Random().Next(rocks.Length)
        
        rocks.[randomIndex]

    /// <summary>
    /// A factory function that simulates terraforming a piece of land
    /// with random rock formations. Totally random.rock type selection.
    /// </summary>
    /// <param name="length">The length of the land.</param>
    /// <param name="width">The width of the land.</param>
    /// <returns>A GameArea representing the terraformed land.</returns>
    let public terraformRandomLand (length: int, width : int) : GameArea =
        let grid = Array2D.create length width IronImpregnatedRock

        // Cycle through each cell in the grid and assign a random rock type
        for lengthIndex in 0 .. length - 1 do
            for widthIndex in 0 .. width - 1 do
                grid.[lengthIndex, widthIndex] <- getRandomRock()

        // Return the generated GameArea
        { Grid = grid }

    /// <summary>
    /// A factory function that simulates terraforming a piece of land
    /// with a bias towards a preferred rock type. The higher the biasPercentage,
    /// the more likely the preferred rock type will appear.
    /// </summary>
    /// <param name="length">The length of the land.</param>
    /// <param name="width">The width of the land.</param>
    /// <param name="biasPercentage">
    /// The percentage chance of the preferred rock type appearing, with higher 
    /// the percentage, the more likely the preferred rock type will appear.
    /// </param>
    /// <returns>A GameArea representing the terraformed land.</returns>
    let public terraformBiasedLand (
        length: int, 
        width : int,
        biasPercentage: int) (preferredRock: Rock) : GameArea =
        let grid = Array2D.create length width IronImpregnatedRock
        
        // Cycle through each cell in the grid and assign a random rock type
        for lengthIndex in 0 .. length - 1 do
            for widthIndex in 0 .. width - 1 do
                let randomValue = System.Random().Next(0, 100)
                if randomValue < biasPercentage then
                    grid.[lengthIndex, widthIndex] <- preferredRock
                else
                    grid.[lengthIndex, widthIndex] <- getRandomRock()
        
        // Return the generated GameArea
        { Grid = grid }


