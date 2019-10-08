module Logic

    // Thread save stack, supporting parallel pop and push.
    type ThreadSaveStack<'T>() = 
        let locker = new obj()
    
        let mutable stack : List<'T> = []

        // Thread save push.
        member this.Push value =
            lock locker (fun () -> 
                stack <- value :: stack)
            
        // Trying to pop element.
        member this.TryPop() =
            lock locker (fun () ->
                 match stack with
                 | result :: newStack ->
                    stack <- newStack
                    Some result
                 | [] -> None
            )  