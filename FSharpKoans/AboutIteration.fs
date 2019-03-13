namespace FSharpKoans
open NUnit.Framework

module ``05: To iterate is human; to recurse, divine`` =
    (*
        The `rec` keyword exposes the function identifier for use inside the function.
        And that's literally all that it does - it has no other purpose whatsoever.
    *)

    [<Test>]
    let ``01 `rec` exposes the name of the function for use inside the function`` () =
        let rec converge d c n = 
            match d = c with
            | false ->
                match d < c with
                | true -> converge (d+10) c (n+1) //if you removed the rec keyword above, you would get: The value or constructor 'converge' is not defined.
                | false -> converge (d - 1) c (n+1)
            | true -> n
        converge 3 10 0 |> should equal 4 //just work through the function with good ol' pen & paper :)

    [<Test>]
    let ``02 Tail recursion stops a stack overflow from occurring`` () =
        // CHANGE the recursive function to be tail recursive.
        let myfun n = 
            let sq = n*n
            let v = sq*sq*sq*sq
            let rec inner count acc =
                match count = v with 
                | true -> acc
                | false -> inner (count+1) (acc-1)
            inner sq 0

        myfun 12 |> should equal -429981552