module CodeForces.Solutions._2114.C

open System

let tests = Console.ReadLine() |> int
for i in 1 .. tests do
    let n = Console.ReadLine() |> int
    let numbers = Console.ReadLine().Split [|' '|] |> Seq.map Int32.Parse |> Seq.toArray
    
    let mutable result = 1
    let mutable prev = 0;
    for i in 1 .. n - 1 do
        if numbers[i] > numbers[prev] + 1 then
            result <- result + 1
            prev <- i
            
    Console.WriteLine result