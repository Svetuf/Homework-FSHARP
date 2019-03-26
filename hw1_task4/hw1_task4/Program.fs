module logic

    let createList n m =
        let rec loop acc list m =
            match (List.length list) with
            | x when x = m + 1 -> list
            | _ -> loop (acc / 2) (acc :: list) (m - 1)
        loop (pown 2 n + m) [] m