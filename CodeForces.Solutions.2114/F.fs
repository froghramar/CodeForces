module CodeForces.Solutions._2114.F

open System
open System.Collections.Generic

let tests = Console.ReadLine() |> int

let rec getGcd = fun (x, y) -> (
    let mutable result = 0
    if y = 0 then
        result <- x
    elif x % y = 0 then
        result <- y
    else
        result <- getGcd(y, x % y)
    result)

let solve = fun (x, k) -> (
    let mutable result = 0
    if x <> 1 then
        let divs = List<int>()
        let sqrtX = x |> double |> sqrt |> int
        for i in 1 .. sqrtX do
            if x % i = 0 then
                divs.Add(i)
                divs.Add(x / i)
                
        divs.Sort()
        
        let n = divs.Count
        let dp = Array.create n 100
        dp[0] <- 0
        
        for i in 1 .. n - 1 do
            for j = i - 1 downto 0 do
                if (divs[i] / divs[j] <= k) && (divs[i] % divs[j] = 0) then
                    dp[i] <- min dp[i] (dp[j] + 1)
        
        if dp[n - 1] = 100 then
            result <- -1
        else
            result <- dp[n - 1]
    result)

for _ in 1 .. tests do
    let inputs = Console.ReadLine().Split [|' '|] |> Seq.map Int32.Parse |> Seq.toArray
    let mutable x = inputs[0] |> int
    let mutable y = inputs[1] |> int
    
    if x = y then
        printfn "0"
    else
        let k = inputs[2] |> int
        let gcd = getGcd(x, y)
        x <- x / gcd
        y <- y / gcd
        
        let ax = solve(x, k)
        let ay = solve(y, k)
        if ax = -1 || ay = -1 then
            printfn "-1"
        else
            let result = ax + ay
            printfn $"{result}"