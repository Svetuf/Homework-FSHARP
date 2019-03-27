module logic

    let findElement list element =
        let rec loop count list element =
            match list with
            | head::tail -> if(head = element)
                            then Some(count)
                            else loop (count + 1) tail element
            | [] -> None
                            
        loop 1 list element

    let testlist = [1..5]

    let filledList = findElement testlist 6

