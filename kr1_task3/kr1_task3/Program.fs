module Logic

    open System.Collections
    open System.Threading

    type Blocking_Queue () =
        /// A local queue.
        let mutable local_queue = Queue()
        /// Resent ebent to controll empty queue
        let resetEvent = new AutoResetEvent(false)
        /// Adding element.
        member this.add element = 
                lock this (fun () -> if local_queue.Count = 0
                                     then resetEvent.Set() |> ignore
                                     local_queue.Enqueue(element))
        /// Get and remove first element.
        member this.getFirstElement =
            lock this (fun () ->
            if local_queue.Count = 0
                then resetEvent.WaitOne() |> ignore
                     local_queue.Dequeue()
            else  local_queue.Dequeue())
        /// Return size.
        member this.getSize = 
            lock this (fun () -> local_queue.Count)

