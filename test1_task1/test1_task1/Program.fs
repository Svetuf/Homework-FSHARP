module Logic

    let infiniteUnity = Seq.initInfinite(fun i -> pown (-1) (i % 2))

    let naturalNumbers = Seq.initInfinite(fun i -> (i + 1))

    let makeResultFromSeq firstSeq secondSeq =
        let cortegeSeq  = Seq.zip infiniteUnity naturalNumbers
        Seq.map(fun (a, b) -> a * b) cortegeSeq

    // Stolen from stackoverflow to make tests work!
    let everyNth n seq = 
        seq |> Seq.mapi (fun i el -> el, i)             
            |> Seq.filter (fun (el, i) -> i % n = n - 1)
            |> Seq.map fst
    
    let answer n = (makeResultFromSeq infiniteUnity naturalNumbers) |> Seq.take n |> Seq.toArray