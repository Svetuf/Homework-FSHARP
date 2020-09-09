module Logic

    open System.Threading

    type ILazy<'a> = abstract member Get: unit -> 'a

    type SingleThread<'a>(supplier) =
        let mutable source = None

        interface ILazy<'a> with
            member this.Get() =
                match source with
                | Some(value) -> value
                | None -> 
                    source <- Some(supplier())
                    source.Value

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

    type MultiThreadNoLock<'a>(supplier) =
        let mutable source = None

        interface ILazy<'a> with
            member this.Get() =
                match source with
                | Some(value) -> value
                | None -> 
                    Interlocked.CompareExchange(&source, Some(supplier()), None) |> ignore
                    Option.get source