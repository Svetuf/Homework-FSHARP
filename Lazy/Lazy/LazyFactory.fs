module LazyFactory  
     
    open Logic

    // Factory to create different Lazy realizations.
    type LazyFactory() =

        static member CreatesigngeThread supplier = SingleThread<'a>(supplier)

        static member CreateMultiThread supplier = MultiThread<'a>(supplier)

        static member CreateMultiThreadNoLock supplier = MultiThreadNoLock<'a>(supplier)



    
