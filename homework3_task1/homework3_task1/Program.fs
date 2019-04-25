module Logic

    let numberOfEvenElementsInList1 list =  list |> List.map (fun x -> (x + 1) % 2) |> List.sum

    let numberOfEvenElementsInList2 list = list |> List.filter (fun x -> x % 2 = 0) |> List.length

    let numberOfEvenElementsInList3 list = List.fold (fun acc x -> acc + ((x + 1) % 2)) 0 list
