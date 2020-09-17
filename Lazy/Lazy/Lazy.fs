module Logic

    open System.Threading
    
    /// Method to get a stared value.
    type ILazy<'a> = abstract member Get: unit -> 'a

    /// One thread type. Allow to get value of source.
    type SingleThread<'a>(supplier) =
        let mutable source = None

        interface ILazy<'a> with
            member this.Get() =
                match source with
                | Some(value) -> value
                | None -> 
                    source <- Some(supplier())
                    source.Value

    /// Multi thread type. Allow to get value, value calculate only once.
    type MultiThread<'a>(supplier) =
        let mutable source = None
        let locker = obj()

        interface ILazy<'a> with
            member this.Get() =
                match source with
                | Some(value) -> value
                | None -> 
                    lock locker ( fun () ->
                                    match source with
                                    |Some(value) -> value
                                    |None ->
                                        source <- Some(supplier())
                                        source.Value
                                )

    /// Lock-free multithreat realization. Value may calculate a lot of times, but write only one.
    type MultiThreadNoLock<'a>(supplier) =
        let mutable source = None

        interface ILazy<'a> with
            member this.Get() =
                match source with
                | Some(value) -> value
                | None -> 
                    Interlocked.CompareExchange(&source, Some(supplier()), None) |> ignore
                    Option.get source