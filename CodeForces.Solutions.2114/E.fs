module CodeForces.Solutions._2114.E

open System
open System.Collections.Generic

let tests = Console.ReadLine() |> int
for _ in 1 .. tests do
    let n = Console.ReadLine() |> int
    let a = Console.ReadLine().Split [|' '|] |> Seq.map Int32.Parse |> Seq.toArray
    
    let edges : List<int> array = Array.zeroCreate n
    for i in 0 .. n - 1 do
        edges[i] <- List<int>()
    
    for _ in 1 .. n - 1 do
        let edge = Console.ReadLine().Split [|' '|]
        let u = edge[0] |> int
        let v = edge[1] |> int
        edges[u - 1].Add(v - 1)
        edges[v - 1].Add(u - 1)
        
        
    let max : int64 array = Array.zeroCreate n
        
    let rec calc = fun (v, p, mini, maxi) ->
        if mini < 0L then
            max[v] <- (a[v] |> int64) - mini
        else
            max[v] <- a[v]
          
        let mutable newMin = 0L
        if maxi > 0L then
            newMin <- (a[v] |> int64) - maxi
        else
            newMin <- a[v]
            
        for u in edges[v] do
            if u <> p then
                calc(u, v, newMin, max[v])
        ()
        
    calc(0, -1, 0L, 0L)
    
    for i in 0 .. n - 1 do
        printf $"{max[i]}"
        if i <> n - 1 then
            printf " "
    printf "\n"