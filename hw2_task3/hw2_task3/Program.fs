module Logic 

    let rec split ls left right =
        match ls with
        | [] -> (left, right)
        | [a] -> (a::left, right)
        | a::b::tail -> split tail (a::left) (b::right)

    let rec merge (list1: 'a list) (list2:'a list) : 'a list =
        match list1, list2 with
        | [], list -> list
        | list, [] -> list
        | firstElem1::tailList1, firstElem2::tailList2 when 
            firstElem1 < firstElem2 -> 
                firstElem1::(merge tailList1 (firstElem2::tailList2))
        | firstList, firstElem2::tailList2 -> 
            firstElem2::(merge firstList tailList2)

    let rec mergeSort list =
        match (List.length list) with
        | 1 -> list
        | 2 -> if list.Head < (List.item 1 list) then list
               else (List.rev list)
        | _ -> let (a,b) = (split list [] [])
               merge (mergeSort a) (mergeSort b)
               
    let a = mergeSort [3; 2; 1; 0; 7; 6; 5; 5; 5; 5; 6; 7; 8]