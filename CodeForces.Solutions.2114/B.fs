module CodeForces.Solutions._2114.B

open System

let firstLine = Console.ReadLine()
let numberOfTests = firstLine |> int

for i in 1 .. numberOfTests do
    let numbersLine = Console.ReadLine()
    let numbersParsed = numbersLine.Split [|' '|]
    let n = numbersParsed[0] |> int
    let k = numbersParsed[1] |> int
     
    let input = Console.ReadLine()
    let ones = input |> Seq.filter(fun c -> c = '1') |> Seq.length
    let zeroes = n - ones
    let badPairCount = n/2 - k
    let goodOnes = ones - badPairCount
    let goodZeroes = zeroes - badPairCount
    
    let isEven x = x % 2 = 0
    let yes = (goodOnes >= 0) && (goodOnes |> isEven) && (goodZeroes >= 0) && (goodZeroes |> isEven)
    
    if yes then
        printfn "YES"
    else
        printfn "NO"