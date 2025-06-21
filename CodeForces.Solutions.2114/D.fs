module CodeForces.Solutions._2114.D

open System

let tests = Console.ReadLine() |> int

for _ in 1 .. tests do
    let n = Console.ReadLine() |> int
    let x : int array = Array.zeroCreate n
    let y : int array = Array.zeroCreate n
    
    for i in 0 .. n - 1 do
        let numbers = Console.ReadLine().Split [|' '|]
        x[i] <- numbers[0] |> int
        y[i] <- numbers[1] |> int
        
    if n = 1 then
        Console.WriteLine 1
    else
        let findTop = fun (getVal, comparator) ->
            let mutable top1 = 0
            let mutable top2 = 1
            
            if comparator(getVal(1), getVal(0)) then
                top1 <- 1
                top2 <- 0
                
            for i in 2 .. n - 1 do
                if comparator(getVal(i), getVal(top1)) then
                    top2 <- top1
                    top1 <- i
                elif comparator(getVal(i), getVal(top2)) then
                    top2 <- i
            (top1, top2)
        
        let getX = fun pos -> x[pos]
        let getY = fun pos -> y[pos]
        let minComparator = fun (val1, val2) -> val1 < val2
        let maxComparator = fun (val1, val2) -> val1 > val2
        
        let xMin = findTop(getX, minComparator)
        let xMax = findTop(getX, maxComparator)
        let yMin = findTop(getY, minComparator)
        let yMax = findTop(getY, maxComparator)
        
        let firstOrSecond = fun (pair, exclude) ->
            let mutable result1 = fst(pair)
            if exclude = fst(pair) then
                result1 <- snd(pair)
            result1
        
        let calc = fun exclude ->
            let xDiff = (x[firstOrSecond(xMax, exclude)] |> int64) - (x[firstOrSecond(xMin, exclude)] |> int64) + 1L
            let yDiff = (y[firstOrSecond(yMax, exclude)] |> int64) - (y[firstOrSecond(yMin, exclude)] |> int64) + 1L
            let mutable result1 = xDiff * yDiff
            if result1 < n then
                if xDiff < yDiff then
                    result1 <- result1 + xDiff
                else
                    result1 <- result1 + yDiff
            result1
        
        let mutable result = calc(-1)
        for i in 0 .. n - 1 do
            let newResult = calc(i)
            if newResult < result then
                result <- newResult
                
        Console.WriteLine result