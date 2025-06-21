module CodeForces.Solutions.C2116.A

open System

let readInt () =
    let input = Console.ReadLine()
    input |> int

let numberOfTests = readInt()
for i in 1 .. numberOfTests do
    let input = readInt()
    
    let b = input |> double |> sqrt |> int
    if b * b = input then
        Console.WriteLine $"0 {b}"
    else
        Console.WriteLine -1