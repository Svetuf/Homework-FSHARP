module Logic

    let func x l = List.map (fun y -> y * x) l
    let func1 x = List.map (fun y -> y * x)
    let func2 x = List.map ((*) x)
    let func3 ()  = List.map << (*)